using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werzid.Data
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        //Image
    }
}