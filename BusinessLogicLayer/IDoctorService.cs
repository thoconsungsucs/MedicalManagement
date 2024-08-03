using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task<Doctor> DeleteDoctorAsync(int id);
    }
}
