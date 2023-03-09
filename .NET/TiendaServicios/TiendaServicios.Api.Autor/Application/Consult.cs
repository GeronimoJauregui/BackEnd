using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Models;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class Consult
    {
        public class ListaAutor : IRequest<List<AutorLibro>> { }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            public readonly ContextAutor _context;

            public Manejador(ContextAutor context)
            {
                _context = context;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _context.AutorLibro.ToListAsync();

                return autores;
            }
        }
    }
}
