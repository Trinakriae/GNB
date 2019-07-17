using GNB.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB.Business.Interfaces
{
    public interface IRatesService
    {
        Task<IEnumerable<ConversionRate>> GetConversionRates();
    }
}
