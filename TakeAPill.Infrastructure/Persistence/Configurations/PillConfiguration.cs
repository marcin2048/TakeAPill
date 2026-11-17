using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakeAPill.Domain.Pills;

namespace TakeAPill.Infrastructure.Persistence.Configurations;

public sealed class PillConfiguration : IEntityTypeConfiguration<Pill>
{
    public void Configure(EntityTypeBuilder<Pill> builder)
    {
        builder.ToTable("Pills");
        builder.HasKey(pill => pill.Id);
        builder.Property(pill => pill.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(
            new { Id = 1, Name = "Aspirin" },
            new { Id = 2, Name = "Ibuprofen" },
            new { Id = 3, Name = "Paracetamol" },
            new { Id = 4, Name = "Vitamin D3" },
            new { Id = 5, Name = "Magnesium" },
            new { Id = 6, Name = "Omeprazole" },
            new { Id = 7, Name = "Loratadine" },
            new { Id = 8, Name = "Melatonin" },
            new { Id = 9, Name = "Iron" },
            new { Id = 10, Name = "Omega-3" });
    }
}

