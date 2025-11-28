using System.Runtime.InteropServices;
using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Repositories;
using Finalskiii.SmartLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Finalskiii.Controllers
{
    //localhost:xxx/api/User
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryDbContext dbContext;
        public UserController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new Users
            {
                Id = addUserDto.Id,
                Fullname = addUserDto.FullName,
                Email = addUserDto.Email,
                UserType = addUserDto.UserType
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpPut]
        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Id = updateUserDto.Id;
            user.FullName = updateUserDto.FullName;
            user.Email = updateUserDto.Email;
            user.UserType = updateUserDto.UserType;

            dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return Ok(user);
        }

    }
}