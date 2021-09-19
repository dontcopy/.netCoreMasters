using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
   
    public class ErrorController : ControllerBase
    {


        // GET api/<ErrorController>/5
        [Route("/error")]
        public IActionResult Get()
        {
            return this.Problem();
        }

        
    }
}
