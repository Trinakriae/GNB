using GNB.Business.Models;
using System.Collections.Generic;

namespace GNB.Business.Interfaces
{
    public interface IRatesService
    {
        IEnumerable<ConversionRate> GetConversionRates();
        float GetConversionRateValue(string from, string to);
    }
}
