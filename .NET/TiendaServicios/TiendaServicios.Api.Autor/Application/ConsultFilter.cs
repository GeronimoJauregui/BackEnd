using AutoMapper;
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
        public class AutorUnico : IRequest<AutorLibroDto>
        {
            public string AutorLibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibroDto>
        {
            public readonly ContextAutor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AutorLibroDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _context.AutorLibro.Where(autor => autor.AutorLibroGuid == request.AutorLibroGuid).FirstOrDefaultAsync();
                if(autor == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var autorLibroDto = _mapper.Map<AutorLibro, AutorLibroDto>(autor);
                return autorLibroDto;
            }
        }
    }
}
