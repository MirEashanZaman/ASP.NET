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

    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}