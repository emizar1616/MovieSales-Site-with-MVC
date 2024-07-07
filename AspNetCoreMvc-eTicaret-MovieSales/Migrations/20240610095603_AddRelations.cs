using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMvc_eTicaret_MovieSales.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieSaleId1",
                table: "SalesDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_MovieId",
                table: "SalesDetail",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_MovieSaleId1",
                table: "SalesDetail",
                column: "MovieSaleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Movies_MovieId",
                table: "SalesDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetail_Sales_MovieSaleId1",
                table: "SalesDetail");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetail_MovieId",
                table: "SalesDetail");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetail_MovieSaleId1",
                table: "SalesDetail");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieSaleId1",
                table: "SalesDetail");
        }
    }
}
