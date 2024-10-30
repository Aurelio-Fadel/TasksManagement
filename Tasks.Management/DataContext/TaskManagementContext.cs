using Microsoft.EntityFrameworkCore;
using TaskManagement.Management.DataContext.Maps;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.DataContext
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }



        public DbSet<AssignedTask> Tasks { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedTask>().ToTable("AssignedTasks");
            modelBuilder.Entity<Person>().ToTable("Persons");

            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
    }
}
