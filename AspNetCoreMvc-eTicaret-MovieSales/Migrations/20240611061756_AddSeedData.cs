using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreMvc_eTicaret_MovieSales.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Movies_MovieId",
                table: "SalesDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Sales_MovieSaleId1",
                table: "SalesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDetail",
                table: "SalesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "SalesDetail",
                newName: "MovieSalesDetail");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "MovieSales");

            migrationBuilder.RenameIndex(
                name: "IX_SalesDetail_MovieSaleId1",
                table: "MovieSalesDetail",
                newName: "IX_MovieSalesDetail_MovieSaleId1");

            migrationBuilder.RenameIndex(
                name: "IX_SalesDetail_MovieId",
                table: "MovieSalesDetail",
                newName: "IX_MovieSalesDetail_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerId",
                table: "MovieSales",
                newName: "IX_MovieSales_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieSalesDetail",
                table: "MovieSalesDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieSales",
                table: "MovieSales",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "Beşiktaş-İstanbul", "ali@gmail.com", "Ali Uçar", "123", "533 345 56 67" },
                    { 2, "Kadıköy-İstanbul", "oya@gmail.com", "Oya Uçar", "123", "543 345 56 67" },
                    { 3, "Bakırköy-İstanbul", "nese@gmail.com", "Neşe Sever", "123", "433 345 56 67" },
                    { 4, "Beşiktaş-İstanbul", "hasan@gmail.com", "Hasan Kaya", "123", "633 345 56 67" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Komik olaylar", "Komedi" },
                    { 2, "Tarihi Savaşlar , kan , şiddet", "Savaş" },
                    { 3, "Hem romantik hem komik olaylar", "Romantik Komedi" },
                    { 4, "Acıklı Hikayeler", "Dram" },
                    { 5, "Korku , gerilim", "Korku" },
                    { 6, "Robotlar , uzay", "Bilim Kurgu" },
                    { 7, "Gerçek dışı, heyecanlı", "Fantastik" },
                    { 8, "Hareket , aksiyon dolu sahneler", "Aksiyon" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "Director", "GenreId", "ImageUrl", "IsDiscount", "IsLocal", "Name", "Price", "RelaseDate", "Stock", "Summary" },
                values: new object[,]
                {
                    { 1, "Bradd Pit , Orlando Bloom", "Wolgan Pettersen", 2, "/images/truva.jpg", false, false, "Truva", 350m, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Tarihten Truva savaşından kesitler" },
                    { 2, "Ananda George , Donny Alamsyah", "Gareth Evans", 8, "/images/baskin.jpg", false, false, "Baskın", 340m, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Operasyom timinin uyuşturucu baskınları" },
                    { 3, "Leonarda Di Caprio , Cate Winslet", "James Cameron", 4, "/images/titanic.jpg", false, false, "Titanic", 320m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lüks titanic gemisinin hazin öyküsü" },
                    { 4, "Bradd Pit , Edward Norton", "David Lyinch", 8, "/images/fight.jpg", false, false, "Fight Club", 330m, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Dövüş kulübü , ilk kural bahsetmemek" },
                    { 5, "Bradd Pit , Christoph Wals", "Quentin Tarantino", 2, "/images/soysuzlar.jpg", false, false, "Soysuzlar Çetesi", 310m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "2. Dünya savaşından kesitler" },
                    { 6, "Bradd Pit , Christoph Wals", "Quentin Tarantino", 2, "/images/soysuzlar.jpg", false, false, "Soysuzlar Çetesi", 310m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "2. Dünya savaşından kesitler" },
                    { 7, "Bradd Pit , Christoph Wals", "Quentin Tarantino", 2, "/images/soysuzlar.jpg", false, false, "Soysuzlar Çetesi", 310m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "2. Dünya savaşından kesitler" },
                    { 8, "Bradd Pit , Christoph Wals", "Quentin Tarantino", 2, "/images/soysuzlar.jpg", false, false, "Soysuzlar Çetesi", 310m, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "2. Dünya savaşından kesitler" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSalesDetail_MovieSales_MovieSaleId1",
                table: "MovieSalesDetail",
                column: "MovieSaleId1",
                principalTable: "MovieSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSalesDetail_Movies_MovieId",
                table: "MovieSalesDetail",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSalesDetail_MovieSales_MovieSaleId1",
                table: "MovieSalesDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSalesDetail_Movies_MovieId",
                table: "MovieSalesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieSalesDetail",
                table: "MovieSalesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieSales",
                table: "MovieSales");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameTable(
                name: "MovieSalesDetail",
                newName: "SalesDetail");

            migrationBuilder.RenameTable(
                name: "MovieSales",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_MovieSalesDetail_MovieSaleId1",
                table: "SalesDetail",
                newName: "IX_SalesDetail_MovieSaleId1");

            migrationBuilder.RenameIndex(
                name: "IX_MovieSalesDetail_MovieId",
                table: "SalesDetail",
                newName: "IX_SalesDetail_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieSales_CustomerId",
                table: "Sales",
                newName: "IX_Sales_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDetail",
                table: "SalesDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetail_Movies_MovieId",
                table: "SalesDetail",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetail_Sales_MovieSaleId1",
                table: "SalesDetail",
                column: "MovieSaleId1",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
