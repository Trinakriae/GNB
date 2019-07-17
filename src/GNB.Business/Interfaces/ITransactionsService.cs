using GNB.Business.Enums;
using GNB.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB.Business.Interfaces
{
    public interface ITransactionsService
    {
        Task<IEnumerable<BusinessTransaction>> GetTransactions();
        Task<IEnumerable<BusinessTransaction>> GetTransactionsBySKU(string SKU);
    }
}
