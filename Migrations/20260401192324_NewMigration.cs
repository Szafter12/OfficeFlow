using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfficeFlow.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OpeningHours = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    First_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Office_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desks_Offices_Office_id",
                        column: x => x.Office_id,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressLine1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddressLine2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    OfficeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeAddresses_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenityDesk",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "integer", nullable: false),
                    DesksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityDesk", x => new { x.AmenitiesId, x.DesksId });
                    table.ForeignKey(
                        name: "FK_AmenityDesk_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityDesk_Desks_DesksId",
                        column: x => x.DesksId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Desk_id = table.Column<int>(type: "integer", nullable: false),
                    Start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    DeskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationArchives_Desks_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationArchives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Desk_id = table.Column<int>(type: "integer", nullable: false),
                    Start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reservationStatus = table.Column<int>(type: "integer", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Desks_Desk_id",
                        column: x => x.Desk_id,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monitor 4K" },
                    { 2, "Regulowane biurko" },
                    { 3, "Fotel ergonomiczny" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1, "Warsaw Spire", "{\"Monday\":\"08:00-18:00\",\"Tuesday\":\"08:00-18:00\",\"Wednesday\":\"08:00-18:00\",\"Thursday\":\"08:00-18:00\",\"Friday\":\"08:00-16:00\",\"Saturday\":\"Closed\",\"Sunday\":\"Closed\"}" },
                    { 2, "Cracow Tower", "{\"Monday\":\"07:00-20:00\",\"Tuesday\":\"07:00-20:00\",\"Wednesday\":\"07:00-20:00\",\"Thursday\":\"07:00-20:00\",\"Friday\":\"07:00-20:00\",\"Saturday\":\"09:00-15:00\",\"Sunday\":\"Closed\"}" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "First_name", "Last_name" },
                values: new object[,]
                {
                    { 1, "jan.k@example.com", "Jan", "Kowalski" },
                    { 2, "a.nowak@example.com", "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Desks",
                columns: new[] { "Id", "Office_id", "Price", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, 50.00m, "Available", 0 },
                    { 2, 1, 100.00m, "Maintenance", 1 },
                    { 3, 2, 60.00m, "Retired", 0 },
                    { 4, 1, 44.00m, "Available", 0 },
                    { 5, 2, 45.00m, "Available", 1 },
                    { 6, 1, 46.00m, "Available", 0 },
                    { 7, 2, 47.00m, "Available", 0 },
                    { 8, 1, 48.00m, "Available", 0 },
                    { 9, 2, 49.00m, "Available", 0 },
                    { 10, 1, 40.00m, "Available", 1 },
                    { 11, 2, 41.00m, "Available", 0 },
                    { 12, 1, 42.00m, "Available", 0 },
                    { 13, 2, 43.00m, "Available", 0 },
                    { 14, 1, 44.00m, "Available", 0 },
                    { 15, 2, 45.00m, "Available", 1 },
                    { 16, 1, 46.00m, "Available", 0 },
                    { 17, 2, 47.00m, "Available", 0 },
                    { 18, 1, 48.00m, "Available", 0 },
                    { 19, 2, 49.00m, "Available", 0 },
                    { 20, 1, 40.00m, "Available", 1 },
                    { 21, 2, 41.00m, "Available", 0 },
                    { 22, 1, 42.00m, "Available", 0 },
                    { 23, 2, 43.00m, "Available", 0 },
                    { 24, 1, 44.00m, "Available", 0 },
                    { 25, 2, 45.00m, "Available", 1 },
                    { 26, 1, 46.00m, "Available", 0 },
                    { 27, 2, 47.00m, "Available", 0 },
                    { 28, 1, 48.00m, "Available", 0 },
                    { 29, 2, 49.00m, "Available", 0 },
                    { 30, 1, 40.00m, "Available", 1 },
                    { 31, 2, 41.00m, "Available", 0 },
                    { 32, 1, 42.00m, "Available", 0 },
                    { 33, 2, 43.00m, "Available", 0 },
                    { 34, 1, 44.00m, "Available", 0 },
                    { 35, 2, 45.00m, "Available", 1 },
                    { 36, 1, 46.00m, "Available", 0 },
                    { 37, 2, 47.00m, "Available", 0 },
                    { 38, 1, 48.00m, "Available", 0 },
                    { 39, 2, 49.00m, "Available", 0 },
                    { 40, 1, 40.00m, "Available", 1 },
                    { 41, 2, 41.00m, "Available", 0 },
                    { 42, 1, 42.00m, "Available", 0 },
                    { 43, 2, 43.00m, "Available", 0 },
                    { 44, 1, 44.00m, "Available", 0 },
                    { 45, 2, 45.00m, "Available", 1 },
                    { 46, 1, 46.00m, "Available", 0 },
                    { 47, 2, 47.00m, "Available", 0 },
                    { 48, 1, 48.00m, "Available", 0 },
                    { 49, 2, 49.00m, "Available", 0 },
                    { 50, 1, 40.00m, "Available", 1 }
                });

            migrationBuilder.InsertData(
                table: "OfficeAddresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "OfficeId", "PostalCode", "Town" },
                values: new object[,]
                {
                    { 1, "Plac Europejski 1", "", "Warszawa", 1, "00123", "Mazowieckie" },
                    { 2, "Pawia 5", "", "Kraków", 2, "31154", "Małopolskie" }
                });

            migrationBuilder.InsertData(
                table: "AmenityDesk",
                columns: new[] { "AmenitiesId", "DesksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Created_at", "Desk_id", "End_date", "Start_date", "User_id", "reservationStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 5, 20, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 20, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 2, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2026, 6, 21, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 21, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 3, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2026, 6, 5, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 4, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2026, 6, 6, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 6, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 5, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2026, 6, 23, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 23, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 6, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 7, new DateTime(2026, 6, 7, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 7, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2026, 6, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 8, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 9, new DateTime(2026, 6, 16, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 16, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 9, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 10, new DateTime(2026, 6, 13, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 13, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 10, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 11, new DateTime(2026, 6, 17, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 17, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 11, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 12, new DateTime(2026, 6, 25, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 25, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 12, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 13, new DateTime(2026, 6, 13, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 13, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 13, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 14, new DateTime(2026, 6, 4, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 4, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 14, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 15, new DateTime(2026, 6, 25, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 25, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 15, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 16, new DateTime(2026, 6, 3, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 16, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 17, new DateTime(2026, 6, 6, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 6, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 17, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 18, new DateTime(2026, 6, 22, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 18, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 19, new DateTime(2026, 6, 7, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 19, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 20, new DateTime(2026, 6, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 20, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 21, new DateTime(2026, 6, 25, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 25, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 21, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 22, new DateTime(2026, 6, 17, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 17, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 22, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 23, new DateTime(2026, 6, 23, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 23, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 23, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 24, new DateTime(2026, 6, 6, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 6, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 24, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 25, new DateTime(2026, 6, 3, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 25, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 26, new DateTime(2026, 6, 20, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 20, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 26, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 27, new DateTime(2026, 6, 9, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 9, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 27, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 28, new DateTime(2026, 6, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 28, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 29, new DateTime(2026, 6, 6, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 6, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 29, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 30, new DateTime(2026, 6, 19, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 30, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 31, new DateTime(2026, 6, 3, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 31, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 32, new DateTime(2026, 6, 22, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 32, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 33, new DateTime(2026, 6, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 33, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 34, new DateTime(2026, 6, 12, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 34, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 35, new DateTime(2026, 6, 3, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 35, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 36, new DateTime(2026, 6, 4, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 4, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 36, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 37, new DateTime(2026, 6, 2, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 37, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 38, new DateTime(2026, 6, 14, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 14, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 38, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 39, new DateTime(2026, 6, 16, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 16, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 39, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 40, new DateTime(2026, 6, 26, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 26, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 40, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 41, new DateTime(2026, 6, 2, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 41, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 42, new DateTime(2026, 6, 20, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 20, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 42, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 43, new DateTime(2026, 6, 28, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 28, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 43, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 44, new DateTime(2026, 6, 15, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 44, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 45, new DateTime(2026, 6, 19, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 45, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 46, new DateTime(2026, 6, 12, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 46, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 47, new DateTime(2026, 6, 14, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 14, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 47, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 48, new DateTime(2026, 6, 17, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 17, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 48, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 6, 10, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 49, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2026, 6, 19, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 50, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2026, 6, 2, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 51, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2026, 6, 29, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 29, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 52, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2026, 6, 22, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 53, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2026, 6, 4, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 4, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 54, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 7, new DateTime(2026, 6, 11, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 11, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 55, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 8, new DateTime(2026, 6, 6, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 6, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 56, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 9, new DateTime(2026, 6, 8, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 57, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 10, new DateTime(2026, 6, 16, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 16, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 58, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 11, new DateTime(2026, 6, 24, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 24, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 59, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 12, new DateTime(2026, 6, 22, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 60, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 13, new DateTime(2026, 6, 18, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 18, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 61, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 14, new DateTime(2026, 6, 20, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 20, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 62, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 15, new DateTime(2026, 6, 12, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 63, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 16, new DateTime(2026, 6, 2, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 64, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 17, new DateTime(2026, 6, 9, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 9, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 65, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 18, new DateTime(2026, 6, 8, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 66, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 19, new DateTime(2026, 6, 14, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 14, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 67, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 20, new DateTime(2026, 6, 30, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 30, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 68, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 21, new DateTime(2026, 6, 5, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 69, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 22, new DateTime(2026, 6, 11, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 11, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 70, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 23, new DateTime(2026, 6, 25, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 25, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 71, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 24, new DateTime(2026, 6, 3, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 72, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 25, new DateTime(2026, 6, 27, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 27, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 73, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 26, new DateTime(2026, 6, 28, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 28, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 74, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 27, new DateTime(2026, 6, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 75, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 28, new DateTime(2026, 6, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 20, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 76, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 29, new DateTime(2026, 6, 7, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 77, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 30, new DateTime(2026, 6, 7, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 78, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 31, new DateTime(2026, 6, 8, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 8, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 79, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 32, new DateTime(2026, 6, 30, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 30, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 80, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 33, new DateTime(2026, 6, 5, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 81, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 34, new DateTime(2026, 6, 7, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 7, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 82, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 35, new DateTime(2026, 6, 18, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 18, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 83, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 36, new DateTime(2026, 6, 22, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 22, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 84, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 37, new DateTime(2026, 6, 19, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 85, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 38, new DateTime(2026, 6, 27, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 27, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 86, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 39, new DateTime(2026, 6, 12, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 12, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 87, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 40, new DateTime(2026, 6, 15, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 88, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 41, new DateTime(2026, 6, 29, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 29, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 89, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 42, new DateTime(2026, 6, 5, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 5, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 90, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 43, new DateTime(2026, 6, 2, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 2, 8, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 91, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 44, new DateTime(2026, 6, 29, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 29, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 92, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 45, new DateTime(2026, 6, 13, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 13, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 93, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 46, new DateTime(2026, 6, 13, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 13, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 94, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 47, new DateTime(2026, 6, 28, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 28, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 95, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 48, new DateTime(2026, 6, 27, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 27, 8, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 96, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 6, 11, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 11, 9, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 97, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2026, 6, 19, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 19, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 98, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2026, 6, 25, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 25, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 99, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2026, 6, 10, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 10, 9, 0, 0, 0, DateTimeKind.Utc), 2, 0 },
                    { 100, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 5, new DateTime(2026, 6, 17, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 17, 10, 0, 0, 0, DateTimeKind.Utc), 1, 0 },
                    { 101, new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2026, 6, 9, 16, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 6, 9, 10, 0, 0, 0, DateTimeKind.Utc), 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenityDesk_DesksId",
                table: "AmenityDesk",
                column: "DesksId");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_Office_id",
                table: "Desks",
                column: "Office_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAddresses_OfficeId",
                table: "OfficeAddresses",
                column: "OfficeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationArchives_DeskId",
                table: "ReservationArchives",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationArchives_UserId",
                table: "ReservationArchives",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Desk_id",
                table: "Reservations",
                column: "Desk_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_id",
                table: "Reservations",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityDesk");

            migrationBuilder.DropTable(
                name: "OfficeAddresses");

            migrationBuilder.DropTable(
                name: "ReservationArchives");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
