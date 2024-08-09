using BusinessLogicLayer.IService;
using DataAccessLayer.DTOs.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAll()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors);
        }

        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDTOForPost doctorDTO)
        {
            var doctor = await _doctorService.AddDoctorAsync(doctorDTO);
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] DoctorDTO doctorDTO)
        {
            var doctorUpdated = await _doctorService.UpdateDoctorAsync(id, doctorDTO);

            if (doctorUpdated == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var doctor = await _doctorService.DeleteDoctorAsync(id);
            if (doctor == null) return NotFound();
            return NoContent();
        }
    }
}
