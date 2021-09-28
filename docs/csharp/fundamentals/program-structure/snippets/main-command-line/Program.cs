using System;

namespace main_command_line
{
    class Program
    {
        static int Main(string[] args)
        {
            //<Snippet4>
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return 1;
            }
            //</Snippet4>

            return 0;
        }
    }
}

