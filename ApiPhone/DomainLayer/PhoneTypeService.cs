using ApiPhone.DAL.Repositorio;
using ApiPhone.Models.VO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DomainLayer
{
    public class PhoneTypeService : IPhoneTypeService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PhoneTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public IEnumerable<PhoneNumberTypeVO> GetAll()
        {
            var listaBanco =  _uow.PhoneNumberTypesRepositorio.GetAll().ToList();
            return _mapper.Map<List<Models.PhoneNumberType>, List<Models.VO.PhoneNumberTypeVO>>(listaBanco);

        }
    }
}
