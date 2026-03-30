using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfficeFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedAddresMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    OpeningHours = table.Column<string>(type: "jsonb", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    First_name = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    Last_name = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    Email = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(
                        type: "numeric(10,2)",
                        precision: 10,
                        scale: 2,
                        nullable: false
                    ),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Office_id = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desks_Offices_Office_id",
                        column: x => x.Office_id,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OfficeAddresses",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    AddressLine1 = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    AddressLine2 = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    City = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    Town = table.Column<string>(
                        type: "character varying(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    PostalCode = table.Column<string>(
                        type: "character varying(10)",
                        maxLength: 10,
                        nullable: false
                    ),
                    OfficeId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeAddresses_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "AmenityDesk",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "integer", nullable: false),
                    DesksId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityDesk", x => new { x.AmenitiesId, x.DesksId });
                    table.ForeignKey(
                        name: "FK_AmenityDesk_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_AmenityDesk_Desks_DesksId",
                        column: x => x.DesksId,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ReservationArchives",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Desk_id = table.Column<int>(type: "integer", nullable: false),
                    Start_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    End_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationArchives_Desks_Desk_id",
                        column: x => x.Desk_id,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull
                    );
                    table.ForeignKey(
                        name: "FK_ReservationArchives_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    Desk_id = table.Column<int>(type: "integer", nullable: false),
                    Start_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    End_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "now()"
                    ),
                    Updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "now()"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Desks_Desk_id",
                        column: x => x.Desk_id,
                        principalTable: "Desks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull
                    );
                    table.ForeignKey(
                        name: "FK_Reservations_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monitor 4K" },
                    { 2, "Regulowane biurko" },
                    { 3, "Fotel ergonomiczny" },
                }
            );

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name", "OpeningHours" },
                values: new object[,]
                {
                    {
                        1,
                        "Warsaw Spire",
                        "{\"Monday\":\"08:00-18:00\",\"Tuesday\":\"08:00-18:00\",\"Wednesday\":\"08:00-18:00\",\"Thursday\":\"08:00-18:00\",\"Friday\":\"08:00-16:00\",\"Saturday\":\"Closed\",\"Sunday\":\"Closed\"}",
                    },
                    {
                        2,
                        "Cracow Tower",
                        "{\"Monday\":\"07:00-20:00\",\"Tuesday\":\"07:00-20:00\",\"Wednesday\":\"07:00-20:00\",\"Thursday\":\"07:00-20:00\",\"Friday\":\"07:00-20:00\",\"Saturday\":\"09:00-15:00\",\"Sunday\":\"Closed\"}",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "First_name", "Last_name" },
                values: new object[,]
                {
                    { 1, "jan.k@example.com", "Jan", "Kowalski" },
                    { 2, "a.nowak@example.com", "Anna", "Nowak" },
                }
            );

            migrationBuilder.InsertData(
                table: "Desks",
                columns: new[] { "Id", "Office_id", "Price", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1, 50.00m, "Active", 0 },
                    { 2, 1, 100.00m, "Active", 1 },
                    { 3, 2, 60.00m, "Active", 0 },
                }
            );

            migrationBuilder.InsertData(
                table: "OfficeAddresses",
                columns: new[]
                {
                    "Id",
                    "AddressLine1",
                    "AddressLine2",
                    "City",
                    "OfficeId",
                    "PostalCode",
                    "Town",
                },
                values: new object[,]
                {
                    { 1, "Plac Europejski 1", "", "Warszawa", 1, "00123", "Mazowieckie" },
                    { 2, "Pawia 5", "", "Kraków", 2, "31154", "Małopolskie" },
                }
            );

            migrationBuilder.InsertData(
                table: "AmenityDesk",
                columns: new[] { "AmenitiesId", "DesksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                }
            );

            migrationBuilder.InsertData(
                table: "ReservationArchives",
                columns: new[]
                {
                    "Id",
                    "Created_at",
                    "Desk_id",
                    "End_date",
                    "Start_date",
                    "Updated_at",
                    "User_id",
                },
                values: new object[]
                {
                    1,
                    new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc),
                    3,
                    new DateTime(2026, 5, 20, 18, 0, 0, 0, DateTimeKind.Utc),
                    new DateTime(2026, 5, 20, 10, 0, 0, 0, DateTimeKind.Utc),
                    new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc),
                    2,
                }
            );

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[]
                {
                    "Id",
                    "Created_at",
                    "Desk_id",
                    "End_date",
                    "Start_date",
                    "User_id",
                },
                values: new object[]
                {
                    1,
                    new DateTime(2026, 3, 31, 12, 0, 0, 0, DateTimeKind.Utc),
                    1,
                    new DateTime(2026, 5, 20, 18, 0, 0, 0, DateTimeKind.Utc),
                    new DateTime(2026, 5, 20, 10, 0, 0, 0, DateTimeKind.Utc),
                    1,
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_AmenityDesk_DesksId",
                table: "AmenityDesk",
                column: "DesksId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Desks_Office_id",
                table: "Desks",
                column: "Office_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAddresses_OfficeId",
                table: "OfficeAddresses",
                column: "OfficeId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ReservationArchives_Desk_id",
                table: "ReservationArchives",
                column: "Desk_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ReservationArchives_User_id",
                table: "ReservationArchives",
                column: "User_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Desk_id",
                table: "Reservations",
                column: "Desk_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_id",
                table: "Reservations",
                column: "User_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AmenityDesk");

            migrationBuilder.DropTable(name: "OfficeAddresses");

            migrationBuilder.DropTable(name: "ReservationArchives");

            migrationBuilder.DropTable(name: "Reservations");

            migrationBuilder.DropTable(name: "Amenities");

            migrationBuilder.DropTable(name: "Desks");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "Offices");
        }
    }
}
