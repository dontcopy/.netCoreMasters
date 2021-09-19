using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data
{
    public interface IItemRepository
    {
        public int GetAll(int userId);
        public void Save(ItemDTO item);
    }
}
