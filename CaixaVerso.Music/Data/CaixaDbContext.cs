using Microsoft.EntityFrameworkCore;

namespace CaixaVerso.MusicApp.Data
{
    public class CaixaDbContext : DbContext
    {
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Music> Musics => Set<Music>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = Path.Combine(localAppData, "Caixa.db");


            optionsBuilder.UseSqlite($"Data Source={dbPath}")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasIndex(artist => artist.Name).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
