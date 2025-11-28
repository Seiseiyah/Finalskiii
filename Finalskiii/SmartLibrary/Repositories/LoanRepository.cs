using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Data;

namespace Finalskiii.Finalskiii.Repositories
{
    public class LoanRepository 
    {
        private readonly LibraryDbContext _ctx;
        public LoanRepository(LibraryDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Loan loan)
        {
            _ctx.Loans.Add(loan);
            await _ctx.SaveChangesAsync();
        }

        public async Task CreateFineForLoanAsync(int loanId, decimal amount)
        {
            var fine = new Fine { LoanId = loanId, Amount = amount, Paid = false };
            _ctx.Fines.Add(fine);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _ctx.Loans.FindAsync(id);
        }

        public async Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId)
        {
            return await _ctx.Loans.Where(l => l.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetOverdueLoansAsync()
        {
            var now = DateTime.UtcNow;
            return await _ctx.Loans.Where(l => !l.IsReturned && l.DueDate < now).ToListAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _ctx.Loans.Update(loan);
            await _ctx.SaveChangesAsync();
        }
    }
}
