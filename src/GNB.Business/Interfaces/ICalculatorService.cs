using GNB.Business.Enums;
using GNB.Business.Models;
using System.Collections.Generic;

namespace GNB.Business.Interfaces
{
    public interface ICalculatorService
    {
        decimal ComputeTotalTransactionValueByCurrency(IEnumerable<Amount> amounts, IEnumerable<ConversionRate> rates, CurrencyCode currencyCode);
    }
}
