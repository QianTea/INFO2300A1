using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameMarketPlace.Migrations
{
    public partial class ReviewV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fec5110-2f2d-4dd0-8a60-8f2ce73841d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f444a6ff-e6c0-4365-a590-46a252af5dad");

            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "APSuiteNumber", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "GenreId", "LastName", "LockoutEnabled", "LockoutEnd", "MailingAPNumber", "MailingAddress", "MailingCity", "MailingPostalCode", "MailingProvince", "MemberId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlatformId", "PostalCode", "PromotionalEmail", "ProvinceId", "SameAsShipping", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "bd209521-92a2-4d62-99ce-0e5d0a49ad9c", "", 0, "", "e8a4cfcc-a0a5-4c5c-b325-1cef25e4dc0f", new DateTime(2022, 12, 2, 13, 26, 9, 291, DateTimeKind.Local).AddTicks(8379), "Member", "NJackson6581@conestogac.on.ca", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Testing", null, null, "AQAAAAEAACcQAAAAEMJmFiXBkcpYLwS65DFBl0QyBUuxHKjmXyQajY/4gx2UCKAjqrLXMZx5qSuA7f/ibg==", null, false, 1, "", false, 1, false, "89346c16-e766-45f9-af18-084b1563b5cb", "", false, "Testing", 2 },
                    { "f703524c-599c-4578-bc2f-de65e4f58e4a", "", 0, "Waterloo", "0a66259b-2fb5-4c71-bbc2-84084b60a437", new DateTime(2022, 12, 2, 13, 26, 9, 290, DateTimeKind.Local).AddTicks(6444), "Member", "Admin@admin.com", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Admin", null, null, "AQAAAAEAACcQAAAAEGawy4rpV2bBNPCbr8uF0CGNKDVoQkvkbMDdY6w9SZ/kT78kwdklw8lp0WU3Ap2v2A==", null, false, 1, "", false, 1, false, "e70e3773-8285-47ef-a7ec-d2df1f23f3df", "421 Strawberry Road", false, "admin", 1 }
                });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2024, 12, 2, 13, 26, 9, 291, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 12, 2, 13, 26, 9, 291, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2022, 12, 7, 13, 26, 9, 291, DateTimeKind.Local).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "MemberName",
                value: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd209521-92a2-4d62-99ce-0e5d0a49ad9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f703524c-599c-4578-bc2f-de65e4f58e4a");

            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "APSuiteNumber", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "GenreId", "LastName", "LockoutEnabled", "LockoutEnd", "MailingAPNumber", "MailingAddress", "MailingCity", "MailingPostalCode", "MailingProvince", "MemberId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlatformId", "PostalCode", "PromotionalEmail", "ProvinceId", "SameAsShipping", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "1fec5110-2f2d-4dd0-8a60-8f2ce73841d4", "", 0, "Waterloo", "93c3e946-a569-45aa-99b1-912fdc0f64fe", new DateTime(2022, 12, 2, 13, 21, 12, 915, DateTimeKind.Local).AddTicks(1943), "Member", "Admin@admin.com", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Admin", null, null, "AQAAAAEAACcQAAAAEJJLaq8WZvGLX1ewR2hbs0y/rWR4ff6tH31+BRb7P23bzfiodrr1SMg9Wjhgv8qjkg==", null, false, 1, "", false, 1, false, "af88acbe-f7a9-45a2-a595-873d37cba293", "421 Strawberry Road", false, "admin", 1 },
                    { "f444a6ff-e6c0-4365-a590-46a252af5dad", "", 0, "", "0d49f210-79c8-4b93-82f1-0abd64fb274c", new DateTime(2022, 12, 2, 13, 21, 12, 916, DateTimeKind.Local).AddTicks(3759), "Member", "NJackson6581@conestogac.on.ca", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Testing", null, null, "AQAAAAEAACcQAAAAELMYrKxQHZ7wN/kq7nUNtyq5olcKw4iS1qmGD+Gr3Y5GcjW7AR9tMEnXaFgx9a/Hag==", null, false, 1, "", false, 1, false, "6873e9f8-efb2-4add-ae54-a4454ac16379", "", false, "Testing", 2 }
                });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2024, 12, 2, 13, 21, 12, 916, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 12, 2, 13, 21, 12, 916, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2022, 12, 7, 13, 21, 12, 916, DateTimeKind.Local).AddTicks(4060));
        }
    }
}
