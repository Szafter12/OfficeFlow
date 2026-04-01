using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using OfficeFlow.Enums;
using OfficeFlow.Models;

namespace OfficeFlow.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var office1Hours = new
            {
                Monday = "08:00-18:00",
                Tuesday = "08:00-18:00",
                Wednesday = "08:00-18:00",
                Thursday = "08:00-18:00",
                Friday = "08:00-16:00",
                Saturday = "Closed",
                Sunday = "Closed",
            };

            var office2Hours = new
            {
                Monday = "07:00-20:00",
                Tuesday = "07:00-20:00",
                Wednesday = "07:00-20:00",
                Thursday = "07:00-20:00",
                Friday = "07:00-20:00",
                Saturday = "09:00-15:00",
                Sunday = "Closed",
            };

            modelBuilder
                .Entity<Amenity>()
                .HasData(
                    new Amenity { Id = 1, Name = "Monitor 4K" },
                    new Amenity { Id = 2, Name = "Regulowane biurko" },
                    new Amenity { Id = 3, Name = "Fotel ergonomiczny" }
                );
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        First_name = "Jan",
                        Last_name = "Kowalski",
                        Email = "jan.k@example.com",
                    },
                    new User
                    {
                        Id = 2,
                        First_name = "Anna",
                        Last_name = "Nowak",
                        Email = "a.nowak@example.com",
                    }
                );
            modelBuilder
                .Entity<Office>()
                .HasData(
                    new Office
                    {
                        Id = 1,
                        Name = "Warsaw Spire",
                        OpeningHours = JsonSerializer.Serialize(office1Hours),
                    },
                    new Office
                    {
                        Id = 2,
                        Name = "Cracow Tower",
                        OpeningHours = JsonSerializer.Serialize(office2Hours),
                    }
                );
            modelBuilder
                .Entity<OfficeAddress>()
                .HasData(
                    new OfficeAddress
                    {
                        Id = 1,
                        OfficeId = 1,
                        AddressLine1 = "Plac Europejski 1",
                        City = "Warszawa",
                        Town = "Mazowieckie",
                        PostalCode = "00123",
                    },
                    new OfficeAddress
                    {
                        Id = 2,
                        OfficeId = 2,
                        AddressLine1 = "Pawia 5",
                        City = "Kraków",
                        Town = "Małopolskie",
                        PostalCode = "31154",
                    }
                );
            modelBuilder
                .Entity("AmenityDesk")
                .HasData(
                    new { AmenitiesId = 1, DesksId = 1 },
                    new { AmenitiesId = 2, DesksId = 1 },
                    new { AmenitiesId = 1, DesksId = 2 }
                );
            var desks = new List<Desk>
            {
                new Desk
                {
                    Id = 1,
                    Office_id = 1,
                    Price = 50.00m,
                    Type = DeskType.Desk,
                    Status = DeskStatus.Available,
                },
                new Desk
                {
                    Id = 2,
                    Office_id = 1,
                    Price = 100.00m,
                    Type = DeskType.ConferenceRoom,
                    Status = DeskStatus.Maintenance,
                },
                new Desk
                {
                    Id = 3,
                    Office_id = 2,
                    Price = 60.00m,
                    Type = DeskType.Desk,
                    Status = DeskStatus.Retired,
                },
            };
            for (int i = 4; i <= 50; i++)
            {
                desks.Add(
                    new Desk
                    {
                        Id = i,
                        Office_id = (i % 2) + 1,
                        Price = 40.00m + (i % 10),
                        Type = i % 5 == 0 ? DeskType.ConferenceRoom : DeskType.Desk,
                        Status = DeskStatus.Available,
                    }
                );
            }

            modelBuilder.Entity<Desk>().HasData(desks);

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = 1,
                    User_id = 1,
                    Desk_id = 1,
                    reservationStatus = ReservationStatus.Accepted,
                    Start_date = new DateTime(2026, 05, 20, 10, 0, 0, DateTimeKind.Utc),
                    End_date = new DateTime(2026, 05, 20, 18, 0, 0, DateTimeKind.Utc),
                    Created_at = new DateTime(2026, 03, 31, 12, 0, 0, DateTimeKind.Utc),
                    Updated_at = new DateTime(2026, 03, 31, 12, 0, 0, DateTimeKind.Utc),
                },
            };

            var seedDate = new DateTime(2026, 03, 31, 12, 0, 0, DateTimeKind.Utc);

            var random = new Random(42);
            for (int i = 2; i <= 101; i++)
            {
                var dayOffset = random.Next(1, 30);
                var startHour = random.Next(8, 11);

                reservations.Add(
                    new Reservation
                    {
                        Id = i,
                        User_id = (i % 2) + 1,
                        Desk_id = (i % 48) + 1,
                        reservationStatus = ReservationStatus.Accepted,
                        Start_date = new DateTime(
                            2026,
                            06,
                            01,
                            startHour,
                            0,
                            0,
                            DateTimeKind.Utc
                        ).AddDays(dayOffset),
                        End_date = new DateTime(
                            2026,
                            06,
                            01,
                            startHour + 6,
                            0,
                            0,
                            DateTimeKind.Utc
                        ).AddDays(dayOffset),
                        Created_at = seedDate,
                        Updated_at = seedDate,
                    }
                );
            }

            modelBuilder.Entity<Reservation>().HasData(reservations);
        }
    }
}
