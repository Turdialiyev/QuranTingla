using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurahSender.Entities;

public class QuranConfiguration : IEntityTypeConfiguration<Quran>
{
    public void Configure(EntityTypeBuilder<Quran> builder)
    {
        builder.HasIndex(q => q.MessageId).IsUnique();
        builder.Property(q => q.Name).IsRequired();
        builder.Property(q => q.Size);
    }
}