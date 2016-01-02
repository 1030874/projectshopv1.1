namespace webServer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Infrastructure;

    public partial class DatabaseConnection : DbContext
    {
        public DatabaseConnection() : base("DatabaseConnection")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();,
            //throw new UnintentionalCodeFirstException();
        }
    }
}
