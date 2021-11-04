namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentBooksIDAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentBooks",
                c => new
                    {
                        StudentBooksId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentBooksId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentBooks", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentBooks", "BookId", "dbo.Book");
            DropIndex("dbo.StudentBooks", new[] { "BookId" });
            DropIndex("dbo.StudentBooks", new[] { "StudentId" });
            DropTable("dbo.StudentBooks");
        }
    }
}
