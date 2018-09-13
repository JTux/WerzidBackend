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
        public Guid OwnerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public virtual Product TransactionProduct { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public bool Purchased { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}