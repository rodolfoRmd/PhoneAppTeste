using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DAL.Repositorio
{
   public  interface IUnitOfWork
    {
        IRepositorio<Models.PersonPhone> PersonPhonesRepositorio { get; }
        IRepositorio<Models.PhoneNumberType> PhoneNumberTypesRepositorio { get; }
        bool Commit();
       
    }
}
