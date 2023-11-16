using AutoMapper;
using CarShowRoomProject.DTO;
using CarShowRoomProject.Models;

namespace CarShowRoomProject.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<BookedCar, BookedCarDTO>().ReverseMap();
        }
    }
}
