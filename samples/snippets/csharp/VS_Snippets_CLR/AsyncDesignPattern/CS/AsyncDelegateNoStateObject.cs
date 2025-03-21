// <Snippet4>
/*
The following example demonstrates using asynchronous methods to
get Domain Name System information for the specified host computers.
This example uses a delegate to obtain the results of each asynchronous
operation.
*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;

namespace Examples.AdvancedProgramming.AsynchronousOperations
{
    public class UseDelegateForAsyncCallback
    {
        static int requestCounter;
        static ArrayList hostData = new ArrayList();
        static StringCollection hostNames = new StringCollection();
        static void UpdateUserInterface()
        {
            // Print a message to indicate that the application
            // is still working on the remaining requests.
            Console.WriteLine($"{requestCounter} requests remaining.");
        }
        public static void Main()
        {
            // Create the delegate that will process the results of the
            // asynchronous request.
            AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation);
            string host;
            do
            {
                Console.Write(" Enter the name of a host computer or <enter> to finish: ");
                host = Console.ReadLine();
                if (host.Length > 0)
                {
                    // Increment the request counter in a thread safe manner.
                    Interlocked.Increment(ref requestCounter);
                    // Start the asynchronous request for DNS information.
                    Dns.BeginGetHostEntry(host, callBack, host);
                 }
            } while (host.Length > 0);
            // The user has entered all of the host names for lookup.
            // Now wait until the threads complete.
            while (requestCounter > 0)
            {
                UpdateUserInterface();
            }
            // Display the results.
            for (int i = 0; i< hostNames.Count; i++)
            {
                object data = hostData [i];
                string message = data as string;
                // A SocketException was thrown.
                if (message != null)
                {
                    Console.WriteLine($"Request for {hostNames[i]} returned message: {message}");
                    continue;
                }
                // Get the results.
                IPHostEntry h = (IPHostEntry) data;
                string[] aliases = h.Aliases;
                IPAddress[] addresses = h.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine($"Aliases for {hostNames[i]}");
                    for (int j = 0; j < aliases.Length; j++)
                    {
                        Console.WriteLine($"{aliases[j]}");
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine($"Addresses for {hostNames[i]}");
                    for (int k = 0; k < addresses.Length; k++)
                    {
                        Console.WriteLine("{0}",addresses[k].ToString());
                    }
                }
            }
       }

        // The following method is called when each asynchronous operation completes.
        static void ProcessDnsInformation(IAsyncResult result)
        {
            string hostName = (string) result.AsyncState;
            hostNames.Add(hostName);
            try
            {
                // Get the results.
                IPHostEntry host = Dns.EndGetHostEntry(result);
                hostData.Add(host);
            }
            // Store the exception message.
            catch (SocketException e)
            {
                hostData.Add(e.Message);
            }
            finally
            {
                // Decrement the request counter in a thread-safe manner.
                Interlocked.Decrement(ref requestCounter);
            }
        }
    }
}
//</Snippet4>
