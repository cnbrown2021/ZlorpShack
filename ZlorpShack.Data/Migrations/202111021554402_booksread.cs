namespace ZlorpShack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booksread : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookStudent", "Book_BookID", "dbo.Book");
            DropForeignKey("dbo.BookStudent", "Student_StudentId", "dbo.Student");
            DropIndex("dbo.BookStudent", new[] { "Book_BookID" });
            DropIndex("dbo.BookStudent", new[] { "Student_StudentId" });
            CreateIndex("dbo.Book", "StudentId");
            AddForeignKey("dbo.Book", "StudentId", "dbo.Student", "StudentId");
            DropTable("dbo.BookStudent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookStudent",
                c => new
                    {
                        Book_BookID = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookID, t.Student_StudentId });
            
            DropForeignKey("dbo.Book", "StudentId", "dbo.Student");
            DropIndex("dbo.Book", new[] { "StudentId" });
            CreateIndex("dbo.BookStudent", "Student_StudentId");
            CreateIndex("dbo.BookStudent", "Book_BookID");
            AddForeignKey("dbo.BookStudent", "Student_StudentId", "dbo.Student", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.BookStudent", "Book_BookID", "dbo.Book", "BookID", cascadeDelete: true);
        }
    }
}
