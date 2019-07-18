using GNB.Business.Interfaces;
using GNB.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Business.Services
{
    public class FileService : IPersistenceService
    {
        public Task SaveTransactions(IEnumerable<BusinessTransaction> transactions)
        {
            throw new NotImplementedException();
        }

        public Task SaveRates(IEnumerable<ConversionRate> rates)
        {
            throw new NotImplementedException();
        }
    }
}
