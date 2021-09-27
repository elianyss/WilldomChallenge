using ApiBlog.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dominio.Interfaces
{
    public interface IPublicacion
    {
        public IEnumerable<ApiBlog.Dominio.Entidades.Publicacion> ConsultarPublicaciones();
        public ApiBlog.Dominio.Entidades.Publicacion ConsultarPublicacionesPorId(int IdPublicacion);
        public void GrabarPublicacion(Publicacion publicacion);

    }
}
