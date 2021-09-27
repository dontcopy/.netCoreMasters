using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemRepository _repository;
        private readonly IMapper _mapper;
        public ItemsController(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ItemFetchApiModel>> GetItems()
        {
            var items = _repository.GetAllItems();
            return Ok(_mapper.Map<IEnumerable<ItemFetchApiModel>>(items));
        }

        [HttpGet("{itemId}")]
        public ActionResult<ItemFetchApiModel> GetItem(int itemId)
        {
            var item = _repository.GetItem(itemId);
            if(item == null)
                return NotFound();
            return Ok(_mapper.Map<ItemFetchApiModel>(item));
        }

        [HttpGet]
        [Route("filterBy")]
        public ActionResult<IEnumerable<ItemFetchApiModel>> GetItems([FromQuery]Dictionary<string,string> filters)
        {
            var items = _repository.GetAllItems();
            return Ok(_mapper.Map<IEnumerable<ItemFetchApiModel>>(items));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ItemCreateApiModel item)
        {
            _repository.Upsert(_mapper.Map<ItemDTO>(item));
            return Ok();
        }

        [HttpPut("{itemId}")]
        public ActionResult Put(int itemId, [FromBody] ItemUpdateApiModel item)
        {
            // item model already has the itemId
            _repository.Upsert(_mapper.Map<ItemDTO>(item));
            return Ok();
        }

        [HttpDelete("{itemId}")]
        public ActionResult Delete(int itemid)
        {
            _repository.Delete(itemid);
            return Ok();
        }
    }
}
