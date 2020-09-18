using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "cat_permiso",
                schema: "public",
                columns: table => new
                {
                    id_permiso = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_descripcion = table.Column<string>(nullable: true),
                    b_Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_permiso", x => x.id_permiso);
                });

            migrationBuilder.CreateTable(
                name: "cat_rol",
                schema: "public",
                columns: table => new
                {
                    id_rol = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ds_descripcion = table.Column<string>(nullable: true),
                    b_Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_rol", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "tb_rol_permiso",
                schema: "public",
                columns: table => new
                {
                    id_rol_permiso = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_rol = table.Column<long>(nullable: false),
                    id_permiso = table.Column<long>(nullable: false),
                    b_activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rol_permiso", x => x.id_rol_permiso);
                    table.ForeignKey(
                        name: "fk_cat_permiso_id_permiso",
                        column: x => x.id_permiso,
                        principalSchema: "public",
                        principalTable: "cat_permiso",
                        principalColumn: "id_permiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cat_rol_id_rol",
                        column: x => x.id_rol,
                        principalSchema: "public",
                        principalTable: "cat_rol",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_rol_permiso_id_permiso",
                schema: "public",
                table: "tb_rol_permiso",
                column: "id_permiso");

            migrationBuilder.CreateIndex(
                name: "IX_tb_rol_permiso_id_rol",
                schema: "public",
                table: "tb_rol_permiso",
                column: "id_rol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_rol_permiso",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cat_permiso",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cat_rol",
                schema: "public");
        }
    }
}
