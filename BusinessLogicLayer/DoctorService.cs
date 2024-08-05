using DataAccessLayer.Data;
using DataAccessLayer.Entities;
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

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
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

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            var doctorToUpdate = await _context.Doctors.FindAsync(doctor.Id);
            if (doctorToUpdate == null) return null;

            doctorToUpdate.FirstName = doctor.FirstName;
            doctorToUpdate.LastName = doctor.LastName;
            doctorToUpdate.Specialty = doctor.Specialty;
            doctorToUpdate.Address = doctor.Address;
            doctorToUpdate.Email = doctor.Email;
            doctorToUpdate.PhoneNumber = doctor.PhoneNumber;

            await _context.SaveChangesAsync();
            return doctorToUpdate;
        }
    }
}
