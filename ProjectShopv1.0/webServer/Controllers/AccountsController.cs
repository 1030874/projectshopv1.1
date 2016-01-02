using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webServer.Models;
using webServer.Models.Interface;
using webServer.Models.Repository;

namespace webServer.Controllers
{
    public class AccountsController : Controller
    {
        IAccountsRepository _repository;


        public AccountsController()
            : this(new AccountsRepository())
        {

        }

        public AccountsController(IAccountsRepository repository)
        {
            _repository = repository;
        }



        public ActionResult Index()
        {
             ViewData["ControllerName"] = this.ToString();
             return View("Index", _repository.GetAllAccounts());
        }

        public ActionResult Details(int id = 0)
        {
            Accounts acc = _repository.GetAccountsByID(id);
            return View("Details", acc);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Accounts accountsToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateAccounts(accountsToCreate);
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
            var accountsToEdit = _repository.GetAccountsByID(id);
            return View(accountsToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Accounts acc = _repository.GetAccountsByID(id);

            try
            {
                if (TryUpdateModel(acc))
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

            return View(acc);
        }

        public ActionResult Delete(int id)
        {
            var deleteAccounts = _repository.GetAccountsByID(id);
            return View(deleteAccounts);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteAccounts(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }    


        
         
    }
}