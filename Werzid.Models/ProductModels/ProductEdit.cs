using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werzid.Models.ProductModels
{
    public class ProductEdit
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductionDescription { get; set; }
        //ProductImage
    }
}
