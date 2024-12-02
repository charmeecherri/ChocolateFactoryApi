using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChocolateFactoryApi.Migrations
{
    /// <inheritdoc />
    public partial class IntialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionSchedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionSchedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuppilerId = table.Column<int>(type: "int", nullable: false),
                    CostPerUnit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsActive", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Manager@factory.com", true, "$2a$11$cgIIqNPh6ueOB.L.lWPKv.0mXC5fIC4yAGq0L1sRzVrZUbx5cs97u", "FactorManager", "Manager" },
                    { 2, "Quality@factory.com", true, "$2a$11$Xgyzjmax5BeNatMlex74Xuiyeo9B/m/xxZ3mFFCipORvQE3JuLv4S", "QualityController", "quality" },
                    { 3, "supervisor@factory.com", true, "$2a$11$F25ylK0PsWcn0teYn17B6eVr4cylSXyy0txjJ8/UZHFXraPXwyMwS", "ProductionSupervisor", "supervisor" },
                    { 4, "warehouse@factory.com", true, "$2a$11$uJhN5VF/O1s5/z5tgrfEtOq9W.JuVpOo73hjnFkrPTTprLdzIDI46", "warehouseStaff", "warehouse" },
                    { 5, "sales@factory.com", true, "$2a$11$7X.3U4wgVpL3WD8dMYD6DOOKeZZlLvtaZImjboEKEmOEV2Dj1iP82", "SalesRepresentative", "sales" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionSchedules");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
