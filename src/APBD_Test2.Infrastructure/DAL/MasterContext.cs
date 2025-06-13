using System.Diagnostics;
using System.Numerics;
using APBD_Test2.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task = APBD_Test2.Infrastructure.Model.Task;

namespace APBD_Test2.Infrastructure.DAL;

public class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {
    }

    public DbSet<Task> Task { get; set; }
    
    public DbSet<Language> Language { get; set; }
    
    public DbSet<Student> Student { get; set; }
    
    public DbSet<Record> Record { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            entity.Property(t => t.Description)
                .IsRequired(true)
                .HasMaxLength(2000);
            entity.HasMany<Record>(t => t.Records)
                .WithOne(r => r.Task)
                .HasForeignKey(r => r.TaskId);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            entity.HasMany<Record>(t => t.Records)
                .WithOne(r => r.Language)
                .HasForeignKey(r => r.LanguageId);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            var bigIntegerConverter = new ValueConverter<BigInteger, string>(
                v => v.ToString(),
                v => BigInteger.Parse(v)
            );

            entity.ToTable("Record");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.ExecutionTime)
                .HasConversion(bigIntegerConverter)
                .IsRequired(true);
            entity.Property(x => x.CreatedAt)
                .IsRequired(true);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(100);
            entity.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(100);
            entity.Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(250);
            entity.HasMany<Record>(e => e.Records)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId);
        });
    }

}