using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeFlow.Models;

namespace OfficeFlow.Data.Configurations
{
    public class DeskConfiguration : IEntityTypeConfiguration<Desk>
    {
        public void Configure(EntityTypeBuilder<Desk> builder)
        {
            builder.Property(d => d.Status).HasConversion<String>().IsRequired();
            builder.Property(d => d.Price).HasPrecision(10, 2).IsRequired();
            builder.Property(d => d.Status).HasConversion<String>().IsRequired();

            builder
                .HasOne(d => d.Office)
                .WithMany(o => o.Desks)
                .HasForeignKey(d => d.Office_id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.Amenities).WithMany(a => a.Desks);
        }
    }
}
