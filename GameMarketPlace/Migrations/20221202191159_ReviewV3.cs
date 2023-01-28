using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameMarketPlace.Migrations
{
    public partial class ReviewV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd209521-92a2-4d62-99ce-0e5d0a49ad9c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f703524c-599c-4578-bc2f-de65e4f58e4a");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "APSuiteNumber", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "GenreId", "LastName", "LockoutEnabled", "LockoutEnd", "MailingAPNumber", "MailingAddress", "MailingCity", "MailingPostalCode", "MailingProvince", "MemberId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlatformId", "PostalCode", "PromotionalEmail", "ProvinceId", "SameAsShipping", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "1d87a6ad-8587-4e6c-8381-bc71b2e3936c", "", 0, "Waterloo", "dc866a43-236b-4fae-94f9-7f6753c2592d", new DateTime(2022, 12, 2, 14, 11, 59, 228, DateTimeKind.Local).AddTicks(6336), "Member", "Admin@admin.com", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Admin", null, null, "AQAAAAEAACcQAAAAEIweY9iqe57TO4LeIOs7VdX4+jC2qXsGo4SNnoxoFVrisW8bFwM+bmbKIRHvJfB/QA==", null, false, 1, "", false, 1, false, "56bfce72-42a1-403d-825e-e230b1f8c48b", "421 Strawberry Road", false, "admin", 1 },
                    { "3f6e4ee1-600d-4fd0-976d-fcc38a37790e", "", 0, "", "52c0ce4e-3016-4108-a36b-2e74b7db6461", new DateTime(2022, 12, 2, 14, 11, 59, 229, DateTimeKind.Local).AddTicks(7593), "Member", "NJackson6581@conestogac.on.ca", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Testing", null, null, "AQAAAAEAACcQAAAAEJjTJ/98WVolxFkY0jv0D9JYAHpEVg5hH8fl0XdFRrEIUTvlRalanvYVTzuHmO1n+w==", null, false, 1, "", false, 1, false, "b970298a-8d48-4c80-bea4-10a99c794a28", "", false, "Testing", 2 }
                });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2024, 12, 2, 14, 11, 59, 229, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 12, 2, 14, 11, 59, 229, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2022, 12, 7, 14, 11, 59, 229, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "Rating",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d87a6ad-8587-4e6c-8381-bc71b2e3936c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f6e4ee1-600d-4fd0-976d-fcc38a37790e");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

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
        }
    }
}
