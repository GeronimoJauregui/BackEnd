using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Models;
using TiendaServicios.Api.Libro.Persistence;

namespace TiendaServicios.Api.Libro.Application
{
    public class Consult
    {
        public class Ejecuta : IRequest<List<LibreriaMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibreriaMaterialDto>>
        {
            private readonly ContextLibreria _context;
            private readonly IMapper _mapper;

            public Manejador(ContextLibreria context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<LibreriaMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _context.LibreriaMaterial.ToListAsync();
                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibreriaMaterialDto>>(libros);

                return librosDto;
            }
        }
    }
}
