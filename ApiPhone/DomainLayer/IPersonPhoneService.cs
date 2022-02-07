using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.DomainLayer
{
    public interface IPersonPhoneService
    {
        IEnumerable<Models.VO.PersonPhoneVO> GetAll();
        Models.VO.PersonPhoneVO GetByID(int id);

        Tuple<bool,string> Atualizar(Models.VO.PersonPhoneVO  personPhoneVO);
        Tuple<bool, string> Adicionar(Models.VO.PersonPhoneVO personPhoneVO);
        Tuple<bool, string> Remover(int id);
    }
}
