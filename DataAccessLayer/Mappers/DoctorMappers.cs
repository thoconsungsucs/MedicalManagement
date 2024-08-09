using DataAccessLayer.DTOs.Account;
using DataAccessLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Mappers;

public static class DoctorMappers
{
    public static DoctorDTOForGet ToDoctorDTOForGet(this Doctor doctor)
    {
        return new DoctorDTOForGet
        {
            DoctorId = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialty = doctor.Specialty,
            Email = doctor.Email,
            PhoneNumber = doctor.PhoneNumber
        };
    }

    public static Doctor ToDoctor(this DoctorRegistationDTO doctorDTOForPost)
    {
        return new Doctor
        {
            FirstName = doctorDTOForPost.FirstName,
            LastName = doctorDTOForPost.LastName,
            Specialty = doctorDTOForPost.Specialty,
            Email = doctorDTOForPost.Email,
            Address = doctorDTOForPost.Address,
            PhoneNumber = doctorDTOForPost.PhoneNumber,
            UserName = doctorDTOForPost.Email
        };
    }

}
