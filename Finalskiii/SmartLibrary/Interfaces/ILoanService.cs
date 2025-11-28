using Finalskiii.Finalskiii.Models;
using SmartsLibrary.Core.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface ILoanService
    {
        Task<Loan> BorrowAsync(int userId, int bookId);
        Task<Loan> ReturnAsync(int loanId);
    }
}
