// Module Name: PeerNameResolver.cs
//
// Description:
//
//    This sample illustrates how to resolve a Peer Name published in any Cloud.  The application accepts a Peer Name
//    in the forum Authority.Classifier as the only command line arugment to the application and attempts to 
//    synchronously resolve the Peer Name.  If the PeerName is successfully resolved, the data associated with the 
//    Peer Name is printed out. 
//
// Compile:
//
//    csc /reference:c:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Net.dll
//        /out:PeerNameResolver.exe PeerNameResolver.cs 
//
// Command Line Options:
//
//    All command line arguments are required:
//    Usage: PeerNameResolver.exe <PeerName:Authority.Classifier> 

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.PeerToPeer;
using System.Net;

namespace PNRPSample
{
    class Program
    {
        //<Snippet1>
        static void Main(string[] args)
        {
            try
            {

                if (args.Length != 1)
                {
                    Console.WriteLine("Usage: PeerNameResolver.exe <PeerNameToResolve>");
                    return;
                }
                
                // create a resolver object to resolve a Peer Name that was previously published
                PeerNameResolver resolver = new PeerNameResolver();
                // The Peer Name to resolve must be passed as the first 
                // command line argument to the application
                PeerName peerName = new PeerName(args[0]);
                // Resolve the Peer Name 
                // This is a network operation and will block until the resolve completes
                PeerNameRecordCollection results = resolver.Resolve(peerName);

                // Display the data returned by the resolve operation
                Console.WriteLine("Resolve operation complete.\n", peerName);
                Console.WriteLine("Results for PeerName: {0}", peerName);
                Console.WriteLine();
                
                int count = 1;
                foreach (PeerNameRecord record in results)
                {
                    Console.WriteLine("Record #{0} results...", count);
                    
                    Console.Write("Comment:");
                    if (record.Comment != null)
                    {
                        Console.Write(record.Comment);
                    }
                    Console.WriteLine();

                    Console.Write("Data:");
                    if (record.Data != null)
                    {
                        // Assumes the data blob associated with the PeerName 
                        // is made up of ASCII characters
                        Console.Write(System.Text.Encoding.ASCII.GetString(record.Data));
                    }
                    Console.WriteLine();

                    Console.WriteLine("Endpoints:");
                    foreach (IPEndPoint endpoint in record.EndPointCollection)
                    {
                        Console.WriteLine("\t Endpoint:{0}", endpoint);
                        Console.WriteLine();
                    }

                    count++;
                }

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured while attempting to resolve the PeerName: {0}", e.Message);
                Console.WriteLine(e.StackTrace);

                // P2P is not supported on Windows Server 2003
                if (e.InnerException != null)
                { 
                    Console.WriteLine("Inner Exception is {0}", e.InnerException);
                }    
            }
        }
        //</Snippet1>

    }
}
