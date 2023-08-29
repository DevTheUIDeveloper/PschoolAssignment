using AutoMapper;
using Pschool.Business.Dto;
using Pschool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Parent, ParentDto>();
            CreateMap<Parent, ParentLoad>();
            CreateMap<ParentLoad, Parent>();
            CreateMap<Student, StudentCreateUpdateDto>();
            CreateMap<StudentCreateUpdateDto, Student>();
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => src.Parent));
            CreateMap<ParentDto, Parent>();
            CreateMap<StudentDto, Student>();
        }
    }
}
