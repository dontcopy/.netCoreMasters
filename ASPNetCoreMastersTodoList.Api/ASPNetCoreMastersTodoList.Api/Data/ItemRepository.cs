using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public class ItemRepository : IItemRepository
    {
        public ItemRepository()
        {
            //add context
        }

        public void Delete(int itemId)
        {
            try
            {
                new ItemServices().Delete(itemId);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<string> GetAll(int userId)
        {
            try
            {
                return new ItemServices().GetAll(userId);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
            return new ItemServices().GetAllItems();
        }

        public IEnumerable<ItemDTO> GetAllItemsFilterBy(string filter)
        {
            return new ItemServices().GetAllItems();
        }

        public ItemDTO GetItem(int itemId)
        {
            return new ItemServices().GetItem(itemId);
        }

        public void Upsert(ItemDTO item)
        {
            new ItemServices().Upsert(item);
        }

    }
}
