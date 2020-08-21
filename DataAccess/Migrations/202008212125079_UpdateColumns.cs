namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumns : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Image", "ProductId");
            AddForeignKey("dbo.Image", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropIndex("dbo.Image", new[] { "ProductId" });
        }
    }
}
