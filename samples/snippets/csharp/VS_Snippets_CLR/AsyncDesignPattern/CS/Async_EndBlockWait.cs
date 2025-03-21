// <Snippet2>
/*
The following example demonstrates using asynchronous methods to
get Domain Name System information for the specified host computer.

*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class WaitUntilOperationCompletes
    {
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
            // Wait until the operation completes.
            result.AsyncWaitHandle.WaitOne();
            // The operation completed. Process the results.
            try
            {
                // Get the results.
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        Console.WriteLine($"{aliases[i]}");
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
                Console.WriteLine($"Exception occurred while processing the request: {e.Message}");
            }
        }
    }
}
// </Snippet2>