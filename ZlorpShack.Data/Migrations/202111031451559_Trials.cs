namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Award", "StudentId", c => c.Int());
            CreateIndex("dbo.Award", "StudentId");
            AddForeignKey("dbo.Award", "StudentId", "dbo.Student", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Award", "StudentId", "dbo.Student");
            DropIndex("dbo.Award", new[] { "StudentId" });
            DropColumn("dbo.Award", "StudentId");
        }
    }
}
