﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Marwan.DAL.Data.Migration
{
    using Microsoft.EntityFrameworkCore.Migrations;
    /// <inheritdoc />
    /// 
    public partial class AddImageNameColumnToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "employees");
        }
    }
}
