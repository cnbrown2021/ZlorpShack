namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "StudentId", "dbo.Student");
            DropIndex("dbo.Book", new[] { "StudentId" });
            AlterColumn("dbo.Book", "StudentId", c => c.Int());
            CreateIndex("dbo.Book", "StudentId");
            AddForeignKey("dbo.Book", "StudentId", "dbo.Student", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "StudentId", "dbo.Student");
            DropIndex("dbo.Book", new[] { "StudentId" });
            AlterColumn("dbo.Book", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "StudentId");
            AddForeignKey("dbo.Book", "StudentId", "dbo.Student", "StudentId", cascadeDelete: true);
        }
    }
}
