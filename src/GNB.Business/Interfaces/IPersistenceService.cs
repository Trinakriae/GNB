using GNB.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Business.Interfaces
{
    public interface IPersistenceService
    {
        Task SaveTransactions(IEnumerable<BusinessTransaction> transactions);
        Task SaveRates(IEnumerable<ConversionRate> rates);
    }
}
