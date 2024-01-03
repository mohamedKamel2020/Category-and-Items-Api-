using AutoMapper;
using CategoryAndItemAPI.DAL.Entities;
using CategoryAndItemAPI.Dtos;

namespace CategoryAndItemAPI.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ItemToReturnDto>().ReverseMap();
            CreateMap<Item, ItemToReturnDtoWithId>().ReverseMap();
            CreateMap<Item, ItemToReturnDtoWithCategory>().
                ForMember(d => d.Category, O => O.MapFrom(S => S.Category.Name)).ReverseMap();

            CreateMap<Category, CategoryToReturnDto>().ReverseMap();
            CreateMap<Category, CategoryToReturnDtoWithId>().ReverseMap();


        }
    }
}
