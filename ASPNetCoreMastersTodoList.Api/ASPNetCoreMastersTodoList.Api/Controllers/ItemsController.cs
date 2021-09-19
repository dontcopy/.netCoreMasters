using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.Api.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemRepository _repository;
        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }
        

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {
            return _repository.GetAll(id);
        }

        
    }
}
