using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedmonie.Model.Entity;

namespace Pedmonie.Migrationn;
public class ApplicationDbContext : DbContext
{
    // Constructor used by DI (when configured in Program.cs)
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Parameterless constructor for design time (migrations)
    public ApplicationDbContext()
    {
    }

    // Define your DbSets here
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    // Override OnConfiguring to set up the MySQL provider if not configured
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Wallet>().ToTable("Wallets");
        modelBuilder.Entity<Transaction>().ToTable("Transactions");
    }

}

