﻿using AutoMapper;
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
        public ItemService(IItemRepository repository, IMapper mapper,DataContext dataContext)
        {
            _repository = repository;
            _repository.LoadContext(dataContext);
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
            var filterItems = new List<ItemDTO>();
            try
            {
                var items = _mapper.Map<IEnumerable<ItemDTO>>(_repository.All());
                
                //dummy filter implementation
                foreach (var filter in filters.filters)
                {
                    filterItems.Add(items.FirstOrDefault(x => x.ItemId == Convert.ToInt32(filter.Key)));
                }
                foreach (var filter in filters.filters)
                {
                   var item=filterItems.FirstOrDefault(x => x.ItemId == Convert.ToInt32(filter.Key));
                   if (item != null&&item.Text != filter.Value)
                        filterItems.Remove(item);
                }

            }
            catch(Exception ex)
            { 
                //// do something
                throw (ex); }
            return filterItems;
        }
    

        public void Update(ItemDTO item)
        {
            _repository.Save(_mapper.Map<Item>(item));
        }
    }
}
