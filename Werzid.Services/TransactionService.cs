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
        private readonly Guid _userID;

        public TransactionService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Transaction()
                {
                    OwnerID = _userID,
                    ProductID = model.ProductID,
                    ProductQuantity = model.ProductQuantity,
                    TotalPrice = ((ctx.Products.Single(e => e.ProductID == model.ProductID)).ProductPrice) * model.ProductQuantity,
                    Purchased = model.Purchased
                };

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
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    TransactionID = e.TransactionID,
                                    ProductID = e.ProductID,
                                    ProductQuantity = e.ProductQuantity,
                                    TotalPrice = e.TotalPrice,
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
                var entity = ctx.Transactions.Where(e => e.OwnerID == _userID).Single(e => e.TransactionID == transactionID);

                return
                    new TransactionDetail
                    {
                        TransactionID = entity.TransactionID,
                        ProductID = entity.ProductID,
                        ProductQuantity = entity.ProductQuantity,
                        TotalPrice = entity.TotalPrice,
                        Purchased = entity.Purchased
                    };
            }
        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Where(e => e.OwnerID == _userID).Single(e => e.TransactionID == model.TransactionID);

                entity.TransactionID = model.TransactionID;
                entity.ProductID = model.ProductID;
                entity.ProductQuantity = model.ProductQuantity;
                entity.TotalPrice = ((ctx.Products.Single(e => e.ProductID == model.ProductID)).ProductPrice) * model.ProductQuantity;
                entity.Purchased = model.Purchased;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Where(e => e.OwnerID == _userID).Single(e => e.TransactionID == transactionID);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}