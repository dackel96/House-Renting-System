using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddHouseException : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f862dfce-7e2b-43df-919a-5c111f21a623", "AQAAAAEAACcQAAAAEH3Cc2KBYLlhmkpHfMiVpyARRpQdFuKIj/MSPzDEeD5iq6r3PX0EqnIIV/DlWq83qw==", "2227bb5c-1ed2-4254-8d1e-c341d8d13b14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47085791-29ca-4a04-a334-a9545a28fd73", "AQAAAAEAACcQAAAAEA12LGeGgXHz4Owj+/VE2EXCQKPmz4vG6vH5Ia0pT1ZDvP6GNLUtgfxSXciQWwbz2g==", "e64e1c62-0cc6-4a41-928c-62596a7c132e" });
        }
    }
}
