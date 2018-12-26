using cqrssssinside.domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace cqrssssinside.domain.infrastructure.Data
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }

    public static class StoreDBContextSeedDataExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "IT", Description = "IT employees" },
            new Department { Id = 2, Name = "Marketing", Description = "Marketing employees", },
            new Department { Id = 3, Name = "Business Management", Description = "Management consultants", });
        }
    }
}
