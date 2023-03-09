using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Models;

namespace TiendaServicios.Api.Libro.Persistence
{
    public class ContextLibreria : DbContext
    {
        public ContextLibreria(DbContextOptions<ContextLibreria> options) : base(options) { }

        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
    }
}
