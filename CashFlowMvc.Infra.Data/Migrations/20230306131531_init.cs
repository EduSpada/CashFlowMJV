using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlowMvc.Infra.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DirectionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CreatedAt", "Description", "DirectionId", "UpdatedAt" },
                values: new object[] { 1, null, "inflow exemple", 1, null });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CreatedAt", "Description", "DirectionId", "UpdatedAt" },
                values: new object[] { 2, null, "outflow exemple", 2, null });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CreatedAt", "Description", "PaymentMethodId", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9086), "George Wells Company", 1, null, 3015.17m },
                    { 2, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9089), "Mayden Market", 2, null, 183.25m },
                    { 3, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9090), "Clean Services S/A", 2, null, 15850.13m },
                    { 4, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9091), "Paul Walker Acessories", 1, null, 11012.33m },
                    { 5, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9092), "Mindnith Events", 1, null, 5489.85m },
                    { 6, new DateTime(2023, 3, 6, 13, 15, 31, 122, DateTimeKind.Utc).AddTicks(9093), "Energy Company", 2, null, 2123.74m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PaymentMethodId",
                table: "Operations",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
