using ApiPhone.DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPhone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneTypeController : ControllerBase
    {
        private readonly IPhoneTypeService _phoneTypeService;
        public PhoneTypeController(IPhoneTypeService phoneTypeService)
        {
            _phoneTypeService = phoneTypeService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_phoneTypeService.GetAll());
        }

    }
}
