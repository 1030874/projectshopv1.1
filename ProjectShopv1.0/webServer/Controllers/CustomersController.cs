using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webServer.Models;
using webServer.Models.Repository;

namespace webServer.Controllers
{
    public class CustomersController : Controller
    {
        ICustomersRepository _repository;

        public CustomersController()
            : this(new CustomersRepository())
        {

        }
        public CustomersController(ICustomersRepository repository)
        {
            _repository = repository;
        }

        // GET: Customers
        public ActionResult Index()
        {
            ViewData["ControllerName"] = this.ToString();
            return View("Index", _repository.GetAllCustomers());
        }

        public ActionResult Details(int id = 0)
        {
            Customers cus = _repository.GetCustomersByID(id);
            return View("Details", cus);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Customers CustomersToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateCustomer(CustomersToCreate);
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

        // GET: Customer/Edit/5
        //
        // GET: /Customer/Edit/5


        public ActionResult Edit(int id = 0)
        {
            var customersToEdit = _repository.GetCustomersByID(id);
            return View(customersToEdit);
        }


        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // GET: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Customers cus = _repository.GetCustomersByID(id);

            try
            {
                if (TryUpdateModel(cus))
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

            return View(cus);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteCustomer = _repository.GetCustomersByID(id);
            return View(deleteCustomer);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteCustomers(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }    



    }
}