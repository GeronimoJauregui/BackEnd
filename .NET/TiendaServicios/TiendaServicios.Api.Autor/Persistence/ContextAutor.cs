using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Models;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class ContextAutor : DbContext
    {
        public ContextAutor(DbContextOptions<ContextAutor> options) : base(options) { }

        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademicos { get; set; }
    }
}
