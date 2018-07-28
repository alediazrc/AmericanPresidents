using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EndpointApp.Models
{
    public partial class endpointdatabaseContext : DbContext
    {
        public endpointdatabaseContext()
        {
        }

        public endpointdatabaseContext(DbContextOptions<endpointdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Presidents> Presidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presidents>(entity =>
            {
                entity.HasKey(e => e.President);

                entity.Property(e => e.President)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeathDay)
                    .HasColumnName("Death day")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeathPlace)
                    .HasColumnName("Death place")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
