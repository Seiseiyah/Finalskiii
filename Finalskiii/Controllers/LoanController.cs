using Finalskiii.Finalskiii.DTOs;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("SmartLibrary/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanRepository _loanRepository;

    public LoanController(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _loanRepository.GetAllAsync();
        return (!loans.Any()) ? NotFound("No Loans Registered") : Ok(loans);
    }

    [HttpGet("{loanId:int}")]
    public async Task<IActionResult> GetLoan(int loanId)
    {
        var loan = await _loanRepository.GetByIdAsyncLoan(loanId);
        return (loan == null) ? NotFound($"#404! Id {loanId} Not Found") : Ok(loan);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan(AddLoanDTO addLoan)
    {
        if (addLoan.book_id == null || !addLoan.book_id.Any())
            return BadRequest("Cannot Add Loan Without Book To Borrow");

        var user = await _loanRepository.GetByIdAsyncUser(addLoan.ClientId);
        if (user == null)
            return NotFound("No User Found");

        await _loanRepository.UpdateBorrowedBookisBorrowed(addLoan.book_id);

        string faculty;
        if (user.Role == "Faculty")
        {
            var get_faculty = await _loanRepository.GetFacultyByRole(user.Id);
            faculty = get_faculty!.Position.ToString();
        }
        else
        {
            faculty = "Student";
        }

        int get_day = 0;

        if (user.Role == "Faculty")
        {
            if (faculty == "Professor") get_day = 14;
            else if (faculty == "Instructor") get_day = 10;
            else get_day = 7;
        }
        else if (user.Role == "Student")
        {
            get_day = 5;
        }
        else
        {
            get_day = 3;
        }

        DateOnly dueDate = addLoan.DueDate.AddDays(get_day);

        var loan = new Loan
        {
            ClientId = addLoan.ClientId,
            TransactionType = "Borrowed",
            ReservedDate = addLoan.ReservedDate,
            BorrowDate = addLoan.BorrowDate,
            DueDate = dueDate,
            ReturnDate = null,
            book_id = addLoan.book_id,
            TransactionStatus = "Borrowed",
            FineId = addLoan.FineId,
            CreatedBy = "Librarian",
            CreatedAt = DateTime.UtcNow,
            UpdatedBy = "Librarian",
            UpdatedAt = DateTime.UtcNow
        };
        await _loanRepository.AddAsync(loan);

       
        var response = new GetLoanDTO
        {
            LoanId = loan.LoanId,
            ClientId = loan.ClientId,
            TransactionType = loan.TransactionType,
            ReservedDate = loan.ReservedDate,
            BorrowDate = loan.BorrowDate,
            DueDate = loan.DueDate,
            ReturnDate = loan.ReturnDate,
            TransactionStatus = loan.TransactionStatus,
            book_id = loan.book_id,
            FineId = loan.FineId,
            CreatedBy = loan.CreatedBy,
            CreatedAt = loan.CreatedAt,
            UpdatedBy = loan.UpdatedBy,
            UpdatedAt = loan.UpdatedAt
        };

        return Ok(response);
    }


[HttpPut]
    public async Task<IActionResult> UpdateBorrowedBooks(AddFineByLibrarian addfine, int loanId)
    {
        var loan = await _loanRepository.GetByIdAsyncLoan(loanId);
        if (loan == null) return NotFound("No Loan Found");

        loan.ReturnDate = addfine.ReturnDate;
        loan.FineId = addfine.FineId;
        loan.UpdatedAt = DateTime.UtcNow;
        loan.UpdatedBy = "Librarian";

        await _loanRepository.UpdateAsync(loan);
        return Ok(loan);
    } 

    [HttpDelete("{loanId:int}")]
    public async Task<IActionResult> DeleteLoan(int loanId)
    {
        var loan = await _loanRepository.GetByIdAsyncLoan(loanId);
        if (loan == null) return NotFound($"#404!, Id {loanId} Not Found");

        await _loanRepository.DeleteAsync(loan);
        return Ok($"Loan With Id {loanId} Deleted Successfully.");
    }
}
