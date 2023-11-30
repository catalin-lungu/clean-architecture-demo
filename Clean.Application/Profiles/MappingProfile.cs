using AutoMapper;
using Clean.Application.Features.Students.Commands.CreateCheckIn;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Queries;
using Clean.Domain.Entities;

namespace Clean.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Student, StudentVM>().ReverseMap();
            CreateMap<Domain.Entities.CheckIn, CheckInVM>().ReverseMap();

            CreateMap<Domain.Entities.Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Domain.Entities.CheckIn, CheckInCommand>().ReverseMap();
        }
    }
}