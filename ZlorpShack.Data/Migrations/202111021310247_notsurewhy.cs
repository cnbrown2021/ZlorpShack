namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsurewhy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "StudentId", "dbo.Student");
            DropIndex("dbo.Book", new[] { "StudentId" });
            CreateTable(
                "dbo.BookStudent",
                c => new
                    {
                        Book_BookID = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookID, t.Student_StudentId })
                .ForeignKey("dbo.Book", t => t.Book_BookID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Book_BookID)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookStudent", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.BookStudent", "Book_BookID", "dbo.Book");
            DropIndex("dbo.BookStudent", new[] { "Student_StudentId" });
            DropIndex("dbo.BookStudent", new[] { "Book_BookID" });
            DropTable("dbo.BookStudent");
            CreateIndex("dbo.Book", "StudentId");
            AddForeignKey("dbo.Book", "StudentId", "dbo.Student", "StudentId");
        }
    }
}
