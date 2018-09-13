using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werzid.Data;

namespace Werzid.Models.TransactionModels
{
    public class TransactionListItem
    {
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public bool Purchased { get; set; }
    }
}
