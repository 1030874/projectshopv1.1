using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


using System.Web.Security;
using webServer.Models;
using System.Net.Mail;
using System.Net;

namespace webServer.Controllers
{
    public class AuthController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();
        // GET: Login
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(Accounts model, string returnUrl)
        {
                // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                using (DatabaseConnection db = new DatabaseConnection())
                {

                    string accountName = model.accountName;
                    string accountPassword = model.accountPassword;

                    bool userValid = db.Accounts.Any(account => account.accountName == accountName && account.accountPassword == accountPassword);


                    // Checks value in the database is equal to accountName and accountPassword
                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(accountName, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "UI");
                        }
                    }

                    else
                    {
                        ModelState.AddModelError("", "Forkert e-mail eller adgangskode");
                    }
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Logon", "Auth");
        }




      public ActionResult ForgotPassword()
      {
          return View();
      }

       [HttpPost]

      
      public ActionResult ForgotPassword(Accounts model)
      {
          if (ModelState.IsValid)
          {
              using (DatabaseConnection db = new DatabaseConnection())
              {
                  string accountName = model.accountName;

                  bool userValid = db.Accounts.Any(account => account.accountName == accountName);

                  if (userValid)
                  {
                     Accounts acc = db.Accounts.Single(x => x.accountName == accountName);

                     string lostPass;

                     lostPass = acc.accountPassword;
                   
                      ViewBag.Succes = "Vi har sendt en e-mail med din adgangskode...";


                      MailMessage mailMessage = new MailMessage();
                      MailAddress fromAddress = new MailAddress("noreply@projectshop.dk");
                      mailMessage.From = fromAddress;
                      mailMessage.To.Add(accountName);

                      mailMessage.Body = "This is Testing Email Without Configured SMTP Server";
                      mailMessage.IsBodyHtml = true;
                      mailMessage.Subject = lostPass;
                      SmtpClient smtpClient = new SmtpClient();
                      smtpClient.Host = "localhost";
                      smtpClient.Send(mailMessage);
                      
                    
                     
                  }
                  else
                  {
                      ModelState.AddModelError("", "Brugeren findes ikke.");
                  }
               
              }

          }
          return View();
      }



    }
}