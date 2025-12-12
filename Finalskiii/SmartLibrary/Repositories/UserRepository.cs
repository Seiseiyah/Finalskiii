using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseLibrary _db;

        public UserRepository(DatabaseLibrary db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.OrderByDescending(d => d.Id).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.Email == emailOrUsername || u.Username == emailOrUsername);
        }

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
