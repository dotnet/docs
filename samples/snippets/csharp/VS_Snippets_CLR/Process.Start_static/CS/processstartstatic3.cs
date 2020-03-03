// Place this code into a console project called ArgsEcho to build the argsecho.exe target

using System;

namespace StartArgs
{
    class ArgsEcho
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Received the following arguments:\n");

            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"[{i}] = {args[i]}");
            }

            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
