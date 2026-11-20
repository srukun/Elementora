using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Elementora.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Moves",
                columns: new[] { "Id", "Accuracy", "Category", "Name", "Power", "Type" },
                values: new object[,]
                {
                    { 1, 100, "Physical", "Spark Bite", 40, "Energy" },
                    { 2, 95, "Special", "Volt Beam", 70, "Energy" },
                    { 3, 100, "Physical", "Vine Lash", 45, "Bio" },
                    { 4, 95, "Special", "Spore Burst", 65, "Bio" },
                    { 5, 95, "Physical", "Gear Smash", 60, "Tech" },
                    { 6, 100, "Special", "Laser Pulse", 55, "Tech" },
                    { 7, 100, "Special", "Static Shift", 50, "Null" },
                    { 8, 100, "Physical", "Tackle", 35, "Null" },
                    { 9, 100, "Utility", "Harden", 0, "Null" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "BaseDefense", "BaseHp", "BasePhysicalAttack", "BaseSpecialAttack", "BaseSpeed", "Name", "Rank", "Rarity", "Type" },
                values: new object[,]
                {
                    { 1, 50, 60, 50, 75, 85, "Voltkit", 1, "Common", "Energy" },
                    { 2, 70, 75, 60, 55, 45, "Sproutling", 1, "Common", "Bio" },
                    { 3, 75, 65, 75, 45, 50, "Cogling", 1, "Common", "Tech" },
                    { 4, 65, 70, 65, 65, 65, "Glitchmote", 1, "Uncommon", "Null" },
                    { 5, 100, 95, 90, 60, 55, "Thornback", 2, "Rare", "Bio" },
                    { 6, 110, 110, 120, 100, 90, "Arcforge", 3, "Legendary", "Tech" }
                });

            migrationBuilder.InsertData(
                table: "SpeciesMoves",
                columns: new[] { "MoveId", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 8, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 9, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 9, 3 },
                    { 7, 4 },
                    { 8, 4 },
                    { 9, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 8, 5 },
                    { 2, 6 },
                    { 5, 6 },
                    { 6, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "SpeciesMoves",
                keyColumns: new[] { "MoveId", "SpeciesId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Moves",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
