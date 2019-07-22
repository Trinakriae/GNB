using GNB.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Business.Interfaces
{
    public interface IPersistenceService
    {
        void SaveTransactions(IEnumerable<BusinessTransaction> transactions);
        void SaveRates(IEnumerable<ConversionRate> rates);
    }
}
