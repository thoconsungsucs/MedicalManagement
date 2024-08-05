using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<ClinicalSummary> ClinicalSummaries { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            /*modelBuilder.Entity<Doctor>().HasData(
                               new Doctor
                               {
                                   DoctorId = 1,
                                   FirstName = "John",
                                   LastName = "Doe",
                                   Specialty = "General Practitioner",
                                   Address = "123 Main St",
                                   Email = "john@gmail.com",
                                   PhoneNumber = "01234567"
                               });*/
        }
    }
}
