using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Inventarios> Inventarios { get; set; }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Secciones> Secciones { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public Contexto() : base("ConStr")
        { }
    }
}
