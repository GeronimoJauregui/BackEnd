using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Models;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Application
{
    public class New
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextAutor _context;

            public Manejador(ContextAutor context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid())
                };

                _context.AutorLibro.Add(autorLibro);
                var valor = await _context.SaveChangesAsync();

                if (valor > 0 )
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el Autor del libro");
            }
        }
    }
}
