using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werzid.Models.Stripe
{
    public class ChargeModel
    {
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public string StripePublishableKey { get; set; }
        public bool PaymentFormHidden { get; set; }
        public string PaymentFormHiddenCss
        {
            get
            {
                return PaymentFormHidden ? "hidden" : "";
            }
        }
    }
}
