using AutoMapper;
using ReviewApp.DTO;
using ReviewApp.Models;

namespace ReviewApp.AutoHelper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Generes, GenereDto>();
        }
    }
}
