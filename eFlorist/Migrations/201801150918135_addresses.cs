namespace eFlorist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Florists", "FloristAddress", c => c.String(maxLength: 4000));
            AddColumn("dbo.Warehouses", "WarehouseAddress", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Warehouses", "WarehouseAddress");
            DropColumn("dbo.Florists", "FloristAddress");
        }
    }
}
