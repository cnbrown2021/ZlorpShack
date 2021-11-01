using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlorpShack.Data;
using ZlorpShack.Model;

namespace ZlorpShack.Service
{
    public class BookService
    {
        public bool CreateBook(BookCreate book)
        {
            var entity = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Summary = book.Summary,
                StudentId = book.StudentId
            };
            
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookList> GetAllBooks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Books.Select(e => new BookList
                {
                    BookID = e.BookID,
                    Title = e.Title,
                    Author = e.Author
                }
                );

                return query.ToArray();
            }
        } 

        public BookDetail GetBookByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.Title == title);

                return new BookDetail
                {
                    BookID = entity.BookID,
                    Title = entity.Title,
                    Author = entity.Author,
                    Genre = entity.Genre,
                    Summary = entity.Summary,
                };
            }
        }

        public bool UpdateBook(BookEdit book)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookID == book.BookID);

                entity.Title = book.Title;
                entity.Author = book.Author;
                entity.Genre = book.Genre;
                entity.Summary = book.Summary;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookID == bookID);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
