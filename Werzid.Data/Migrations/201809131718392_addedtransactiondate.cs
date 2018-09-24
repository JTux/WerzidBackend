namespace Werzid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtransactiondate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "PurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "PurchaseDate");
        }
    }
}
