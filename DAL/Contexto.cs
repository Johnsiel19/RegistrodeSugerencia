using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Sugerencias> Sugerencias { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
