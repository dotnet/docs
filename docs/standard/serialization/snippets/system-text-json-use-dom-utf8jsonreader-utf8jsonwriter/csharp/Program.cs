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
            Console.WriteLine("\n============================= From string example\n");
            JsonNodeFromStringExample.Program.Main();
            Console.WriteLine("\n============================= From object example\n");
            JsonNodeFromObjectExample.Program.Main();
            Console.WriteLine("\n============================= POCO example\n");
            JsonNodePOCOExample.Program.Main();
            Console.WriteLine("\n============================= Average Grades example\n");
            JsonNodeAverageGradeExample.Program.Main();
            Console.WriteLine("\n============================= Write raw JSON\n");
            WriteRawJson.Program.Main();
        }
    }
}
