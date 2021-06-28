using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IAsyncEnumerableDeserializeNonStreaming
{
    public class MyPoco
    {
        public IAsyncEnumerable<int> Data { get; set; }
    }

    public class Program
    {
        public static async Task Main()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"{""Data"":[0,1,2,3,4]}"));
            var result = await JsonSerializer.DeserializeAsync<MyPoco>(stream);
            await foreach (int item in result.Data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
// output:
//0
//1
//2
//3
//4
