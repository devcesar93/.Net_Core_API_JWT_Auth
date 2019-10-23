using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Contatos_NetCore.Migrations.AcessoDB
{
    public partial class AcessoInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Acesso (Email, Senha) VALUES ('fulano2019@gmail.com', 'password')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Acesso");
        }
    }
}
