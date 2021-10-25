using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class DataContext
    {

        public  DataContext()
        {
            Items = GenerateDummyData().ToList();
        }
        public List<DomainModels.Item> Items { get; set; }


        private static Random random = new Random();
        private static IList<DomainModels.Item> GenerateDummyData()
        {
            var result = new List<DomainModels.Item>();
            var size = random.Next(5, 100);
            for (int i = size - 1; i >= 0; i--)
            {
                result.Add(new DomainModels.Item()
                {
                    ItemId = i,
                    Text = RandomString(random.Next(5, 10)),
                    CreatedBy = RandomString(random.Next(8, 10)),
                    DateCreated = DateTime.Now
                }) ;
            }

            return result.OrderBy(x => x.ItemId).ToList();

        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
