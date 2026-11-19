using System;
using System.Collections.Generic;
using LabTask_2_51726_.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabTask_2_51726_.Data;

public partial class UniversityDbContext : DbContext
{
    public UniversityDbContext()
    {
    }

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=UniversityDBContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student");

            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(250);
            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
