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
    public class Consult
    {
        public class ListaAutor : IRequest<List<AutorLibroDto>> { }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibroDto>>
        {
            public readonly ContextAutor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AutorLibroDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _context.AutorLibro.ToListAsync();
                var autoresLibroDto = _mapper.Map<List<AutorLibro>, List<AutorLibroDto>>(autores);
                return autoresLibroDto;
            }
        }
    }
}
