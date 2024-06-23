using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium_2.Config;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.Property(e => e.IdVisit).UseIdentityColumn();

        builder.HasOne(e => e.Patient)
            .WithMany(e => e.Visits)
            .HasForeignKey(e => e.IdPatient)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Visits)
            .HasForeignKey(e => e.IdDoctor)
            .OnDelete(DeleteBehavior.ClientSetNull);

        var list = new List<Visit>();
        list.Add(new Visit()
        {
            IdVisit = 1,
            IdPatient = 1,
            Date = DateTime.Now,
            IdDoctor = 1,
            Price = 300.0
        });
        
        builder.HasData(list);
    }
}