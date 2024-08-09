using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.IService
{
    public interface IDoctorService
    {
        Task<List<DoctorDTOForGet>> GetDoctorsAsync();
        Task<DoctorDTOForGet> GetDoctorByIdAsync(string id);
        /*        Task<Doctor> AddDoctorAsync(DoctorDTOForPost doctor);*/
        Task<Doctor> UpdateDoctorAsync(string id, DoctorDTO doctor);
        Task<Doctor> DeleteDoctorAsync(string id);
    }
}
