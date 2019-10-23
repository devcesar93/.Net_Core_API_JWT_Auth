using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Contatos_NetCore.Migrations
{
    public partial class ContatosInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Contatos (Nome, Email, Telefone) VALUES ('Fulano Rodrigues Santos', 'fulano2019@gmail.com', '(11) 99929-2097')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Contatos");
        }
    }
}
