using System;
using System.Collections.Generic;
using FirstMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Data;

public partial class FirstMvcContext : DbContext
{
    public FirstMvcContext()
    {
    }

    public FirstMvcContext(DbContextOptions<FirstMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Major> Majors { get; set; }
    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=FirstMVCContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Major>(entity =>
        {
            entity.ToTable("Major");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.TotalCredit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalTuitionFee).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
