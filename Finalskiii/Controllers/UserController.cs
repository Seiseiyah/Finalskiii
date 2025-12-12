using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.DTOs;
using Finalskiii.Finalskiii.Enums;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Models;
using Finalskiii.Finalskiii.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

    //localhost:xxx/api/User
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            if (!users.Any()) return NotFound("No User Registered");

            return Ok(users);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userRepository.GetAllAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    [HttpPost("/Register")]
    public async Task<IActionResult> Register(AddUserDTOs addUser)
    {
        string role;

        if (addUser.Email.EndsWith("@faculty.school.edu"))
        {
            role = "Faculty";
        }
        else if (addUser.Email.EndsWith("@student.school.edu"))
        {
            role = "Student";
        }
        else if (addUser.Email.Contains("admin"))
        {
            role = "Admin";
        }
        else
        {
            // Default fallback role
            role = "Guest";
        }

        var user = new User
        {
            FullName = addUser.FullName,
            Username = addUser.Username,
            Email = addUser.Email,
            Password = addUser.Password,
            Role = role
        };

        await _userRepository.AddAsync(user);
        var payload = new GetUserDTO
        {
            Fullname = user.FullName,
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };

        return Ok(payload);
    }

    [HttpPut]
        public async Task<IActionResult> UpdateUser(int Id, UpdateUserDTO updateUser)
        {
            var user = await _userRepository.GetByIdAsync(Id);
            if (user == null)
           
            user.Username = updateUser.Username;
            await _userRepository.UpdateAsync(user);

            return Ok(user);
        }

        [HttpDelete ("{Id: int}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _userRepository.GetByIdAsync(Id);
            if (user is null)

                await _userRepository.DeleteAsync(user);
            return Ok($"User With Id {Id} deleted");
        }

    }
