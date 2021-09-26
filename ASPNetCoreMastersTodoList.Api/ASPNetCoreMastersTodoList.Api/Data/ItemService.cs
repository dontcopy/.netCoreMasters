using AutoMapper;
using DomainModels;
using Repositories;
using Repositories.Item;
using Services.DTO;
using Services.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public class ItemService : IItemService
    {
        private IItemRepository _repository;
        private readonly IMapper _mapper;
        public ItemService(DataContext context,IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _repository.LoadContext(context);
            _mapper = mapper;
        }
        public void Add(ItemDTO item)
        {
            _repository.Save(_mapper.Map<Item>(item));
        }

        public void Delete(int itemId)
        {
            _repository.Delete(itemId);
        }

        public ItemDTO Get(int itemId)
        {
            return _mapper.Map<IEnumerable<ItemDTO>>(_repository.All()).FirstOrDefault(x=>x.ItemId==itemId);
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ItemDTO>>(_repository.All());
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            //not enough info on ItemByFilterDto
            return _mapper.Map<IEnumerable<ItemDTO>>(_repository.All());
        }

        public void Update(ItemDTO item)
        {
            _repository.Save(_mapper.Map<Item>(item));
        }
    }
}
