
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ItemServices
    {
        private static Random random = new Random();
        public IEnumerable<String> GetAll(int userId)
        {
            var size = random.Next(5, 100);
            var result = new String[size];
            
            for(int ctr=0;  ctr<result.Length; ctr++)
            {
                result[ctr] = RandomString(random.Next(5, 10));
            }
            return result;
        }

        public bool Upsert(ItemDTO item)
        {
            //map w/o automapper
            var itemDomain = new DomainModels.Item()
            {
                Text = item.Text
            };
          

            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }


        public IList<ItemDTO> GetAllItems()
        {
            return GenerateDummyData();
        }

        public IList<ItemDTO> GetAllItemsFilterBy(string filter)
        {
            return GenerateDummyData().Where(x => x.Text.Contains(filter)).ToList();
        }

        public ItemDTO GetItem(int id)
        {
            var Items = GenerateDummyData();
            return Items.FirstOrDefault(x => x.ItemId == id);
        }

        private static IList<ItemDTO> GenerateDummyData()
        {
            var result = new List<ItemDTO>();
            var size = random.Next(5, 100);
            for (int i = size - 1; i >= 0; i--)
            {
                result.Add(new ItemDTO() { ItemId = i, Text = RandomString(random.Next(5, 10)) });
            }

            return result.OrderBy(x=>x.ItemId).ToList();

        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
