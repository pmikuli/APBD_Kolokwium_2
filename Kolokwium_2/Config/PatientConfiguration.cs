using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium_2.Config;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(e => e.IdPatient).UseIdentityColumn();

        builder.HasMany(p => p.Visits)
            .WithOne(e => e.Patient)
            .HasForeignKey(v => v.IdPatient)
            .OnDelete(DeleteBehavior.ClientSetNull);

        var list = new List<Patient>();
        list.Add(new Patient()
        {
            IdPatient = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Birthdate = DateTime.Today
        });

        builder.HasData(list);
    }
}