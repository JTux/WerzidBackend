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
        public int OwnerID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        //Image
    }
}
