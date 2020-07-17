using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            using (HelloClient client = new HelloClient())
            {
                string s = client.SayHello("Frodo");
                Console.WriteLine(s);
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client");
            Console.ReadLine();
        }
    }
}
