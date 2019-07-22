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
            try
            {
                decimal total = 0;

                foreach (var amount in amounts)
                {
                    decimal convertedAmount = amount.Value * GetConversionRateValue(rates, amount.Currency, currencyCode.Value);
                    if(convertedAmount < 0)
                    {
                        throw new Exception($"No hay tasa de conversión desde {amount.Currency} hasta {currencyCode.Value}");
                    }
                    total += convertedAmount;
                }
                return total;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private decimal GetConversionRateValue(IEnumerable<ConversionRate> rates, string from, string to)
        {
            try
            {
                if(rates == null || rates.Count() == 0)
                {
                    return -1;
                }
                if(from == to)
                {
                    return 1;
                }

                ConversionRate exactConversion = rates.Where(r => r.From == from && r.To == to).FirstOrDefault();

                if (exactConversion != null)
                {
                    return exactConversion.Rate;
                }

                IEnumerable<ConversionRate> nextRates = rates.Where(r => r.From == from);
                IEnumerable<ConversionRate> filteredRates = rates.Where(r => r.To != from);

                foreach(ConversionRate nextRate in nextRates)
                {
                    var value = GetConversionRateValue(filteredRates, nextRate.To, to);
                    if(value > 0)
                    {
                        return nextRate.Rate * value;
                    }
                }
                return -1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
