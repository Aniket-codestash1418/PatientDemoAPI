using Microsoft.EntityFrameworkCore;
using PatientDemoAPI.Entities;

namespace PatientDemoAPI.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> PatientDetails { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }

    }
}
