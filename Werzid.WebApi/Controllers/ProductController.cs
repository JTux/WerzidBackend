using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Werzid.Models.ProductModels;
using Werzid.Services;

namespace Werzid.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ProductService productService = new ProductService();
            var products = productService.GetProducts();
            return Ok(products);
        }

        public IHttpActionResult Get(int id)
        {
            ProductService productService = new ProductService();
            var note = productService.GetProductByID(id);
            return Ok(note);
        }

        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new ProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new ProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();

            return Ok();
        }
    }
}