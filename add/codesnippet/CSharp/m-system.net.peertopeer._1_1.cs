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