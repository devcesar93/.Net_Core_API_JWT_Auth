using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos_NetCore.Models
{
    public class ContatoDBContext : DbContext
    {
        public ContatoDBContext(DbContextOptions<ContatoDBContext> options) : base(options)
        {}

        public DbSet<Contato> Contatos { get; set; }
    }
}
