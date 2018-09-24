using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Werzid.Models.Stripe;
using Werzid.Models.StripeModels;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using StripeProduct = Werzid.Models.StripeModels.StripeProduct;

namespace Werzid.WebApi.Controllers
{
    public class ChargeController : ApiController
    {
        // GET: Product
        public IHttpActionResult Index()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new StripeProduct() { StripePublishableKey = stripePublishableKey };
            return Ok(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IHttpActionResult Charge(ChargeModel chargeModel)
        {
            return Redirect("Confirmation");
        }

        public IHttpActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new ChargeModel() { StripePublishableKey = stripePublishableKey, PaymentFormHidden = true };
            return Ok(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IHttpActionResult Custom(ChargeModel chargeModel)
        {
            var chargeOptions = new StripeChargeCreateOptions()
            {
                Amount = 1999,
                Currency = "usd",
                ReceiptEmail = chargeModel.StripeEmail,
                SourceTokenOrExistingSourceId = chargeModel.StripeToken,
            };
            var chargeService = new StripeChargeService();
            try
            {
                var stripeCharge = chargeService.Create(chargeOptions);
            }
            catch (StripeException stripeException)
            {
                ModelState.AddModelError(string.Empty, stripeException.Message);
                return Ok(chargeModel);
            }
            return Redirect("Confirmation");
        }
        // GET: Confirmation
        public IHttpActionResult Confirmation()
        {
            return Ok();
        }
    }
}
