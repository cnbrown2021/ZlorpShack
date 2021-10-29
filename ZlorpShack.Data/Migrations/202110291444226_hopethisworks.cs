namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopethisworks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "FullName", c => c.String());
        }
    }
}
