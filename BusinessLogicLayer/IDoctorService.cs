using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer
{
    public interface IDoctorService
    {
        Task<List<DoctorDTOForGet>> GetDoctorsAsync();
        Task<DoctorDTOForGet> GetDoctorByIdAsync(string id);
        Task<Doctor> AddDoctorAsync(DoctorDTOForPost doctor);
        Task<Doctor> UpdateDoctorAsync(DoctorDTO doctor);
        Task<Doctor> DeleteDoctorAsync(string id);
    }
}
