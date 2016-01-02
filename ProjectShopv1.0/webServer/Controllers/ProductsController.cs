using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webServer.Models;
using webServer.Models.Interface;
using webServer.Models.Repository;

namespace webServer.Controllers
{
    public class ProductsController : Controller
    {
        IProductsRepository _repository;

        public ProductsController()  
            : this(new ProductsRepository())
        {

        }

        public ProductsController(IProductsRepository repository)
        {
            _repository = repository; 
        }

        public ActionResult Index()
        {
            ViewData["ControllerName"] = this.ToString();
            return View("Index", _repository.GetAllProducts());
        }

        public ActionResult Details(int id = 0)
        {
            Products pro = _repository.GetProductsByID(id);
            return View("Details", pro);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Products productsToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateProducts(productsToCreate);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex);
                ViewData["CreateError"] = "Unable to create; view innerexception";
            }
            return View("Create");
        }

        public ActionResult Edit(int id = 0)
        {
            var productsToEdit = _repository.GetProductsByID(id);
            return View(productsToEdit);
        }

        public ActionResult Search(string search)
        {
            var productsSearch = _repository.Search(search);

            return View(productsSearch.ToList());
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Products pro = _repository.GetProductsByID(id);

            try
            {
                if (TryUpdateModel(pro))
                {
                    _repository.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                    ViewData["EditError"] = ex.InnerException.ToString();
                else
                    ViewData["EditError"] = ex.ToString();
            }

#if DEBUG
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    if (error.Exception != null)
                    {
                        throw modelState.Errors[0].Exception;
                    }
                }
            }
#endif

            return View(pro);
        }


        public ActionResult Delete(int id)
        {
            var deleteProducts = _repository.GetProductsByID(id);
            return View(deleteProducts);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteProducts(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }    





    }
}
