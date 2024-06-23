using Kolokwium_2.Config;
using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Repository;

public class Context : DbContext
{
    public Context() {}
    
    public Context(DbContextOptions<Context> options) : base(options) {}
    
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Visit> Visits { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new VisitConfiguration());
    }
}