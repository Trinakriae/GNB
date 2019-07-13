using System.Collections.Generic;
using System.Transactions;
using GNB.Business.Interfaces;

namespace GNB.Business.Services
{
    public class TransactionsJSONService : ITransactionsService
    {
        public IEnumerable<Transaction> GetTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}
