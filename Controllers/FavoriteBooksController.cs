using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;
using TeamWebAPI.Models;

namespace TeamWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteBook>> GetFavoriteBook(int id)
        {
            var favoriteBook = await _context.FavoriteBook.FindAsync(id);

            if (favoriteBook == null)
            {
                return NotFound();
            }

            return favoriteBook;
        }

        // GET: api/FavoriteBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetFavoriteBooks([FromQuery] int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.FavoriteBook.Take(5).ToListAsync();
            }
            else
            {
                var favoriteBook = await _context.FavoriteBook.FindAsync(id);

                if (favoriteBook == null)
                {
                    return NotFound();
                }

                return Ok(favoriteBook);
            }
        }

        // POST: api/FavoriteBooks
        [HttpPost]
        public async Task<ActionResult<FavoriteBook>> PostFavoriteBook(FavoriteBook favoriteBook)
        {
            _context.FavoriteBook.Add(favoriteBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavoriteBooks), new { id = favoriteBook.Id }, favoriteBook);
        }

        // PUT: api/FavoriteBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteBook(int id, FavoriteBook favoriteBook)
        {
            if (id != favoriteBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteBookExists(id))
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

        // DELETE: api/FavoriteBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteBook(int id)
        {
            var favoriteBook = await _context.FavoriteBook.FindAsync(id);
            if (favoriteBook == null)
            {
                return NotFound();
            }

            _context.FavoriteBook.Remove(favoriteBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteBookExists(int id)
        {
            return _context.FavoriteBook.Any(e => e.Id == id);
        }
    }
}
