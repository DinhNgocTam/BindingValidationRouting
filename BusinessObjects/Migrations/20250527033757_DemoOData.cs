using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class DemoOData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gadgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gadgets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gadgets",
                columns: new[] { "Id", "Brand", "Cost", "ProductName", "Type" },
                values: new object[,]
                {
                    { 1, "BrandA", 499.99m, "Smartphone X1", "Smartphone" },
                    { 2, "BrandB", 1299.00m, "Laptop Pro 15", "Laptop" },
                    { 3, "BrandC", 99.99m, "Wireless Earbuds", "Audio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gadgets");
        }
    }
}
