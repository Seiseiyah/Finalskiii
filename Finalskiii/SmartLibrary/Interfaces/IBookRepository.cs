using System.Collections.Generic;
using System.Threading.Tasks;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Enums;
using SmartsLibrary.Core.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
        Task<IEnumerable<Book>> SearchAsync(string? title, string? author, BookStatus? status);
    }
}
