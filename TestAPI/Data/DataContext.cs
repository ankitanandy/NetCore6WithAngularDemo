using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    public DbSet<Employee> Employees {get;set;}

    public DbSet<Department> Departments {get;set;}
}