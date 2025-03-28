using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleWeb.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pasport",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false, comment: "Номер"),
                    series = table.Column<int>(type: "integer", nullable: false, comment: "Серия"),
                    issue_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Дата выдачи"),
                    birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "День рождения")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pasport", x => x.id);
                },
                comment: "Паспорт");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Имя"),
                    last_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Фамилия"),
                    passport_id = table.Column<int>(type: "integer", nullable: false, comment: "Индетификатор паспорта")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_pasport_passport_id",
                        column: x => x.passport_id,
                        principalTable: "pasport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Пользователь");

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false, comment: "Индетификатор юзера"),
                    email = table.Column<string>(type: "text", nullable: false, comment: "Почта"),
                    phone = table.Column<string>(type: "text", nullable: false, comment: "Телефон")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_contact_user_set_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Контакт");

            migrationBuilder.CreateIndex(
                name: "ix_contact_user_id",
                table: "contact",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_passport_id",
                table: "user",
                column: "passport_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "pasport");
        }
    }
}
