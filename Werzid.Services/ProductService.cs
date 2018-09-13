using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Contracts;
using Werzid.Data;
using Werzid.Data.IdentityModels;
using Werzid.Models.ProductModels;

namespace Werzid.Services
{
    public class ProductService : IProductService
    {
        public bool CreateProduct(ProductCreate model)
        {
            var entity = new Product()
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(
                            e=>
                                new ProductListItem
                                {
                                    ProductID = e.ProductID,
                                    ProductName = e.ProductName,
                                    ProductDescription = e.ProductDescription,
                                    ProductPrice = e.ProductPrice
                                }
                        );
                var queryArray = query.ToArray();
                return queryArray;
            }
        }

        public ProductDetail GetProductByID(int productID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductID == productID);

                return
                    new ProductDetail
                    {
                        ProductID = entity.ProductID,
                        ProductName = entity.ProductName,
                        ProductDescription = entity.ProductDescription,
                        ProductPrice = entity.ProductPrice
                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductID == model.ProductID);

                entity.ProductID = model.ProductID;
                entity.ProductName = model.ProductName;
                entity.ProductDescription = model.ProductDescription;
                entity.ProductPrice = model.ProductPrice;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Products.Single(e => e.ProductID == productID);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
