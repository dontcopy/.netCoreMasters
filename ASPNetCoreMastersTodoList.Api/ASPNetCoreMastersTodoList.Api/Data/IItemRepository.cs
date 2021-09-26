using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public interface IItemRepository
    {
        public void Upsert(ItemDTO item);

        public void Delete(int itemId);

        public IEnumerable<ItemDTO> GetAllItems();
        public IEnumerable<ItemDTO> GetAllItemsFilterBy(string filter);
        public ItemDTO GetItem(int itemId);

    }
}
