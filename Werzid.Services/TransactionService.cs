using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Contracts;
using Werzid.Models.TransactionModels;

namespace Werzid.Services
{
    public class TransactionService : ITransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int TransactionID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public TransactionDetail GetTransactionByID(int transactionID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
