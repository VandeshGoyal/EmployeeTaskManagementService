using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementService.DataAcessLayer
{
    public class EmployeeTaskDbContext : DbContext
    {
        public DbSet<Models.Employee> Employees { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Models.Document> Documents { get; set; }

        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TaskName).IsRequired();
                entity.HasOne(d => d.AssignedEmployee)
                  .WithMany(p => p.AssignedTasks);
            });

            modelBuilder.Entity<Models.Employee>().HasData(new Models.Employee
            {
                Id = 1,
                Name = "Ghost",
                CreatedDate = DateTime.UtcNow,
                TeamName = ""
            });
        }
    }
}
