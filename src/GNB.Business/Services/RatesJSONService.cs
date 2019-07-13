using System.Collections.Generic;
using GNB.Business.Interfaces;
using GNB.Business.Models;

namespace GNB.Business.Services
{
    public class RatesJSONService : IRatesService
    {
        public IEnumerable<ConversionRate> GetConversionRates()
        {
            throw new System.NotImplementedException();
        }

        public float GetConversionRateValue(string from, string to)
        {
            throw new System.NotImplementedException();
        }
    }
}
