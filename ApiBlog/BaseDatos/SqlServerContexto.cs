using ApiBlog.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.BaseDatos
{
    public class SqlServerContexto : DbContext
    {
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public SqlServerContexto(DbContextOptions<SqlServerContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    ID = 1,
                    Descripcion = "Publicacion uno",
                    Estado = "A"
                },
                new Categoria
                {
                    ID = 2,
                    Descripcion = "Publicacion dos",
                    Estado = "A"
                }
            );
        }
    }
}
