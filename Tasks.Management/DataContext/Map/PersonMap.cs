using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Management.Entities;

namespace TaskManagement.Management.DataContext.Maps
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Data", "Person");
            builder.HasKey(x => x.Id);
        }
    }
}
