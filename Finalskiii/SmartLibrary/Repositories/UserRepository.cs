using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.SmartLibrary.Models;
using Finalskiii.Finalskiii.Data;

namespace Finalskiii.Finalskiii.Repositories
{
    public class UserRepository 
    {
        private readonly LibraryDbContext _ctx;
        public UserRepository(LibraryDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Users user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Users?> GetByIdAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }
    }
}
