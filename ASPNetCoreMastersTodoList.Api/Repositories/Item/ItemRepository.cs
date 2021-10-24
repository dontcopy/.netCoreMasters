using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Item
{
    public class ItemRepository : IItemRepository
    {
        private DataContext _context;
        public void LoadContext(DataContext context) ///should be ctor
        {
            _context = context;
        }
        public IQueryable<DomainModels.Item> All()
        {
            return _context.Items.AsQueryable();
        }

        public void Delete(int id)
        {
            _context.Items.RemoveAll(x => x.ItemId == id);
        }

        public void Save(DomainModels.Item item)
        {
            if(_context.Items.Exists(x=>x.ItemId==item.ItemId))
            {
                _context.Items.RemoveAll(x => x.ItemId == item.ItemId);
            }

            _context.Items.Add(item);
        }
    }
}
