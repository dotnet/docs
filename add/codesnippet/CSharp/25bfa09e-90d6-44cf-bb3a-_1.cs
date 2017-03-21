        // Registering Notepad.exe as a collab application with a fixed GUID.
        // Note: If you're using the application to send invitations,
        // the same application with the same GUID must be registered on the remote peer machine.
        private static PeerApplication RegisterCollabApp()
        {
            PeerApplication application = null;
            string pathToApp = "%SystemRoot%\\notepad.exe";
            Guid appGuid = new Guid(0xAAAAAAAA, 0xFADE, 0xDEAF, 0xBE, 0xEF, 0xFF, 0xEE, 0xDD, 0xCC, 0xBB, 0xAE);

            application = new PeerApplication();
            application.Id = appGuid;
            application.Path = pathToApp;
            application.Description = "Peer Collaboration Sample -- notepad.exe";
            application.PeerScope = PeerScope.All;
            application.CommandLineArgs = "n";
            application.Data = ASCIIEncoding.ASCII.GetBytes("Test");

            Console.WriteLine("Attempting to register the application \"notepad.exe\"...");
            try
            {

                PeerApplicationCollection pac = PeerCollaboration.GetLocalRegisteredApplications(PeerApplicationRegistrationType.AllUsers);
                if (pac.Contains(application))
                {
                    Console.WriteLine("The application is already registered on the peer.");
                }
                else
                {
                    PeerCollaboration.RegisterApplication(application, PeerApplicationRegistrationType.AllUsers);
                    Console.WriteLine("Application registration succeeded!");
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("The application was previously registered with the Peer Collaboration Infrastructure: {0}.", argEx.Message);
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The application failed to register with the Peer Collaboration Infrastructure: {0}", p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected exception occurred when trying to register the application: {0}.", ex.Message);
            }
            return application;
        }