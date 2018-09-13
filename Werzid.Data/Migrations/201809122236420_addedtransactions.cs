namespace Werzid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtransactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        ProductQuantity = c.Int(nullable: false),
                        Purchased = c.Boolean(nullable: false),
                        ProductID_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Product", t => t.ProductID_ProductID, cascadeDelete: true)
                .Index(t => t.ProductID_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ProductID_ProductID", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "ProductID_ProductID" });
            DropTable("dbo.Transaction");
        }
    }
}
