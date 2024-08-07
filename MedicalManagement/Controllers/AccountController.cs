using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace MedicalManagement.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDoctorService _doctorService;

        public AccountController(UserManager<ApplicationUser> userManager, IDoctorService doctorService)
        {
            _userManager = userManager;
            _doctorService = doctorService;
        }

        [HttpPost("register-doctor")]
        public async Task<IActionResult> Post([FromBody] DoctorDTOForPost doctorDTO)
        {
            var doctor = doctorDTO.ToDoctor();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userResult = await _userManager.CreateAsync(doctor, doctorDTO.Password);
                if (!userResult.Succeeded)
                {
                    return BadRequest(userResult.Errors);
                }

                var roleResult = await _userManager.AddToRoleAsync(doctor, SD.DoctorUser);
                if (!roleResult.Succeeded)
                {
                    return BadRequest(roleResult.Errors);
                }
                return Ok("Doctor created successfully");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
