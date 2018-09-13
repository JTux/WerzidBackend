using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werzid.Data
{   
    public class Transaction
    {
        [Required]
        public int TransactionID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        public bool Purchased { get; set; }
    }
}