using System.Collections.Generic;
using System.Threading.Tasks;
using Finalskiii.Finalskiii.Models;
using SmartsLibrary.Core.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId);
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task<IEnumerable<Loan>> GetOverdueLoansAsync();
        Task CreateFineForLoanAsync(int loanId, decimal amount);
    }
}
