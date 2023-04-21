using AutoMapper;
using DataService.Dto;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Profile
{
    public class AutoMapperProfile : MapperConfigurationExpression
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(a => a.NameDto, b => b.MapFrom(b => b.Name))
                .ReverseMap();
        }
    }
}
