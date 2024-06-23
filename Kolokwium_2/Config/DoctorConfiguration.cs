using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium_2.Config;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(e => e.IdDoctor).UseIdentityColumn();

        builder.HasMany(e => e.Visits)
            .WithOne(e => e.Doctor)
            .OnDelete(DeleteBehavior.ClientSetNull);

        var list = new List<Doctor>();
        list.Add(new Doctor()
        {
            IdDoctor = 1,
            FirstName = "Adam",
            LastName = "Kowalski",
            PriceForVisit = 300,
            Specialization = "Surgeon"
        });

        builder.HasData(list);
    }
}