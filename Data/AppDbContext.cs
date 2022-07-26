using Microsoft.EntityFrameworkCore;
using SurahSender.Entities;

namespace SurahSender.Data;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<QuranVideo>? QuranVideoes { get; set; }
    public DbSet<QuranAudio>? QuranAudioes { get; set; }
    public DbSet<User>? Users { get; set; }
    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) :
    base(options)
    { }


}