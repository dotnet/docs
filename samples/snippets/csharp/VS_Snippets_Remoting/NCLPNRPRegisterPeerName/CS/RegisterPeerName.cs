// RegisterPeerName.cs
//
// Description:
//
//    This sample illustrates how to to create a Peer Name, associate metadata with the PeerName
//    via a PeerNameRegistration object and register a PeerName in a cloud.  Once the PeerName is registered, 
//    it can be resolved by remote peers, thereby retreiving the data associated with the PeerName. 
//
// Command Line Options:
//
//    All command line arguments are required:
//    Usage: RegisterPeerName.exe <Peer Name Classifier> <PeerNameType:Secured|UnSecured> <Port #> <Comment> <Cloud Name:Available|AllLinkLocal|Global> 
//
//    Example: RegisterPeerName.exe MyComputer Secured 8000 MyComment Available


using System;
using System.Collections.Generic;
using System.Text;
using System.Net.PeerToPeer;

namespace PNRPSample
{
    class RegisterPeerName
    {
        static string peerNameClassifier = String.Empty;        // command line argument: args[0]
        static PeerNameType peerNameType = (PeerNameType)(-1);  // command line argument: args[1]
        static int portNumber = -1;                             // command line argument: args[2]
        static string comment = string.Empty;                   // command line argument: args[3]
        static Cloud cloudName = null;                          // command line argument: args[4]
        
        static void Main(string[] args)
        {
            // parse the command line arguments
            bool success = ParseCommandLine(args);
            if (success)
            {
                CreateAndPublishPeerName();
            }
        }

        //<Snippet1>
        // Creates a PeerName and registers it along with the metadata specified 
        // The parameters used to register the name are static types that are set 
        // from user input (command-line or user dialog).
        // These parameters include the following:
        //   static String peerName
        //   static PeerNameType peerNameType
        //   static int portNumber
        //   static String comment
        //   static Cloud cloudName 

        public static void CreateAndPublishPeerName()
        {
            try{
                // Creates a the PeerName to register using the classifier and type provided 
                PeerName peerName = new PeerName(peerNameClassifier, peerNameType);

                // Create a registration object which represents the registration 
                // of the PeerName in a Cloud
                PeerNameRegistration peerNameRegistration = new PeerNameRegistration();
                peerNameRegistration.PeerName = peerName;
                peerNameRegistration.Port = portNumber;
                peerNameRegistration.Comment = comment;
                peerNameRegistration.Cloud = cloudName;
                // Since the peerNameRegistration.EndPointCollection is not specified, 
                // all (IPv4&IPv6) addresses assigned to the local host will 
                // automatically be associated with the peerNameRegistration instance. 
                // This behavior can be control using peerNameRegistration.UseAutoEndPointSelection
                
                //Note: Additional information may be specified on the PeerNameRegistration 
                // object, which is not shown in this example.

                // Starting the registration means the name is published for 
                // other peers to resolve
                peerNameRegistration.Start();
                Console.WriteLine("Registration of Peer Name: {0} complete.", peerName.ToString(), cloudName);
                Console.WriteLine();

                Console.WriteLine("Press any key to stop the registration and close the program");
                Console.ReadKey();

                // Stopping the registration means the name is no longer published
                peerNameRegistration.Stop();
            } catch(Exception e){
                Console.WriteLine("Error creating and registering the PeerName: {0} \n", e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        //</Snippet1>

        /// <summary>
        /// Parse the command line arguments
        /// </summary>
                private static bool ParseCommandLine(string[] args)
        {
            //Command line format:
            const string usage = "Usage: RegisterPeerName.exe <Peer Name Classifier> <PeerNameType:Secured|UnSecured> <Port #> <Comment> <Cloud Name:Available|AllLinkLocal|Global>";

            try
            {
                if (args.Length < 5)
                {
                    Console.WriteLine(usage);
                    return false;
                }

                peerNameClassifier = args[0];

                //Create a secure or unsecure PeerName using the command line arguments: <PeerNameClassifier> and <PeerNameType:Secured|UnSecured>
                string peerNameTypeArgument = args[1].ToLower();
                if (peerNameTypeArgument.Equals("secured"))
                {
                    peerNameType = PeerNameType.Secured;
                }
                else if (peerNameTypeArgument.Equals("unsecured"))
                {
                    peerNameType = PeerNameType.Unsecured;
                }
                else
                {
                    Console.WriteLine("PeerNameType argument is invalid.\n");
                    Console.WriteLine(usage);
                    return false;
                }

                // read the port number
                portNumber = int.Parse(args[2]);
                
                // read the commment to assign to the peername
                comment = args[3];

                // determine the cloud to register the peername into
                string cloudNameArgument = args[4].ToLower();
                if (cloudNameArgument.Equals("available"))
                {
                    cloudName = Cloud.Available;
                }
                else if (cloudNameArgument.Equals("alllinklocal"))
                {
                    cloudName = Cloud.AllLinkLocal;
                }
                else if (cloudNameArgument.Equals("global"))
                {
                    cloudName = Cloud.Global;
                }
                else
                {
                    Console.WriteLine("Cloud Name argument is invalid.\n");
                    Console.WriteLine(usage);
                    return false;
                }
            }
            catch (Exception e)
            {
                // P2P is not supported on Windows Server 2003
                if (e.InnerException != null)
                { 
                    Console.WriteLine("Error occured while attempting to register the PeerName: {0}", e.Message);
                    Console.WriteLine(e.StackTrace);

                    Console.WriteLine("Inner Exception is {0}", e.InnerException);
                }    
                else 
                {
                    Console.WriteLine("Error occured while attempting to register the PeerName: {0}", e.Message);
                    Console.WriteLine(usage);

                    Console.WriteLine("Exception is {0}", e);
                    Console.WriteLine(e.StackTrace);
                }    
                return false;
            }
            return true;
        }

    }
}
