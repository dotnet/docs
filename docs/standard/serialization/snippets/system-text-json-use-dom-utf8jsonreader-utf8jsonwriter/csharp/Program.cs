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
            Console.WriteLine("\n============================= JsonNode example\n");
            JsonNodeExample.Program.Main();
            Console.WriteLine("\n============================= JsonNode POCO example\n");
            JsonNodePOCOExample.Program.Main();
            Console.WriteLine("\n============================= JsonNode Average Grades example\n");
            JsonNodeAverageGradeExample.Program.Main();
        }
    }
}
