using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedmonie.Model.Entity;
using Pedmonie.Model.Enum;

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
   // public DbSet<Transaction> TTransaction { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    // Override OnConfiguring to set up the MySQL provider if not configured
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transaction>()
        .Property(t => t.Status)
        .HasConversion<EnumToStringConverter<Status>>();
    }

}

