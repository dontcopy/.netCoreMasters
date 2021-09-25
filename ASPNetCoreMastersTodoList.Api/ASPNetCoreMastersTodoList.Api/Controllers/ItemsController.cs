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
    
    public class ItemsController : ControllerBase
    {
        private IItemRepository _repository;
        private readonly IMapper _mapper;
        public ItemsController(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

        // GET api/<ItemsController>/5
       
        public int Get(int id)
        {
            //changed to return type to int
            return id;
        }

        public void Post(ItemCreateApiModel item)
        {
            var model = _mapper.Map<ItemDTO>(item);
            _repository.Save(model);
        }
    }
}
