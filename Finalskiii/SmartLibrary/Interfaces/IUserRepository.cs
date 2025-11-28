using System.Threading.Tasks;
using Finalskiii.Finalskiii.Models;
using SmartsLibrary.Core.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
    }
}
