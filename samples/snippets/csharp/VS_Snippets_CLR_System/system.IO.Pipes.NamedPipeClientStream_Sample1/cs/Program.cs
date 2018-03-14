//<snippet01>
using System;
using System.IO;
using System.IO.Pipes;

class PipeClient
{
    static void Main(string[] args)
    {
        using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
        {

            // Connect to the pipe or wait until the pipe is available.
            Console.Write("Attempting to connect to pipe...");
            pipeClient.Connect();

            Console.WriteLine("Connected to pipe.");
            Console.WriteLine("There are currently {0} pipe server instances open.",
               pipeClient.NumberOfServerInstances);
            using (StreamReader sr = new StreamReader(pipeClient))
            {
                // Display the read text to the console
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Received from server: {0}", temp);
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}
//</snippet01>
