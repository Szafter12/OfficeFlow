using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeFlow.Models;

namespace OfficeFlow.Data.Configurations
{
    public class OfficeAddressConfiguration : IEntityTypeConfiguration<OfficeAddress>
    {
        public void Configure(EntityTypeBuilder<OfficeAddress> builder)
        {
            builder.Property(oa => oa.AddressLine1).IsRequired().HasMaxLength(50);
            builder.Property(oa => oa.AddressLine2).IsRequired().HasMaxLength(50);
            builder.Property(oa => oa.City).IsRequired().HasMaxLength(50);
            builder.Property(oa => oa.Town).IsRequired().HasMaxLength(50);
            builder.Property(oa => oa.PostalCode).IsRequired().HasMaxLength(10);
            builder.HasIndex(oa => oa.OfficeId).IsUnique();

            builder
                .HasOne(oa => oa.Office)
                .WithOne(o => o.Address)
                .HasForeignKey<OfficeAddress>(oa => oa.OfficeId);
        }
    }
}
