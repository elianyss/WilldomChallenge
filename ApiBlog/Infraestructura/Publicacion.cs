using ApiBlog.BaseDatos;
using ApiBlog.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Infraestructura
{
    public class Publicacion : ApiBlog.Dominio.Interfaces.IPublicacion
    {
        private readonly SqlServerContexto _dbContext;

        public Publicacion(SqlServerContexto dbContext)
        {
            _dbContext = dbContext;
        }
     
        public void GrabarBase()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<ApiBlog.Dominio.Entidades.Publicacion> ConsultarPublicaciones()
        {
            return _dbContext.Publicacion.ToList();
        }

        public ApiBlog.Dominio.Entidades.Publicacion ConsultarPublicacionesPorId(int IdPublicacion)
        {
            return _dbContext.Publicacion.Find(IdPublicacion);
        }

        public void GrabarPublicacion(ApiBlog.Dominio.Entidades.Publicacion publicacion)
        {
            _dbContext.Add(publicacion);
            GrabarBase();
        }

      
    }
}
