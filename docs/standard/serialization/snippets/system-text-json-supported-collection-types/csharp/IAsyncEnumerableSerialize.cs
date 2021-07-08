using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace IAsyncEnumerableSerialize
{
    public class Program
    {
        public static async Task Main()
        {
            using Stream stream = Console.OpenStandardOutput();
            var data = new { Data = PrintNumbers(3) };
            await JsonSerializer.SerializeAsync(stream, data);
        }

        static async IAsyncEnumerable<int> PrintNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
// output:
//  {"Data":[0,1,2]}
