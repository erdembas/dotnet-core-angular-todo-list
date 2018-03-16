using dotnet_backend_src.data.models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend_src.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { optionsBuilder.UseNpgsql("Server=localhost;Database=todo;Password=2468;User ID=postgres;"); }
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(256);
                entity.Property(e => e.Status).IsRequired().HasColumnType("Smallint").HasDefaultValue(TodoStatus.Wait);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("now()");
            });
        }
    }
}