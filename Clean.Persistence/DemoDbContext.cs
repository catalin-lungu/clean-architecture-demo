using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) :  base(options)
        {            
        }

        public DbSet<Domain.Entities.Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoDbContext).Assembly);

            modelBuilder.Entity<Domain.Entities.Student>().HasData(
                new Domain.Entities.Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe@email.com"
                },
                new Domain.Entities.Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane@doe@email.com"
                },
                new Domain.Entities.Student
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@email.com"
                },
                new Domain.Entities.Student
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@email.com"
                },
                new Domain.Entities.Student
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Jones",
                    Email = "john.jones@email.com"
                },
                new Domain.Entities.Student
                {
                    Id = 6,
                    FirstName = "Jane",
                    LastName = "Jones",
                    Email = "jane@jones@email.com"
                });

            modelBuilder.Entity<Domain.Entities.CheckIn>().HasData(
                new Domain.Entities.CheckIn
                {
                    Id = 1,
                    Email = "john@doe@email.com",
                    Major = "Computer Science",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 2,
                    Email = "john@doe@email.com",
                    Major = "Computer Science",
                    CheckInTime = new DateTime(2023, 1, 2, 9, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 3,
                    Email = "jane@doe@email.com",
                    Major = "Computer Science",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 4,
                    Email = "john.smith@email.com",
                    Major = "Accounting",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 5,
                    Email = "jane.smith@email.com",
                    Major = "Finance",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 6,
                    Email = "john.jones@email.com",
                    Major = "General Management",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                },
                new Domain.Entities.CheckIn
                {
                    Id = 7,
                    Email = "jane@jones@email.com",
                    Major = "Business Analytics",
                    CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0)
                });
        }
    }
}