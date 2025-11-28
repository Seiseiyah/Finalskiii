using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.Models;
using Finalskiii.SmartLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finalskiii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;

        public BookController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(dbContext.Books.ToList());
        }

     
        [HttpGet("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                Category = dto.Category,
                Status = dto.Status
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            return Ok(book);
        }

        // PUT: api/Book/{id}
        [HttpPut("{id:guid}")]
        public IActionResult UpdateBook(Guid id, UpdateBookDto dto)
        {
            var book = dbContext.Books.Find(id);

            if (book == null)
                return NotFound();

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.Category = dto.Category;
            book.Status = dto.Status;

            dbContext.SaveChanges();
            return Ok(book);
        }

        // DELETE: api/Book/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = dbContext.Books.Find(id);
            if (book == null)
                return NotFound();

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

            return Ok(book);
        }
    }
}

