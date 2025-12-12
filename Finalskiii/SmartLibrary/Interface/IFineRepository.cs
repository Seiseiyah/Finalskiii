using Finalskiii.Finalskiii.Models;
namespace Finalskiii.Finalskiii.Interface
{
    public interface IFineRepository
    {
        Task<IEnumerable<Fine>> GetAllAsync();
        Task<User?> GetByIdAsyncUser(int userId);
        Task<Fine?> GetByIdAsyncFine(int fineId);
        Task<Loan?> GetByIdAsyncLoan(int loanId);
        Task AddAsync(Fine fine);
        Task UpdateAsync(Fine fine);
        Task DeleteAsync(Fine fine);
    }
}
