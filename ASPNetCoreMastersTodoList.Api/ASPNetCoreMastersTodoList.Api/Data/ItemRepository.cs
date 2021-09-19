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

        public void Save(ItemDTO item)
        {
            new ItemServices().Save(item);
            //Not enough info
        }

        int IItemRepository.GetAll(int userId)
        {
            //No implementation specified
            throw new NotImplementedException();
        }
    }
}
