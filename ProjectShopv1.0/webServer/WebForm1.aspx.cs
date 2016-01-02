using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webServer.Models;


namespace webServer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obs køres kun databasen skal seedes
        
            using(var db = new DatabaseConnection())
            {
                db.Accounts.Add(new Accounts { accountName = "Rene", accountPassword="123", accountRole="admin" });
                db.Customers.Add(new Customers { firstName="Jose", lastName="phine" });

                db.SaveChanges();
            }


        }
    }
}