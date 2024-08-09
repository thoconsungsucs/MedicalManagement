using BusinessLogicLayer.IService;
using DataAccessLayer;
using DataAccessLayer.DTOs.Account;
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
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, IDoctorService doctorService, ITokenService tokenService, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _doctorService = doctorService;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register-doctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorRegistationDTO doctorDTO)
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
                return Ok(new NewAccount
                {
                    Username = doctor.UserName,
                    Email = doctor.Email,
                    Token = _tokenService.GenerateToken(doctor.Email)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(new NewAccount
            {
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.GenerateToken(loginDTO.Email)
            });
        }
    }
}
