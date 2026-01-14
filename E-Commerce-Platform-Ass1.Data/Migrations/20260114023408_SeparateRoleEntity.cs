using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Platform_Ass1.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeparateRoleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Create roles table first
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            // Step 2: Seed default roles
            var userRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();
            
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name", "description", "create_at" },
                values: new object[] { userRoleId, "User", "Default user role", DateTime.UtcNow });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name", "description", "create_at" },
                values: new object[] { adminRoleId, "Admin", "Administrator role", DateTime.UtcNow });

            // Step 3: Add role_id column (nullable first to allow migration of existing data)
            migrationBuilder.AddColumn<Guid>(
                name: "role_id",
                table: "users",
                type: "uniqueidentifier",
                nullable: true);

            // Step 4: Migrate existing role data to role_id
            migrationBuilder.Sql(@"
                UPDATE users 
                SET role_id = CASE 
                    WHEN role = 'Admin' THEN '" + adminRoleId + @"'
                    ELSE '" + userRoleId + @"'
                END
            ");

            // Step 5: Make role_id NOT NULL
            migrationBuilder.AlterColumn<Guid>(
                name: "role_id",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: userRoleId);

            // Step 6: Create foreign key and index
            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            // Step 7: Drop old role column
            migrationBuilder.DropColumn(
                name: "role",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_users_role_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
