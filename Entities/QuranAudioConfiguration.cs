using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurahSender.Entities;

public class QuranAudioConfiguration : IEntityTypeConfiguration<QuranAudio>
{
    public void Configure(EntityTypeBuilder<QuranAudio> builder)
    {
        builder.HasIndex(q => q.Name).IsUnique();
        builder.Property(q => q.MessageId);
    }
}