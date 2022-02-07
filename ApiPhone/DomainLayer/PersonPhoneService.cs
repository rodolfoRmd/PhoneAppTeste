using ApiPhone.DAL.Repositorio;
using ApiPhone.Models.VO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DomainLayer
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PersonPhoneService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Tuple<bool, string> Adicionar(PersonPhoneVO personPhoneVO)
        {
            //Possui o telefone unico 

            if (ValidarSeNumeroExiste(personPhoneVO.phoneNumber))
                return new Tuple<bool, string>(false, "Já existe esse telefone na base");

            var persoPhone = new Models.PersonPhone()
            {
                IdPhoneNumberType = personPhoneVO.idPhoneNumberType,
                PhoneNumber = personPhoneVO.phoneNumber
            };

            _uow.PersonPhonesRepositorio.Adicionar(persoPhone);
            _uow.Commit();

            return new Tuple<bool, string>(true, "ok");
        }

        public Tuple<bool, string> Atualizar(PersonPhoneVO personPhoneVO)
        {
            var personPhone = _uow.PersonPhonesRepositorio.GetByID(personPhoneVO.id);
            if (personPhone != null)
            {

                if (ValidarSeNumeroExiste(personPhoneVO.phoneNumber,personPhone.Id))
                    return new Tuple<bool, string>(false, "Já existe esse telefone na base");

                personPhone.PhoneNumber = personPhoneVO.phoneNumber;
                personPhone.IdPhoneNumberType = personPhoneVO.idPhoneNumberType;
                _uow.PersonPhonesRepositorio.Atualizar(personPhone);
                _uow.Commit();
                return new Tuple<bool, string>(true, "ok");
            }
            else
                return new Tuple<bool, string>(false, "Id não existe na base");
        }

        public IEnumerable<PersonPhoneVO> GetAll()
        {
            var lista = _uow.PersonPhonesRepositorio.GetAll().ToList();
            var listaVO = _mapper.Map<List<Models.PersonPhone>, List<PersonPhoneVO>>(lista);
            return listaVO;
        }

        public PersonPhoneVO GetByID(int id)
        {
            var personPhone = _uow.PersonPhonesRepositorio.GetByID(id);
            return _mapper.Map<Models.PersonPhone, PersonPhoneVO>(personPhone);
        }

        public Tuple<bool, string> Remover(int id)
        {
            //Verificar se existe na base 
            var personPhone = _uow.PersonPhonesRepositorio.GetByID(id);
            if (personPhone != null)
            {
                _uow.PersonPhonesRepositorio.Deletar(personPhone);
                _uow.Commit();
                return new Tuple<bool, string>(true, "ok");
            }
            else
                return new Tuple<bool, string>(false, "Id não existe na base");
        }

        private bool ValidarSeNumeroExiste(string numberPhone, int id = -1)
        {
            //Desconsiderar o id passado na consulta
            if (id != -1)
                return _uow.PersonPhonesRepositorio.GetAll(x => x.PhoneNumber == numberPhone && x.Id != id).Count() > 0;
            else
                return _uow.PersonPhonesRepositorio.GetAll(x => x.PhoneNumber == numberPhone).Count() > 0;
        }
    }


}
