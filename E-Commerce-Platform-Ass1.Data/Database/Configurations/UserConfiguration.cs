using E_Commerce_Platform_Ass1.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Ass1.Data.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name
            builder.ToTable("users");

            // Primary key
            builder.HasKey(u => u.id);

            // Columns
            builder.Property(u => u.id)
                   .IsRequired();

            builder.Property(u => u.name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.password_hash)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(u => u.email)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(u => u.role_id)
                   .IsRequired();

            builder.Property(u => u.status)
                   .HasDefaultValue(true)
                   .IsRequired();

            // Foreign key relationship
            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.role_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.create_at)
                   .HasDefaultValueSql("GETDATE()")
                   .IsRequired();

            // Indexes
            builder.HasIndex(u => u.email)
                   .IsUnique();


        }
    }
}
