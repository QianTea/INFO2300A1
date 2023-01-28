using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameMarketPlace.Migrations
{
    public partial class UpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e67044f0-457f-4534-baea-cf959f2deed0");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CreditCards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MailingAPNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingCity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingPostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MailingProvince",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SameAsShipping",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_MemberId",
                table: "CreditCards",
                column: "MemberId");        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_AspNetUsers_MemberId",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_MemberId",
                table: "CreditCards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ff80da5-bd29-4a47-ae53-a5d831753b28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d04f6c16-6b95-44fb-a7a2-a4ea83422584");

            migrationBuilder.DropColumn(
                name: "MailingAPNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MailingCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MailingPostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MailingProvince",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SameAsShipping",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "APSuiteNumber", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "GenreId", "LastName", "LockoutEnabled", "LockoutEnd", "MailingAddress", "MemberId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlatformId", "PromotionalEmail", "ProvinceId", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName", "WishListId" },
                values: new object[] { "e67044f0-457f-4534-baea-cf959f2deed0", "", 0, "Waterloo", "6639ca4f-f057-4da4-84ca-1b59b3f68994", new DateTime(2022, 11, 6, 14, 20, 29, 194, DateTimeKind.Local).AddTicks(9156), "Member", "Admin@admin.com", true, "", 1, 1, "", false, null, "", "Admin", null, null, "AQAAAAEAACcQAAAAEPhmI5xpIDQlwzsxsJ97pdbGeuIshfMGqec/qIr+Pq9Z010esEorxpf30Z5SXsqfUg==", null, false, 1, false, 1, "ab247744-14ce-435e-ba04-6df689497811", "421 Strawberry Road", false, "admin", 1 });

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2024, 11, 6, 14, 20, 29, 194, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 11, 6, 14, 20, 29, 194, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventDate",
                value: new DateTime(2022, 11, 11, 14, 20, 29, 194, DateTimeKind.Local).AddTicks(9508));
        }
    }
}
