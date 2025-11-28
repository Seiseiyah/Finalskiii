using System;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;

namespace Finalskiii.Finalskiii.Services
{
    public class FineCalculator : IFineCalculatorStrategy
    {
        private readonly decimal _dailyRate;

        public FineCalculator(decimal dailyRate = 1m)
        {
            _dailyRate = dailyRate;
        }

        public decimal CalculateFine(Loan loan, DateTime now)
        {
            var returnDate = loan.ReturnDate ?? now;
            int overdueDays = (returnDate.Date - loan.DueDate.Date).Days;
            return overdueDays > 0 ? overdueDays * _dailyRate : 0;
        }
    }
}
