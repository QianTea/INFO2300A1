using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameMarketPlace.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ff80da5-bd29-4a47-ae53-a5d831753b28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d04f6c16-6b95-44fb-a7a2-a4ea83422584");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

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

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Approved", "GameId", "ReviewComments" },
                values: new object[] { 1, true, 1, "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fec5110-2f2d-4dd0-8a60-8f2ce73841d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f444a6ff-e6c0-4365-a590-46a252af5dad");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "APSuiteNumber", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "GenreId", "LastName", "LockoutEnabled", "LockoutEnd", "MailingAPNumber", "MailingAddress", "MailingCity", "MailingPostalCode", "MailingProvince", "MemberId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlatformId", "PostalCode", "PromotionalEmail", "ProvinceId", "SameAsShipping", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName", "WishListId" },
                values: new object[,]
                {
                    { "5ff80da5-bd29-4a47-ae53-a5d831753b28", "", 0, "", "e1598bd7-99ab-47c3-a7dc-d8c70e3fe3cc", new DateTime(2022, 11, 11, 10, 39, 30, 249, DateTimeKind.Local).AddTicks(7894), "Member", "NJackson6581@conestogac.on.ca", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Testing", null, null, "AQAAAAEAACcQAAAAENMykcv8E0og3dF8x4dRX0ENPP5IZLUoeLiP9yfgNfaZVKBtK2DfMbwBnMr0rMMvGQ==", null, false, 1, "", false, 1, false, "24937552-34ea-4dcd-a719-7cadc4a3ac76", "", false, "Testing", 2 },
                    { "d04f6c16-6b95-44fb-a7a2-a4ea83422584", "", 0, "Waterloo", "99592b5e-b2cf-4d94-8789-15b5008e43cc", new DateTime(2022, 11, 11, 10, 39, 30, 248, DateTimeKind.Local).AddTicks(6651), "Member", "Admin@admin.com", true, "", 1, 1, "", false, null, "", "", "", "", 1, "Admin", null, null, "AQAAAAEAACcQAAAAEOWnTebpZrW7xIFZaY6AtSfZqEIc0MHDla6CTViZkUqnYIeS8brgTTJOrekdESQLzw==", null, false, 1, "", false, 1, false, "256d5605-3b6a-44a3-bb38-75010871a1c1", "421 Strawberry Road", false, "admin", 1 }
                });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2024, 11, 11, 10, 39, 30, 249, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 11, 11, 10, 39, 30, 249, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2022, 11, 16, 10, 39, 30, 249, DateTimeKind.Local).AddTicks(8116));
        }
    }
}
