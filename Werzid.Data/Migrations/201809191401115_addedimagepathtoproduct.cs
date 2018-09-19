namespace Werzid.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedimagepathtoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductImagePath");
        }
    }
}
