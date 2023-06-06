using Microsoft.EntityFrameworkCore;
using StudentClinic_WebApi.Models;

namespace StudentClinic_WebApi.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitSlot>().HasData(
                new VisitSlot { Id = 1, StartTime = new TimeOnly(09, 00), EndTime = new TimeOnly(09, 30)},
                new VisitSlot { Id = 2, StartTime = new TimeOnly(09, 30), EndTime = new TimeOnly(10, 00)},
                new VisitSlot { Id = 3, StartTime = new TimeOnly(10, 00), EndTime = new TimeOnly(10, 30)},
                new VisitSlot { Id = 4, StartTime = new TimeOnly(10, 30), EndTime = new TimeOnly(11, 00)},
                new VisitSlot { Id = 5, StartTime = new TimeOnly(11, 00), EndTime = new TimeOnly(11, 30)},
                new VisitSlot { Id = 6, StartTime = new TimeOnly(11, 30), EndTime = new TimeOnly(12, 00)},
                new VisitSlot { Id = 7, StartTime = new TimeOnly(12, 00), EndTime = new TimeOnly(12, 30)},
                new VisitSlot { Id = 8, StartTime = new TimeOnly(12, 30), EndTime = new TimeOnly(13, 00)},
                new VisitSlot { Id = 9, StartTime = new TimeOnly(13, 00), EndTime = new TimeOnly(13, 30)},
                new VisitSlot { Id = 10, StartTime = new TimeOnly(13, 30), EndTime = new TimeOnly(14, 00)},
                new VisitSlot { Id = 11, StartTime = new TimeOnly(14, 00), EndTime = new TimeOnly(14, 30)},
                new VisitSlot { Id = 12, StartTime = new TimeOnly(14, 30), EndTime = new TimeOnly(15, 00)},
                new VisitSlot { Id = 13, StartTime = new TimeOnly(15, 00), EndTime = new TimeOnly(15, 30)},
                new VisitSlot { Id = 14, StartTime = new TimeOnly(15, 30), EndTime = new TimeOnly(16, 00)},
                new VisitSlot { Id = 15, StartTime = new TimeOnly(16, 00), EndTime = new TimeOnly(16, 30)},
                new VisitSlot { Id = 16, StartTime = new TimeOnly(16, 30), EndTime = new TimeOnly(17, 00)}
            );

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Visit> Visits => Set<Visit>();
        public DbSet<VisitSlot> VisitSlots => Set<VisitSlot>();
    }
}
