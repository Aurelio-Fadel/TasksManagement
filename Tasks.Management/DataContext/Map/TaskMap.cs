using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.DataContext.Maps
{
    internal class TaskMap : IEntityTypeConfiguration<AssignedTask>
    {
        public void Configure(EntityTypeBuilder<AssignedTask> builder)
        {
            builder.ToTable("Data", "Task");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Person)
                   .WithMany(x => x.Tasks)
                   .HasForeignKey(x => x.PersonId);
        }
    }
}
