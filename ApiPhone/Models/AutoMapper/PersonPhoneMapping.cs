using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.Models.AutoMapper
{
    public class PersonPhoneMapping : Profile
    {
        public PersonPhoneMapping()
        {
            CreateMap<VO.PersonPhoneVO, PersonPhone>()
                .ForMember(dest => dest.Id, ori => ori.MapFrom(src=>src.id))
                .ForMember(dest => dest.PhoneNumber, ori => ori.MapFrom(src => src.phoneNumber))
                .ForMember(dest => dest.IdPhoneNumberType, ori => ori.MapFrom(src => src.idPhoneNumberType))
                .ReverseMap();
            
        }
    }
}
