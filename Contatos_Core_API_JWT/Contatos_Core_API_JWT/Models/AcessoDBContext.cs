using Contatos_NetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos_NetCore.Models
{
    public class AcessoDBContext : DbContext
    {
        public AcessoDBContext(DbContextOptions<AcessoDBContext> options) : base(options)
        { }

        public DbSet<Acesso> Acesso { get; set; }
    }
}
