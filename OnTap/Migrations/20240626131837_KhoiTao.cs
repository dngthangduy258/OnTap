using Microsoft.EntityFrameworkCore.Migrations;

namespace OnTap.Migrations
{
    public partial class KhoiTao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "A", 12000m, 10, "PHP" },
                    { 2, "A", 12000m, 15, "C#" },
                    { 3, "A", 12000m, 10, "Quản trị SQL Server" },
                    { 4, "A", 12000m, 15, "Lập trình Node.js" },
                    { 5, "A", 12000m, 10, "ASP.Net Core MVC" },
                    { 6, "A", 12000m, 15, "Cấu trúc dữ liệu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
