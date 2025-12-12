using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.DTOs;
using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<IEnumerable<GetUserInformationStudent>> GetAllWithUserAsync();
    }
}
