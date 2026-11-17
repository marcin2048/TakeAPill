using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakeAPill.Domain.IntakeSchedules;
using TakeAPill.Infrastructure.Data;

namespace TakeAPill.Infrastructure.Persistence.Configurations;

public sealed class IntakeScheduleConfiguration : IEntityTypeConfiguration<IntakeSchedule>
{
    public void Configure(EntityTypeBuilder<IntakeSchedule> builder)
    {
        builder.ToTable("IntakeSchedules");
        builder.HasKey(schedule => schedule.Id);
        builder.Property(schedule => schedule.UserId)
            .HasMaxLength(450)
            .IsRequired();
        builder.Property(schedule => schedule.IntakeFrequency)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(schedule => schedule.StartDate)
            .IsRequired();
        builder.HasOne(schedule => schedule.Pill)
            .WithMany(pill => pill.IntakeSchedules)
            .HasForeignKey(schedule => schedule.PillId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(schedule => schedule.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(schedule => schedule.UserId);
    }
}

