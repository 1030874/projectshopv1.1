namespace webServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accountName = c.String(),
                        accountPassword = c.String(),
                        accountRole = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        accountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productCategory = c.Int(nullable: false),
                        productName = c.String(),
                        productDescription = c.String(),
                        productRegularPrice = c.Int(nullable: false),
                        productSalePrice = c.Int(nullable: false),
                        productQuantity = c.Int(nullable: false),
                        productStatus = c.Int(nullable: false),
                        productImage = c.String(),
                        productImageAltText = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
