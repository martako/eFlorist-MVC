namespace eFlorist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloristProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FloristId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "FloristId");
            AddForeignKey("dbo.Orders", "FloristId", "dbo.Florists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FloristId", "dbo.Florists");
            DropIndex("dbo.Orders", new[] { "FloristId" });
            DropColumn("dbo.Orders", "FloristId");
        }
    }
}
