using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SystemTextJsonSamples
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\n============================= BothModesNoOptions\n");
            BothModesNoOptions.Program.Main();
            Console.WriteLine("\n============================= SerializeOnlyNoOptions\n");
            SerializeOnlyNoOptions.Program.Main();
            Console.WriteLine("\n============================= MetadataOnlyNoOptions\n");
            MetadataOnlyNoOptions.Program.Main();
            Console.WriteLine("\n============================= SerializeOnlyWithOptions\n");
            SerializeOnlyWithOptions.Program.Main();
            Console.WriteLine("\n============================= JsonSerializerOptionsExample\n");
            JsonSerializerOptionsExample.Program.Main();
        }
    }
}
