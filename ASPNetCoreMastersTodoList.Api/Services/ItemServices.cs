
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

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
