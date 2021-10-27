using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZlorpShack.Model;
using ZlorpShack.Service;

namespace ZlorpShack.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        private BookService CreateBookService()
        {
            BookService bookservice = new BookService();
            return bookservice;
        }

        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService service = CreateBookService();

            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetAllBooks();
            return Ok(books);
        }

        public IHttpActionResult Get(string title)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByTitle(title);
            return Ok(book);
        }

        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService bookService = CreateBookService();

            if (!bookService.UpdateBook(book))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            BookService bookService = CreateBookService();

            if(!bookService.DeleteBook(id))
                return InternalServerError();

            return Ok();
        }
    }
}
