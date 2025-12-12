using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface ILoanRepository 
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsyncLoan(int loanId);
        Task<User?> GetByIdAsyncUser(int userid);
        Task<Faculty?> GetByIdAsyncFaculty(int facultyid);
        Task<Faculty?> GetFacultyByRole(int userid);
        Task UpdateBorrowedBookisBorrowed(List<int> bookId);
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(Loan loan);
    }
}
