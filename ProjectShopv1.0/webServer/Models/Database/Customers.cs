
namespace webServer.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Customers
    {
        public int id { get; set; }

        [DisplayName("Fornavn")]
        public string firstName { get; set; }
        [DisplayName("Efternavn")]
        public string lastName { get; set; }

        [DisplayName("Account rolle")]
        // Add-Migration define a name
        //Update-Database
        public int accountId { get; set; }
    }
}