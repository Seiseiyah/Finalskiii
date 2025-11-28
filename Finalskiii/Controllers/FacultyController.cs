using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Models;
using Finalskiii.SmartLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finalskiii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;

        public FacultyController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/Faculty
        [HttpGet]
        public IActionResult GetAllFaculty()
        {
            var facultyList = dbContext.Users
                .Where(u => u.UserType == UserType.Faculty)
                .ToList();

            return Ok(facultyList);
        }

        // GET: api/Faculty/{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetFacultyById(Guid id)
        {
            var faculty = dbContext.Users
                .FirstOrDefault(u => u.Id == id && u.UserType == UserType.Faculty);

            if (faculty == null)
                return NotFound();

            return Ok(faculty);
        }

        // POST: api/Faculty
        [HttpPost]
        public IActionResult AddFaculty(AddUserDto dto)
        {
            var faculty = new Users()
            {
                Id = Guid.NewGuid(),
                Fullname = dto.FullName,
                Email = dto.Email,
                UserType = UserType.Faculty
            };

            dbContext.Users.Add(faculty);
            dbContext.SaveChanges();

            return Ok(faculty);
        }

        // PUT: api/Faculty/{id}
        [HttpPut("{id:guid}")]
        public IActionResult UpdateFaculty(Guid id, UpdateUserDto dto)
        {
            var faculty = dbContext.Users
                .FirstOrDefault(u => u.Id == id && u.UserType == UserType.Faculty);

            if (faculty == null)
                return NotFound();

            faculty.FullName = dto.FullName;
            faculty.Email = dto.Email;

            dbContext.SaveChanges();
            return Ok(faculty);
        }

        // DELETE: api/Faculty/{id}
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFaculty(Guid id)
        {
            var faculty = dbContext.Users
                .FirstOrDefault(u => u.Id == id && u.UserType == UserType.Faculty);

            if (faculty == null)
                return NotFound();

            dbContext.Users.Remove(faculty);
            dbContext.SaveChanges();
            return Ok(faculty);
        }
    }
}
