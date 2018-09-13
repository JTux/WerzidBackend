namespace Werzid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionvalueschanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "OwnerID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Transaction", "ProductID");
            AddForeignKey("dbo.Transaction", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "ProductID", "dbo.Product");
            DropIndex("dbo.Transaction", new[] { "ProductID" });
            DropColumn("dbo.Transaction", "OwnerID");
        }
    }
}
