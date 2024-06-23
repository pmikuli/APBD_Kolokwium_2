using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium_2.Config;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.Property(e => e.IdSchedule).UseIdentityColumn();

        builder.HasOne(e => e.Doctor)
            .WithMany(e => e.Schedules)
            .HasForeignKey(e => e.IdDoctor)
            .OnDelete(DeleteBehavior.ClientSetNull);

        var list = new List<Schedule>();
        list.Add(new Schedule()
        {
            IdSchedule = 1,
            IdDoctor = 1,
            DateFrom = DateTime.Today,
            DateTo = DateTime.Now
        });

        builder.HasData(list);
    }
}