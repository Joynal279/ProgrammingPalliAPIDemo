using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingPalliAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet]
        public string GetName()
        {
            return "Joynal";
        }

        [HttpGet]
        public string GetFullName()
        {
            return "Joynal Abedin";
        }

        [HttpGet]
        public string CountryName()
        {
            return "Bangladesh";
        }
    }
}
