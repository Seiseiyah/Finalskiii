using Finalskiii.Finalskiii.Interface;
using Finalskiii.Finalskiii.Models;
using Microsoft.AspNetCore.Mvc;
using Finalskiii.Finalskiii.DTOs;

[Route("SmartLibrary/[controller]")]
[ApiController]
public class FineController : ControllerBase
{
    private readonly IFineRepository _fineRepository;

    public FineController(IFineRepository fineRepository)
    {
        _fineRepository = fineRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetFines()
    {
        var fines = await _fineRepository.GetAllAsync();
        return (!fines.Any()) ? NotFound("No Fines Registered") : Ok(fines);
    }

    [HttpGet("{fineId:int}")]
    public async Task<IActionResult> GetFine(int fineId)
    {
        var fine = await _fineRepository.GetByIdAsyncFine(fineId);
        return (fine == null) ? NotFound($"#404! Id {fineId} Not Found") : Ok(fine);
    }

    [HttpPost]
    public async Task<IActionResult> AddFine(AddFineDTO addFine)
    {
        var loan = await _fineRepository.GetByIdAsyncLoan(addFine.LoanId);
        if (loan == null)
            return NotFound("No Loan Found");

        var user = await _fineRepository.GetByIdAsyncUser(loan.ClientId);
        if (user == null)
            return NotFound("No User Found");

        string position = (user.Role == "Faculty") ? "FacultyPosition" : "Student";
        if (loan.book_id == null || loan.book_id.Count == 0)
            return NotFound("No Books To Fine Found");

        int bookCount = loan.book_id.Count;

        decimal total_cost = 0M;

        if (user.Role == "Faculty")
        {
            if (position == "Professor")
                total_cost = 20M * bookCount;
            else if (position == "Instructor")
                total_cost = 15M * bookCount;
            else
                total_cost = 10M * bookCount; 
        }
        else if (user.Role == "Student")
        {
            total_cost = 5M * bookCount;
        }
        else
        {
            total_cost = 3M * bookCount;
        }

        var fine = new Fine
        {
            LoanId = addFine.LoanId,
            TotalAmount = total_cost,
            isPaid = addFine.isPaid,
            PaidAt = addFine.PaidAt,
            CreatedBy = "Librarian",
            CreatedAt = DateTime.UtcNow,
            UpdatedBy = "Librarian",
            UpdatedAt = DateTime.UtcNow
        };

        await _fineRepository.AddAsync(fine);
        var response = new GetFineDTO
        {
            FineId = fine.FineId,
            LoanId = fine.LoanId,
            TotalAmount = fine.TotalAmount,
            isPaid = fine.isPaid,
            PaidAt = fine.PaidAt,
            CreatedBy = fine.CreatedBy,
            CreatedAt = fine.CreatedAt,
            UpdatedBy = fine.UpdatedBy,
            UpdatedAt = fine.UpdatedAt
        };

        return Ok(response);
    }


    [HttpPut("{fineId:int}")]
    public async Task<IActionResult> UpdateFine(int fineId, AddFineDTO updateFine)
    {
        var fine = await _fineRepository.GetByIdAsyncFine(fineId);
        if (fine == null) return NotFound($"#404, Id {fineId} Not Found");

        fine.LoanId = updateFine.LoanId;
        fine.isPaid = updateFine.isPaid;
        fine.PaidAt = updateFine.PaidAt;
        fine.CreatedBy = updateFine.CreatedBy;
        fine.CreatedAt = updateFine.CreatedAt;

        await _fineRepository.UpdateAsync(fine);
        return Ok(fine);
    }

    [HttpDelete("{fineId:int}")]
    public async Task<IActionResult> DeleteFine(int fineId)
    {
        var fine = await _fineRepository.GetByIdAsyncFine(fineId);
        if (fine == null) return NotFound($"#404!, Id {fineId} Not Found");

        await _fineRepository.DeleteAsync(fine);
        return Ok($"Fine With Id {fineId} Deleted Successfully.");
    }
}
