using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ItemService
{
    public interface IItemService
    {
        public void Update(ItemDTO item);

        public void Add(ItemDTO item);

        public void Delete(int itemId);

        public IEnumerable<ItemDTO> GetAll();
        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);
        public ItemDTO Get(int itemId);
    }
}
