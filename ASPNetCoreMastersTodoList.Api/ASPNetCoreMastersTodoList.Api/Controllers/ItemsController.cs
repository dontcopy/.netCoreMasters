using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Data;
using ASPNetCoreMastersTodoList.Api.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.ItemService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [ItemExistingFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemService _svc;
        private readonly IMapper _mapper;
        public ItemsController(IItemService svc, IMapper mapper)
        {
            _svc = svc;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ItemFetchApiModel>> GetItems()
        {
            var items = _svc.GetAll();
            return Ok(_mapper.Map<IEnumerable<ItemFetchApiModel>>(items));
        }

        [HttpGet("{itemId}")]
        public ActionResult<ItemFetchApiModel> GetItem(int itemId)
        {
            var item = _svc.Get(itemId);
            if(item == null)
                return NotFound();
            return Ok(_mapper.Map<ItemFetchApiModel>(item));
        }

        [HttpGet]
        [Route("filterBy")]
        public ActionResult<IEnumerable<ItemFetchApiModel>> GetItems([FromQuery]Dictionary<string,string> filters)
        {
            var items = _svc.GetAllByFilter(new ItemByFilterDTO()
            {
                filters = filters
            }); ;
            return Ok(_mapper.Map<IEnumerable<ItemFetchApiModel>>(items));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ItemCreateApiModel item)
        {
            _svc.Add(_mapper.Map<ItemDTO>(item));
            return Ok();
        }

        [HttpPut("{itemId}")]
        public ActionResult Put(int itemId, [FromBody] ItemUpdateApiModel itemUpdate)
        {
            var item = _svc.Get(itemId);
            if (item == null)
                return NotFound();
            var toUpdate = _mapper.Map<ItemDTO>(itemUpdate);
            toUpdate.ItemId = item.ItemId;
            _svc.Update(toUpdate);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        public ActionResult Delete(int itemid)
        {
            _svc.Delete(itemid);
            return Ok();
        }
    }
}
