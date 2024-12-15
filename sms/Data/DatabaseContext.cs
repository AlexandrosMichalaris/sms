using Microsoft.EntityFrameworkCore;
using sms.Models.Database;

namespace sms.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Message> Message { get; set; }

    public readonly IConfiguration _configuration;

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Message> MessageRequest { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message");
            entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(e => e.Vendor).HasColumnName("vendor");
            entity.Property(e => e.MessageContent)
                                .IsRequired()
                                .HasColumnName("message");
        });
    }
}