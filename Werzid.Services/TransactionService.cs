using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Contracts;
using Werzid.Data;
using Werzid.Data.IdentityModels;
using Werzid.Models.TransactionModels;

namespace Werzid.Services
{
    public class TransactionService : ITransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity = new Transaction()
            {
                ProductQuantity = model.ProductQuantity,
                Purchased = model.Purchased
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionID = e.TransactionID,
                                    ProductID = e.ProductID,
                                    ProductQuantity = e.ProductQuantity,
                                    Purchased = e.Purchased
                                }
                        );
                var queryArray = query.ToArray();
                return queryArray;
            }
        }

        public TransactionDetail GetTransactionByID(int transactionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(e => e.TransactionID == transactionID);

                return
                    new TransactionDetail
                    {
                        TransactionID = entity.TransactionID,
                        ProductID = entity.ProductID,
                        ProductQuantity = entity.ProductQuantity,
                        Purchased = entity.Purchased
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(e => e.TransactionID == model.TransactionID);

                entity.TransactionID = model.TransactionID;
                entity.ProductID = model.ProductID;
                entity.ProductQuantity = model.ProductQuantity;
                entity.Purchased = model.Purchased;

                return ctx.SaveChanges() == 1;
            }
        }
    


        public bool DeleteTransaction(int transactionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(e => e.TransactionID == transactionID);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }   
}