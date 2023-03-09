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
    public class ConsultFilter
    {
        public class LibroUnico : IRequest<LibreriaMaterialDto> {
            public Guid? LibreriaMaterialId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibreriaMaterialDto>
        {
            private readonly ContextLibreria _context;
            private readonly IMapper _mapper;

            public Manejador(ContextLibreria context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<LibreriaMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro = await _context.LibreriaMaterial.Where( libreria => libreria.LibreriaMaterialId == request.LibreriaMaterialId).FirstOrDefaultAsync();
                
                if(libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                
                var libroDto = _mapper.Map<LibreriaMaterial, LibreriaMaterialDto>(libro);

                return libroDto;
            }
        }

    }
}
