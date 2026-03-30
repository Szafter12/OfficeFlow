using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeFlow.Models;

namespace OfficeFlow.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(r => r.Start_date).IsRequired();
            builder.Property(r => r.End_date).IsRequired();
            builder
                .Property(r => r.Created_at)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();

            builder
                .Property(r => r.Updated_at)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.User_id)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(r => r.Desk)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.Desk_id)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
