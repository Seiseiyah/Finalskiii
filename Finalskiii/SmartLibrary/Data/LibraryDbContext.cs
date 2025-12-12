using System.Collections.Generic;
using System.Reflection.Emit;
using Finalskiii.Finalskiii.Models;
using Microsoft.EntityFrameworkCore;

namespace Finalskiii.Finalskiii.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Fine> Fines => Set<Fine>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TPH mapping for User (Student/Faculty)
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("UserDiscriminator")
            .HasValue<Student>(nameof(Student))
            .HasValue<Faculty>(nameof(Faculty));

        // Indexes & constraints
        modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique(false);
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(false);

        base.OnModelCreating(modelBuilder);
    }
}
