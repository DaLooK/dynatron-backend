using Microsoft.EntityFrameworkCore;

namespace interview_backend;

public class CustomersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public string DbPath { get; }

    public CustomersContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "customers.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Customer && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var now = DateTime.Now;
            if (entityEntry.State == EntityState.Added)
            {
                ((Customer)entityEntry.Entity).CreatedAt = now;
            }

            ((Customer)entityEntry.Entity).UpdatedAt = now;
        }

        return base.SaveChanges();
    }
}

public class Customer()
{
    public Customer(CustomerDto customerDto) : this()
    {
        FirstName = customerDto.FirstName;
        LastName = customerDto.LastName;
        Email = customerDto.Email;
    }

    public void update(CustomerDto customerDto)
    {
        FirstName = customerDto.FirstName;
        LastName = customerDto.LastName;
        Email = customerDto.Email;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CustomerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}