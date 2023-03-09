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
    public class ConsultFilter
    {
        public class AutorUnico : IRequest<AutorLibro>
        {
            public string AutorLibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibro>
        {
            public readonly ContextAutor _context;

            public Manejador(ContextAutor context)
            {
                _context = context;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _context.AutorLibro.Where(autor => autor.AutorLibroGuid == request.AutorLibroGuid).FirstOrDefaultAsync();
                if(autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                return autor;
            }
        }
    }
}
