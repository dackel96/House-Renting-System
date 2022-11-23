using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class changesToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b54cf58-70fd-4375-96f0-cda03c396ade", "AQAAAAEAACcQAAAAEJJ0h6en0joQAZtQKJmE5/o19cAW8sQnPBxKhZHg78u07M9D+Duo0vlpRPoYEX0xmw==", "15c47272-c7a5-4419-b458-43db5f6ceeb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9406e67e-f665-4df2-97b0-3342e0c801a4", "AQAAAAEAACcQAAAAEKtqWbl0v1tt/4x8QYY2nwvTohaSWv+n0P2bD5TQhwdmCxva5cNP3dPvYoIBLoTsnA==", "d1c524da-673a-411b-b294-a5a77727d68e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa8655fe-0eda-4a2c-ae60-7de032bce6b5", "AQAAAAEAACcQAAAAEOQ2RgVDjSpuGh7WFKDujoZMMQOF3HNmTY2PagVMBs3GQJ8G3gbSO2imazxR5bp9Pg==", "6715493f-25eb-4c95-9b04-64d20e471c2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e37a00a5-0092-4f08-bbb3-e6fdc1c68c19", "AQAAAAEAACcQAAAAEIXgJ62gNJCD5lUQjelExMHq7IShbTUxUvqWAHyv8UUrjxPKXqPvRc1aKUEh8stpIg==", "00146108-b70a-489b-b808-3b200c6f920e" });
        }
    }
}
