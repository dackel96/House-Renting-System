using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class deletableFlagAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "007c54cd-39d0-4365-9b44-74f7471900c7", "AQAAAAEAACcQAAAAEKjX8EDMB3bWlm+LYIMooE4/suUvpQOAMdmHdasdr1KxhyqPtthMu4QbDR2D2IN7mw==", "c6092e04-cb3a-4e07-ba0c-643585f0f239" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "7a6b9a01-137b-44a2-9f6d-41ce77dc3b2f", "AQAAAAEAACcQAAAAEIRh50N9QTMkSKr8qkbXNzrvBmfY4BR2X+MDj8vUn5RnbPm4bGENynaq5DA4btNDyg==", "5d967b8b-b614-4a5d-98e4-7523c17b7a56" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Houses");

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
    }
}
