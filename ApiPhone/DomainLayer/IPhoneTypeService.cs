using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DomainLayer
{
   public interface IPhoneTypeService
    {
        IEnumerable<Models.VO.PhoneNumberTypeVO> GetAll();
    }
}
