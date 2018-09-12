using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Models.ProductModels;

namespace Werzid.Contracts
{
    public interface IProductService
    {
        bool CreateProduct(ProductCreate model);
        IEnumerable<ProductListItem> GetProduct();
        ProductDetail GetProductByID(int productID);
        bool UpdateProduct(ProductEdit model);
        bool DeleteProduct(int productID);
    }
}
