﻿namespace DataService;

using FomulaOneApi.Entities;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    // Define the entities
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievement> Achievements { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        base.OnModelCreating (modelBuilder);

        // Define the relationship between entities
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne(d => d.Driver)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Driver");
        });
    }
}
