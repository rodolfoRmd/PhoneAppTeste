using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.Models.AutoMapper
{
    public class PhoneNumberTypeMapping: Profile
    {
        public PhoneNumberTypeMapping()
        {
            CreateMap<VO.PhoneNumberTypeVO, PhoneNumberType>()
                .ForMember(dest => dest.Id, ori => ori.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, ori => ori.MapFrom(src => src.name))
               
                .ReverseMap();

        }
    }
}
