using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration; 
    }

    public DataContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("DatabaseConnectionString"));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AiUsage> AiUsages { get; set; }
}

