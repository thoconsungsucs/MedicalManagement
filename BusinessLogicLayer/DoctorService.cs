using DataAccessLayer.Data;
using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogicLayer
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> AddDoctorAsync(DoctorDTOForPost doctorDTO)
        {
            var doctor = doctorDTO.ToDoctor();
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> DeleteDoctorAsync(string id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return null;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<DoctorDTOForGet> GetDoctorByIdAsync(string id)
        {
            return await _context.Doctors
                .Where(d => d.Id == id)
                .Select(d => new DoctorDTOForGet
                {
                    DoctorId = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Specialty = d.Specialty,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber
                }).FirstOrDefaultAsync();
        }

        public async Task<List<DoctorDTOForGet>> GetDoctorsAsync()
        {
            return await _context.Doctors.Select(d => new DoctorDTOForGet
            {
                DoctorId = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Specialty = d.Specialty,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber
            }).ToListAsync();
        }

        public async Task<Doctor> UpdateDoctorAsync(DoctorDTO doctorDTO)
        {
            var doctorToUpdate = await _context.Doctors.FindAsync(doctorDTO.DoctorId);
            if (doctorToUpdate == null) return null;

            doctorToUpdate.FirstName = doctorDTO.FirstName;
            doctorToUpdate.LastName = doctorDTO.LastName;
            doctorToUpdate.Specialty = doctorDTO.Specialty;
            doctorToUpdate.PhoneNumber = doctorDTO.Phone;
            doctorToUpdate.Address = doctorDTO.Address;
            doctorToUpdate.Email = doctorDTO.Email;
            doctorToUpdate.PhoneNumber = doctorDTO.PhoneNumber;

            await _context.SaveChangesAsync();
            return doctorToUpdate;
        }
    }
}
