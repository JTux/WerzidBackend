using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werzid.Models.ProductModels;
using Werzid.Services;

namespace Werzid.WebApi.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var service = new ProductService();
            return View(service.GetProducts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new ProductService();

            if (service.CreateProduct(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new ProductService();
            return View(service.GetProductByID(id));
        }

        public ActionResult Edit(int id)
        {
            var service = new ProductService();
            var detail = service.GetProductByID(id);
            var model =
                new ProductEdit
                {
                    ProductID = detail.ProductID,
                    ProductName = detail.ProductName,
                    ProductionDescription = detail.ProductionDescription,
                    ProductPrice = detail.ProductPrice
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductID != id)
            {
                ModelState.AddModelError("", "Ids are mismatched");
                return View(model);
            }

            var service = new ProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Product has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ProductService();
            return View(service.GetProductByID(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ProductService();
            service.DeleteProduct(id);
            TempData["SaveResult"] = "Product was deleted.";
            return RedirectToAction("Index");
        }
    }
}