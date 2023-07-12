using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineTest.Data;

public partial class DummyContext : DbContext
{
    public DummyContext()
    {
    }

    public DummyContext(DbContextOptions<DummyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=CBPC-BATHAM\\SQLEXPRESS;Initial Catalog=Dummy;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}