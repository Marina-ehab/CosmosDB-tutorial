using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data;

public class UniversityContext : DbContext
{
    public DbSet<Student>? Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //configuring console application
        optionsBuilder.UseCosmos(
            "Account URL", //replace this with account url
            "Account Key", //replace this with primary key
            "university"); //replace this with database name
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //mapping entities to database
        // configuring Students
        modelBuilder.Entity<Student>()
                .ToContainer("students") // ToContainer
                .HasPartitionKey(e => e.Id); // Partition Key
    
    }
}
