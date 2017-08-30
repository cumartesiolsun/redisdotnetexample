using RedisOrnek.Data;
using RedisOrnek.Model;
using System;
using System.Collections.Generic;

namespace RedisOrnek
{
    internal class Program
    {
        private static void Main()
        {
            var mg = new RedisManager(); 
            for (int i = 0; i < 10; i++)
            {
                var model = new TestLoad
                {
                    id = i,
                    guid2 = Guid.NewGuid().ToString("N"),
                    guid3 = Guid.NewGuid().ToString(),
                    guid4 = Guid.NewGuid().ToString("N")
                };
                mg.Set("RedisOrnek", model);
            }

            var results = mg.Get<List<TestLoad>>("RedisOrnek");
            foreach (var item in results)
                Console.WriteLine("id: {0} - guid2: {1}", item.id, item.guid2);

            /*Tüm eklediğimiz datayı çektikten sonra keyi siliyoruz*/
            var result = mg.Remove("RedisOrnek");
            if (result)
                Console.WriteLine("RedisOrnek keyi silindi!");

            Console.WriteLine("Bitti...");
            Console.ReadKey();
        } 
    }
}