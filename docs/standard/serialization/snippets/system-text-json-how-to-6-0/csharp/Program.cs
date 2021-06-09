using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SystemTextJsonSamples
{
    public class Program
    {
        static async Task Main()
        {
            Console.WriteLine("\n============================= Round trip to JsonElementAndNode\n");
            RoundtripJsonElementAndNode.Program.Main();
        }
    }
}
