//<Snippet3>
/*
The following example demonstrates using asynchronous methods to
get Domain Name System information for the specified host computer.
This example polls to detect the end of the asynchronous operation.
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class PollUntilOperationCompletes
    {
        static void UpdateUserInterface()
        {
            // Print a period to indicate that the application
            // is still working on the request.
            Console.Write(".");
        }
        public static void Main(string[] args)
        {
            // Make sure the caller supplied a host name.
            if (args.Length == 0 || args[0].Length == 0)
            {
                // Print a message and exit.
                Console.WriteLine("You must specify the name of a host computer.");
                return;
            }
            // Start the asynchronous request for DNS information.
            IAsyncResult result = Dns.BeginGetHostEntry(args[0], null, null);
            Console.WriteLine("Processing request for information...");

            // Poll for completion information.
            // Print periods (".") until the operation completes.
            while (result.IsCompleted != true)
            {
                UpdateUserInterface();
            }
            // The operation is complete. Process the results.
            // Print a new line.
            Console.WriteLine();
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        Console.WriteLine("{0}", aliases[i]);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        Console.WriteLine("{0}",addresses[i].ToString());
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message);
            }
        }
    }
}
//</Snippet3>