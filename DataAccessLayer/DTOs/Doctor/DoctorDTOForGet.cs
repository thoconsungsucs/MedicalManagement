namespace DataAccessLayer.DTOs.Doctor
{
    public class DoctorDTOForGet
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
