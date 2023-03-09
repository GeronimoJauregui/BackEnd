using AutoMapper;
using TiendaServicios.Api.Libro.Models;

namespace TiendaServicios.Api.Libro.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibreriaMaterialDto>();
        }
    }
}
