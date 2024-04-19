using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PabloNobrega.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendedorId",
                table: "Departamento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_VendedorId",
                table: "Departamento",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Vendedor_VendedorId",
                table: "Departamento",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Vendedor_VendedorId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_VendedorId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Departamento");
        }
    }
}
