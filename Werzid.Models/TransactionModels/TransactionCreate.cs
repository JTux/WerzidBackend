using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Data;

namespace Werzid.Models.TransactionModels
{
    public class TransactionCreate
    {
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public bool Purchased { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
