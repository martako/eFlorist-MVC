namespace eFlorist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nvarchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Florists", "FloristName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Invoices", "InvoiceNo", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Orders", "OrderNo", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Items", "ItemName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.ItemTypes", "ItemsName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.PaymentTypes", "PaymentName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.StatusTypes", "StatusName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Trucks", "TruckName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Trucks", "Brand", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Trucks", "RegistrationNo", c => c.String(maxLength: 4000));
            AlterColumn("dbo.TruckTypes", "TruckTypeName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Warehouses", "WarehouseName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.WarehouseTypes", "WarehouseTypeName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 60));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Movies", "Rating", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.String(maxLength: 5, unicode: false));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.WarehouseTypes", "WarehouseTypeName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Warehouses", "WarehouseName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.TruckTypes", "TruckTypeName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Trucks", "RegistrationNo", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Trucks", "Brand", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Trucks", "TruckName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.StatusTypes", "StatusName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.PaymentTypes", "PaymentName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.ItemTypes", "ItemsName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Orders", "OrderNo", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Invoices", "InvoiceNo", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Florists", "FloristName", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
