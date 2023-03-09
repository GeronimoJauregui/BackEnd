using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Application;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : Controller
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(New.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibreriaMaterialDto>>> GetLibros()
        {
            return await _mediator.Send(new Consult.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibreriaMaterialDto>> GetLibro(Guid id)
        {
            return await _mediator.Send(new ConsultFilter.LibroUnico { LibreriaMaterialId = id });
        }
    }
}
