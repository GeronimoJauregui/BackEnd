using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Application;
using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : Controller
    {
        public readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(New.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibroDto>>> GetAutores()
        {
            return await _mediator.Send(new Consult.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLibroDto>> GetAutor(string id)
        {
            return await _mediator.Send(new ConsultFilter.AutorUnico { AutorLibroGuid = id });
        }
    }
}
