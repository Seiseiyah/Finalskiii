using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Interface
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetAllAsync();
        Task<Faculty?> GetByIdAsync(int facultyId);
        Task AddAsync(Faculty faculty);
        Task UpdateAsync(Faculty faculty);
        Task DeleteAsync(Faculty faculty);
    }
}
