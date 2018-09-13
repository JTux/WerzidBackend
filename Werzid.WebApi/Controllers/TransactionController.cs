using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Werzid.Models.TransactionModels;
using Werzid.Services;

namespace Werzid.WebApi.Controllers
{
    [Authorize]
    public class TransactionController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TransactionService transactionService = GetTransactionService();
            var transactions = transactionService.GetTransactions();
            return Ok(transactions);
        }

        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = GetTransactionService();
            var transaction = transactionService.GetTransactionByID(id);
            return Ok(transaction);
        }

        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = GetTransactionService();

            if (!service.CreateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = GetTransactionService();

            if (!service.UpdateTransaction(transaction))
                return InternalServerError();

            return Ok();
;        }

        public IHttpActionResult Delete(int id)
        {
            var service = GetTransactionService();

            if (!service.DeleteTransaction(id))
                return InternalServerError();

            return Ok();
        }

        private TransactionService GetTransactionService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(userID);
            return transactionService;
        }
    }
}