using ELopesAPI.Data;
using ELopesAPI.Models.Entities;
using ELopesAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ELopesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly LiteratureDbContext context;

        public BookController(LiteratureDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await context.Books
                .ToListAsync();

            var bookDto = books.Select(BookMapper.BookToDtoMap);

            return Ok(bookDto);
        }

        [HttpGet("GetBooksWithFullInfo")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksWithFullInfo()
        {
            var books = await context.Books
                .Include(b => b.BookReview)
                .Include(b => b.BookLinks)!
                .ThenInclude(l => l.Shop)
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/Your/5
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // GET: api/Your/5
        [HttpGet("GetBookWithFullInfo/{id}")]
        public async Task<ActionResult<Book>> GetBookWithFullInfo(int id)
        {
            var book = await context.Books
                .Include(b => b.BookReview)
                .Include(b => b.BookLinks)!
                .ThenInclude(l => l.Shop)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST: api/PostBook
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = book.Id }, book);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            context.Entry(book).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
