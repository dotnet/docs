//<snippet01>
using System;
using System.IO;
using System.IO.Pipes;

class PipeClient
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            using (PipeStream pipeClient =
                new AnonymousPipeClientStream(args[0]))
            {

                Console.WriteLine("Current TransmissionMode: {0}.",
                   pipeClient.TransmissionMode);

                // Anonymous Pipes do not support Message mode.
                try
                {
                    Console.WriteLine("Setting ReadMode to \"Message\".");
                    pipeClient.ReadMode = PipeTransmissionMode.Message;
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("EXCEPTION: {0}", e.Message);
                }

                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    // Display the read text to the console
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(temp);
                    }
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}
//</snippet01>
