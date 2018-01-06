namespace eFlorist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eflorist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Florists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloristName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InvoiceNo = c.String(),
                        WarehouseId = c.Int(nullable: false),
                        FloristId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Florists", t => t.FloristId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Id)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.WarehouseId)
                .Index(t => t.FloristId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        OrderCreatedDate = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        IsRejected = c.Boolean(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        OrderTruckId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        OrderPaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentTypes", t => t.OrderPaymentId, cascadeDelete: true)
                .ForeignKey("dbo.StatusTypes", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Trucks", t => t.OrderTruckId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.OrderStatusId)
                .Index(t => t.OrderTruckId)
                .Index(t => t.WarehouseId)
                .Index(t => t.OrderPaymentId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemQuantity = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemTypes", t => t.ItemTypeId, cascadeDelete: true)
                .Index(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemsName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TruckName = c.String(),
                        Brand = c.String(),
                        RegistrationNo = c.String(),
                        TruckTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId, cascadeDelete: true)
                .Index(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.TruckTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TruckTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(),
                        WarehouseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WarehouseTypes", t => t.WarehouseTypeId, cascadeDelete: true)
                .Index(t => t.WarehouseTypeId);
            
            CreateTable(
                "dbo.WarehouseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemFlorist",
                c => new
                    {
                        ItemRefId = c.Int(nullable: false),
                        FloristRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemRefId, t.FloristRefId })
                .ForeignKey("dbo.Items", t => t.ItemRefId, cascadeDelete: true)
                .ForeignKey("dbo.Florists", t => t.FloristRefId, cascadeDelete: true)
                .Index(t => t.ItemRefId)
                .Index(t => t.FloristRefId);
            
            CreateTable(
                "dbo.FloristWarehouse",
                c => new
                    {
                        FloristRefId = c.Int(nullable: false),
                        WarehouseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FloristRefId, t.WarehouseRefId })
                .ForeignKey("dbo.Florists", t => t.FloristRefId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseRefId, cascadeDelete: true)
                .Index(t => t.FloristRefId)
                .Index(t => t.WarehouseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloristWarehouse", "WarehouseRefId", "dbo.Warehouses");
            DropForeignKey("dbo.FloristWarehouse", "FloristRefId", "dbo.Florists");
            DropForeignKey("dbo.Invoices", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Orders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "WarehouseTypeId", "dbo.WarehouseTypes");
            DropForeignKey("dbo.Orders", "OrderTruckId", "dbo.Trucks");
            DropForeignKey("dbo.Trucks", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.StatusTypes");
            DropForeignKey("dbo.Orders", "OrderPaymentId", "dbo.PaymentTypes");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes");
            DropForeignKey("dbo.ItemFlorist", "FloristRefId", "dbo.Florists");
            DropForeignKey("dbo.ItemFlorist", "ItemRefId", "dbo.Items");
            DropForeignKey("dbo.Invoices", "Id", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "FloristId", "dbo.Florists");
            DropIndex("dbo.FloristWarehouse", new[] { "WarehouseRefId" });
            DropIndex("dbo.FloristWarehouse", new[] { "FloristRefId" });
            DropIndex("dbo.ItemFlorist", new[] { "FloristRefId" });
            DropIndex("dbo.ItemFlorist", new[] { "ItemRefId" });
            DropIndex("dbo.Warehouses", new[] { "WarehouseTypeId" });
            DropIndex("dbo.Trucks", new[] { "TruckTypeId" });
            DropIndex("dbo.Items", new[] { "ItemTypeId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropIndex("dbo.Orders", new[] { "OrderPaymentId" });
            DropIndex("dbo.Orders", new[] { "WarehouseId" });
            DropIndex("dbo.Orders", new[] { "OrderTruckId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Invoices", new[] { "FloristId" });
            DropIndex("dbo.Invoices", new[] { "WarehouseId" });
            DropIndex("dbo.Invoices", new[] { "Id" });
            DropTable("dbo.FloristWarehouse");
            DropTable("dbo.ItemFlorist");
            DropTable("dbo.WarehouseTypes");
            DropTable("dbo.Warehouses");
            DropTable("dbo.TruckTypes");
            DropTable("dbo.Trucks");
            DropTable("dbo.StatusTypes");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.Items");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Florists");
        }
    }
}
