namespace Werzid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedtransactionproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "ProductID_ProductID", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "ProductID_ProductID" });
            AddColumn("dbo.Transaction", "ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "ProductID_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "ProductID_ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.Transaction", "ProductID");
            CreateIndex("dbo.Transaction", "ProductID_ProductID");
            AddForeignKey("dbo.Transaction", "ProductID_ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
    }
}
