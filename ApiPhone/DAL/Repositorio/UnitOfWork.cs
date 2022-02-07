using ApiPhone.DAL.Contexto;
using ApiPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContexto _contextPhone;
        private IRepositorio<Models.PersonPhone> _personPhonesRepositorio = null;
        private IRepositorio<Models.PhoneNumberType> _phoneNumberTypesRepositorio = null;


        public UnitOfWork(IContexto contexto)
        {
            _contextPhone = contexto;
        }

        public IRepositorio<PersonPhone> PersonPhonesRepositorio
        {
            get
            {
                if (_personPhonesRepositorio == null)
                    _personPhonesRepositorio = new Repositorio<PersonPhone>(_contextPhone);
                return _personPhonesRepositorio;
            }
        }


        public IRepositorio<PhoneNumberType> PhoneNumberTypesRepositorio
        {
            get
            {
                if (_phoneNumberTypesRepositorio == null)
                    _phoneNumberTypesRepositorio = new Repositorio<PhoneNumberType>(_contextPhone);
                return _phoneNumberTypesRepositorio;
            }
        }

        public bool Commit()
        {
            try
            {
                _contextPhone.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }



       
    }
}
