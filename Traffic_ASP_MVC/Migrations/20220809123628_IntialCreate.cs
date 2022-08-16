using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traffic_ASP_MVC.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timeSlot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberCartons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loadCube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mbolNbr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loadNbr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carrierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loadComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loadScheduler = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
