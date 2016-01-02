namespace webServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts
    {
        public int id { get; set; }

        public string accountName { get; set; }

  
        public string accountPassword { get; set; }

  
        public string accountRole { get; set; }
    }
}
