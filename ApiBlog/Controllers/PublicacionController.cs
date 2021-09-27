using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
     
        private readonly ApiBlog.Dominio.Interfaces.IPublicacion _infraestructuraPublicacion;

        public PublicacionController(ApiBlog.Dominio.Interfaces.IPublicacion infraestructuraPublicacion)
        {
            _infraestructuraPublicacion = infraestructuraPublicacion;
        }

        [HttpGet]
        public IActionResult ConsultarPublicaciones()
        {
            var products = _infraestructuraPublicacion.ConsultarPublicaciones();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "ConsultarPublicacionesPorId")]
        public IActionResult ConsultarPublicacionesPorId(int id)
        {
            var product = _infraestructuraPublicacion.ConsultarPublicacionesPorId(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public IActionResult GrabarPublicacion([FromBody] ApiBlog.Dominio.Entidades.Publicacion publicacion)
        {
            using (var scope = new TransactionScope())
            {
                _infraestructuraPublicacion.GrabarPublicacion(publicacion);
                scope.Complete();
                return CreatedAtAction(nameof(GrabarPublicacion), new { id = publicacion.ID }, publicacion);
            }
        }

     
    }
}
