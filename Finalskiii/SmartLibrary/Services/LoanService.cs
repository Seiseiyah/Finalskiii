using System;
using System.Linq;
using System.Threading.Tasks;
using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Services
{
    public class LoanService : ILoanService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUserRepository _userRepo;
        private readonly ILoanRepository _loanRepo;
        private readonly IFineCalculatorStrategy _fineCalculator;

        public LoanService(
            IBookRepository bookRepo,
            IUserRepository userRepo,
            ILoanRepository loanRepo,
            IFineCalculatorStrategy fineCalculator)
        {
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _loanRepo = loanRepo;
            _fineCalculator = fineCalculator;
        }

        public async Task<Loan> BorrowAsync(int userId, int bookId)
        {
            var user = await _userRepo.GetByIdAsync(userId)
                ?? throw new Exception("User not found.");

            var book = await _bookRepo.GetByIdAsync(bookId)
                ?? throw new Exception("Book not found.");

            if (book.Status != BookStatus.Available)
                throw new Exception("Book is not available.");

            var userLoans = await _loanRepo.GetLoansByUserAsync(userId);
            if (userLoans.Count(l => !l.IsReturned) >= user.GetBorrowLimit())
                throw new Exception("User exceeded borrow limit.");

            var loan = new Loan
            {
                BookId = bookId,
                UserId = userId,
                BorrowDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(user.GetLoanDays())
            };

            await _loanRepo.AddAsync(loan);

            book.Status = BookStatus.Borrowed;
            await _bookRepo.UpdateAsync(book);

            return loan;
        }

        public async Task<Loan> ReturnAsync(int loanId)
        {
            var loan = await _loanRepo.GetByIdAsync(loanId)
                ?? throw new Exception("Loan not found.");

            if (loan.IsReturned)
                throw new Exception("Loan already returned.");

            loan.ReturnDate = DateTime.UtcNow;
            await _loanRepo.UpdateAsync(loan);

            var book = await _bookRepo.GetByIdAsync(loan.BookId);
            if (book != null)
            {
                book.Status = BookStatus.Available;
                await _bookRepo.UpdateAsync(book);
            }

            var fineAmount = _fineCalculator.CalculateFine(loan, DateTime.UtcNow);

            if (fineAmount > 0)
                await _loanRepo.CreateFineForLoanAsync(loanId, fineAmount);

            return loan;
        }
    }
}
