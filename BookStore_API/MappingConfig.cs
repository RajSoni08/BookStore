using AutoMapper;
using BookStore_API.Model;
using BookStore_API.Model.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User,UserUpdateDTO>().ReverseMap();
            CreateMap<UserDTO,UserUpdateDTO>().ReverseMap();   
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<PublisherDTO, PublisherUpdateDTO>().ReverseMap();
            CreateMap<Publisher,PublisherUpdateDTO>().ReverseMap();
            CreateMap<Author,AuthorDTO>().ReverseMap();
            CreateMap<Author,AuthorUpdateDTO>().ReverseMap();
            CreateMap<AuthorDTO,AuthorUpdateDTO>().ReverseMap();
            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<Book,BookUpdateDTO>().ReverseMap();
            CreateMap<BookDTO,BookUpdateDTO>().ReverseMap();
        }


    }
}
