namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Getter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "Age");
            DropColumn("dbo.Student", "Grade");
            DropColumn("dbo.Student", "CurrentRewardTier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "CurrentRewardTier", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "Grade", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
        }
    }
}
