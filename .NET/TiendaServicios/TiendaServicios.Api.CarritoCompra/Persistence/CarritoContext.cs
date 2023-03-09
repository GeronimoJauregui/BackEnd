using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Models;

namespace TiendaServicios.Api.CarritoCompra.Persistence
{
    public class CarritoContext : DbContext
    {
        public CarritoContext(DbContextOptions<CarritoContext> options) : base(options) { }

        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }
    }
}
