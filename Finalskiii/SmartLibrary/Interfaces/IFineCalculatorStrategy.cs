using System;
using Finalskiii.Finalskiii.Models;
using SmartsLibrary.Core.Models;

namespace Finalskiii.Finalskiii.Interfaces
{
    public interface IFineCalculatorStrategy
    {
        decimal CalculateFine(Loan loan, DateTime now);
    }
}
