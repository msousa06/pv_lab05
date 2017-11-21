using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab05.Models
{
    public class TopCarContext : DbContext
    {
        public TopCarContext(DbContextOptions<TopCarContext> options)
                : base(options)
        { }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Marca> Marcas { get; set; }
    }
}
