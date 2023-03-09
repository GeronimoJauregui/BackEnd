using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Models;
using TiendaServicios.Api.CarritoCompra.Persistence;

namespace TiendaServicios.Api.CarritoCompra.Application
{
    public class New
    {
        public class Ejecuta : IRequest
        {
            public DateTime? FechaCreacion { get; set; }
            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContext _context;

            public Manejador(CarritoContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacion
                };

                _context.CarritoSesion.Add(carritoSesion);
                var value = await _context.SaveChangesAsync();
                if(value == 0)
                {
                    throw new Exception("Errores en la inserción del carrito de compras");
                }
                int id = carritoSesion.CarritoSesionId;
                foreach(var obj in request.ProductoLista)
                {
                    var carritoSesionDetalle = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    _context.CarritoSesionDetalles.Add(carritoSesionDetalle);
                }
                value = await _context.SaveChangesAsync();
                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el detalle del carrito de compras");
            }
        }

    }
}
