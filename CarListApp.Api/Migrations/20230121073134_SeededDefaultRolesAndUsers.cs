using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a", "4e07bc89-e431-4329-9f5c-6ee970a3e045", "User", "USER" },
                    { "b152ca2b-d8d7-4e8d-9863-af0f6f54609f", "3bc83cdf-2c3c-4444-97fe-695e3a89feff", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63", 0, "765762cf-bc8b-45fc-a2d5-f591dab0c41c", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAED85pDcuGJ7LXXSpvMn6Fpbux6FSbSYNMqL6o/+QSg+92yQy3BNcAy59AAyXMVgSog==", null, false, "e0e3da6a-5a7c-4fe8-bd5c-fbf06a478013", false, "user@localhost.com" },
                    { "a7ede16b-a1e2-4a7f-8135-e447d3875816", 0, "213bfe37-eac6-467e-849d-42b58f705413", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEP6yg+Tcl6SKUqifNwMBw4j3CXxSJ+M+1JzVg6w1SjANU+6DWyOmH5aDicQdpito5w==", null, false, "0e83b2bd-1fd5-456d-8a2b-317abfdf5e7b", false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a", "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63" },
                    { "b152ca2b-d8d7-4e8d-9863-af0f6f54609f", "a7ede16b-a1e2-4a7f-8135-e447d3875816" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a", "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b152ca2b-d8d7-4e8d-9863-af0f6f54609f", "a7ede16b-a1e2-4a7f-8135-e447d3875816" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ff6e43f-257d-4ec8-9fb0-32b7e6d66e4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b152ca2b-d8d7-4e8d-9863-af0f6f54609f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bf5ab5a-fbbe-4f5a-8b10-893e3bd7ed63");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7ede16b-a1e2-4a7f-8135-e447d3875816");
        }
    }
}
