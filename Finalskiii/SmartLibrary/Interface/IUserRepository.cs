using Finalskiii.Finalskiii.Models;
using System.Collections.Generic;


namespace Finalskiii.Finalskiii.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);

        Task<User?>GetByEmailOrUsernameAsync( string emailorUsername);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
