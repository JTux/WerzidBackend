using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Models.TransactionModels;

namespace Werzid.Contracts
{
    public interface ITransactionService
    {
        bool CreateTransaction(TransactionCreate model);
        IEnumerable<TransactionListItem> GetTransactions();
        TransactionDetail GetTransactionByID(int transactionID);
        bool UpdateTransaction(TransactionEdit model);
        bool DeleteTransaction(int TransactionID);
    }
}