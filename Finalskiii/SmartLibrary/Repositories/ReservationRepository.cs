using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Data;

namespace Finalskiii.Finalskiii.Repositories
{
    public class ReservationRepository
    {
        private readonly LibraryDbContext _ctx;
        public ReservationRepository(LibraryDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Reservation reservation)
        {
            _ctx.Reservations.Add(reservation);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByBookIdAsync(int bookId)
        {
            return await _ctx.Reservations.Where(r => r.BookId == bookId && r.IsActive).ToListAsync();
        }

        public async Task CancelAsync(int reservationId)
        {
            var r = await _ctx.Reservations.FindAsync(reservationId);
            if (r != null)
            {
                r.IsActive = false;
                _ctx.Reservations.Update(r);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
