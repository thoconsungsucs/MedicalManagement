using BusinessLogicLayer;
using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTOForGet>>> GetAll()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            return Ok(doctors.Select(d => d.ToDoctorDTOForGet()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor.ToDoctorDTOForGet());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDTOForPost doctor)
        {
            var doctorModel = doctor.ToDoctor();
            await _doctorService.AddDoctorAsync(doctorModel);
            return CreatedAtAction(nameof(GetById), new { id = doctorModel.DoctorId }, doctorModel.ToDoctorDTOForGet());
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Doctor doctor)
        {
            var doctorUpdated = await _doctorService.UpdateDoctorAsync(doctor);

            if (doctorUpdated == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.DeleteDoctorAsync(id);
            if (doctor == null) return NotFound();
            return NoContent();
        }
    }
}
