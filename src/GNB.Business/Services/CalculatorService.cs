using System;
using System.Collections.Generic;
using System.Linq;
using GNB.Business.Enums;
using GNB.Business.Interfaces;
using GNB.Business.Models;

namespace GNB.Business.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal ComputeTotalTransactionValueByCurrency(IEnumerable<Amount> amounts, IEnumerable<ConversionRate> rates, CurrencyCode currencyCode)
        {
            decimal total = 0;

            foreach(var amount in amounts)
            {
                total = total + amount.Value * GetConversionRateValue(rates, amount.Currency, currencyCode.Value);
            }

            return total;
        }

        private decimal GetConversionRateValue(IEnumerable<ConversionRate> rates, string from, string to)
        {
            try
            {
                if(rates == null || rates.Count() == 0)
                {
                    return 0;
                }

                ConversionRate exactConversion = rates.Where(r => r.From == from && r.To == to).FirstOrDefault();

                if (exactConversion != null)
                {
                    return exactConversion.Rate;
                }

                var list = rates.Where(r => r.To == from);
                var newList = rates.Where(r => r.From != from && r.To != to);

                foreach(var item in list)
                {
                    var value = GetConversionRateValue(newList, item.From, item.To);
                    if(value > 0)
                    {
                        return item.Rate * value;
                    }
                }
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
