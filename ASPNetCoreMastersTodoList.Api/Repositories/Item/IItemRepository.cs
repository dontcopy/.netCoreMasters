using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Item
{
    public interface IItemRepository
    {
        public IQueryable<DomainModels.Item> All();
        public void Save(DomainModels.Item item);
        public void Delete(int id);

        public void LoadContext(DataContext context);
    }
}
