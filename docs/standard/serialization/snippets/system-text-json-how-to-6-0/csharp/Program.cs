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
            Console.WriteLine("\n============================= Serialize and IgnoreCycles\n");
            SerializeIgnoreCycles.Program.Main();
            Console.WriteLine("\n============================= Callbacks / Notifications\n");
            Callbacks.Program.Main();
            Console.WriteLine("\n============================= Set property order\n");
            PropertyOrder.Program.Main();
        }
    }
}
