using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Data;

namespace Finalskiii.Finalskiii.Repositories
{
    public class BookRepository 
    {
        private readonly LibraryDbContext _ctx;
        public BookRepository(LibraryDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Book book)
        {
            _ctx.Books.Add(book);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _ctx.Books.FindAsync(id);
            if (book != null)
            {
                _ctx.Books.Remove(book);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _ctx.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _ctx.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            _ctx.Books.Update(book);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> SearchAsync(string? title, string? author, BookStatus? status)
        {
            var q = _ctx.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
                q = q.Where(b => EF.Functions.Like(b.Title, $"%{title}%"));

            if (!string.IsNullOrWhiteSpace(author))
                q = q.Where(b => EF.Functions.Like(b.Author, $"%{author}%"));

            if (status.HasValue)
                q = q.Where(b => b.Status == status.Value);

            return await q.AsNoTracking().ToListAsync();
        }
    }
}
