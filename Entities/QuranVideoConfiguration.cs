using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurahSender.Entities;

public class QuranVideoConfiguration : IEntityTypeConfiguration<QuranVideo>
{
    public void Configure(EntityTypeBuilder<QuranVideo> builder)
    {
        builder.HasIndex(q => q.Name).IsUnique();
        builder.HasIndex(q => q.MessageId).IsUnique();
    }
}