using System.Collections.Generic;
using System.Transactions;

namespace GNB.Business.Interfaces
{
    public interface ITransactionsService
    {
        IEnumerable<Transaction> GetTransactions();
    }
}
