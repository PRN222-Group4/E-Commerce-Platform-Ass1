using E_Commerce_Platform_Ass1.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_Platform_Ass1.Data.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Table name
            builder.ToTable("roles");

            // Primary key
            builder.HasKey(r => r.id);

            // Columns
            builder.Property(r => r.id)
                   .IsRequired();

            builder.Property(r => r.name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(r => r.description)
                   .HasMaxLength(255)
                   .IsRequired(false);

            builder.Property(r => r.create_at)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            // Indexes
            builder.HasIndex(r => r.name)
                   .IsUnique();
        }
    }
}
