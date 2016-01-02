using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webServer.Models;


namespace webServer
{
    public partial class Seed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // slet mappen Migrations før koden køres..
            // Obs køres kun databasen skal seedes

            /**
             * 1# Delete eksisternede mappe migrations samt tabeller i databasen
             * 2# kør "Enable-Migrations" i package manager
             * 3# kør "Add-Migration" ved eventuelle ændringer
             * 4# kør "Update-Database" i forhold til opdateringer af ændringer **/


            using (var db = new DatabaseConnection())
            {
                db.Accounts.Add(new Accounts { accountName = "Rene", accountPassword="123", accountRole="admin" });
                db.Customers.Add(new Customers { firstName="Jose", lastName="phine" });
                db.Products.Add(new Products { productName="Iphone 6", productCategory=1, productDescription="beskrivelse", productImage="text.png", productStatus=1, productImageAltText="seotext", productQuantity=1, productRegularPrice=2, productSalePrice=2  });

                db.SaveChanges();
            }


        }
    }
}