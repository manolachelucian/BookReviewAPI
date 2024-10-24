using AutoMapper;
using ReviewApp.DTO;
using ReviewApp.Models;

namespace ReviewApp.AutoHelper
{
    public class MappingProfiles : Profile
    {
        // Mapping between the models and the DTOs
        public MappingProfiles()
        {
            // Map between the models and the DTOs
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Generes, GenereDto>();
            CreateMap<User, UserDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<BookDto, Book>();
            CreateMap<GenereDto, Generes>();
            CreateMap<UserDto, User>();
            CreateMap<ReviewDto, Review>();

        }
    }
}
