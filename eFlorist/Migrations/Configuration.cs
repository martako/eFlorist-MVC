namespace eFlorist.Migrations
{
    using eFlorist.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eFlorist.Models.EFloristDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eFlorist.Models.EFloristDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.TruckTypes.AddOrUpdate(i => i.TruckTypeName,
            new TruckType
            {
                TruckTypeName = "Samoch�d osobowy",
                Trucks = new List<Truck>()
            },
            new TruckType
            {
                TruckTypeName = "Ci�ar�wka",
                Trucks = new List<Truck>()
            },
            new TruckType
            {
                TruckTypeName = "TIR",
                Trucks = new List<Truck>()
            });

            context.StatusTypes.AddOrUpdate(i => i.StatusName,
            new StatusType
            {
                StatusName = "Do akceptacji",
                Orders = new List<Order>()
            },
            new StatusType
            {
                StatusName = "Zaakceptowane",
                Orders = new List<Order>()
            },
            new StatusType
            {
                StatusName = "Zrealizowane",
                Orders = new List<Order>()
            });

            context.ItemTypes.AddOrUpdate(i => i.ItemsName,
            new ItemType
            {
                ItemsName = "Kwiaty",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Nasiona",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Doniczki",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Opakowania prezentowe",
                Items = new List<Item>()
            },
            new ItemType
            {
                ItemsName = "Ozdoby",
                Items = new List<Item>()
            });

            context.PaymentTypes.AddOrUpdate(i => i.PaymentName,
            new PaymentType
            {
                PaymentName = "P�atno�� przy odbiorze",
                Orders = new List<Order>()
            },
            new PaymentType
            {
                PaymentName = "Przedp�ata",
                Orders = new List<Order>()
            });

            context.WarehouseTypes.AddOrUpdate(i => i.WarehouseTypeName,
            new WarehouseType
            {
                WarehouseTypeName = "Magazyn otwarty",
                Warehouses = new List<Warehouse>()
            },
            new WarehouseType
            {
                WarehouseTypeName = "Magazyn zamkni�ty",
                Warehouses = new List<Warehouse>()
            },
            new WarehouseType
            {
                WarehouseTypeName = "Magazyn p�otwarty",
                Warehouses = new List<Warehouse>()
            });
        }
    }
}
