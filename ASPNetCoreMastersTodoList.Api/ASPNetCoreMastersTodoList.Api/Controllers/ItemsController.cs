using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Authentication;
using ASPNetCoreMastersTodoList.Api.Data;
using ASPNetCoreMastersTodoList.Api.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.ItemService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Authorize]
    [ItemExistingFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _svc;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authService​;
        public ItemsController(IItemService svc, IMapper mapper, UserManager<AppUser> userManager, IAuthorizationService authService)
        {
            _userManager = userManager;
            _svc = svc;
            _mapper = mapper;
            _authService = authService;
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
            var newItem = _mapper.Map<ItemDTO>(item);
            newItem.CreatedBy = User.Identity.Name;
            newItem.DateCreated = DateTime.Now;
            newItem.ItemId = _svc.GetAll().Count(); //should be replace by autoseed //for demo only
            _svc.Add(newItem);
            return Ok();
        }

        [HttpPut("{itemId}")]
        public async Task<ActionResult> PutAsync(int itemId, [FromBody] ItemUpdateApiModel itemUpdate)
        {
            var item = _svc.Get(itemId);
            if (item == null)
                return NotFound();
            var authResult = await _authService.AuthorizeAsync(User, item, "canEditItem");
            if (!authResult.Succeeded)
                return StatusCode(401);
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
