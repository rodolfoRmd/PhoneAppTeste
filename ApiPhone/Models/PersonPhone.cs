using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.Models
{
    public class PersonPhone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int IdPhoneNumberType { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
