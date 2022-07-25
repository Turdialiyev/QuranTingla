
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SurahSender.Entities;

public class UserConfiguratin : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.UserId).IsUnique();
        builder.Property(u => u.FirstName);
        builder.Property(u => u.LastName);
        builder.Property(u => u.UserNmae);
        builder.Property(u => u.DateTime);
    }
}