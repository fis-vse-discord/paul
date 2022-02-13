﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PaulBot.Migrations
{
    public partial class AddMemberVerifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "verifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    member_id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    is_revoked = table.Column<bool>(type: "boolean", nullable: false),
                    azure_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_verifications", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_verifications_member_id",
                table: "verifications",
                column: "member_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "verifications");
        }
    }
}
