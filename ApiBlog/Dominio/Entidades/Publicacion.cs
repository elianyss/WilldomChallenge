using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.Dominio.Entidades
{
    public class Publicacion
    {
        public int ID { get; set; }
        public string Cabecera { get; set; }
        public string Detalle { get; set; }
        public string Categoria { get; set; }
        public string FechaHora { get; set; }
        public string Estado { get; set; }

        public Publicacion(int iD, string cabecera, string detalle, string categoria, string fechaHora, string estado)
        {
            ID = iD;
            Cabecera = cabecera;
            Detalle = detalle;
            Categoria = categoria;
            FechaHora = fechaHora;
            Estado = estado;
        }

        public Publicacion()
        {
        }
    }
}
