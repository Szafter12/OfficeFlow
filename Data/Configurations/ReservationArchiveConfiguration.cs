using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeFlow.Models;

namespace OfficeFlow.Data.Configurations
{
    public class ReservationArchiveConfiguration : IEntityTypeConfiguration<ReservationArchive>
    {
        public void Configure(EntityTypeBuilder<ReservationArchive> builder) { }
    }
}
