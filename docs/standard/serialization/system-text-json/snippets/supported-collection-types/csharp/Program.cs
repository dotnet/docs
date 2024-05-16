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
            Console.WriteLine("\n============================= Serialize\n");
            await IAsyncEnumerableSerialize.Program.Main();
            Console.WriteLine("\n============================= Deserialize\n");
            await IAsyncEnumerableDeserialize.Program.Main();
            Console.WriteLine("\n============================= DeserializeNonStreaming\n");
            await IAsyncEnumerableDeserializeNonStreaming.Program.Main();
        }
    }
}
