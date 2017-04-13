using System;
using System.Collections.Generic;
using System.Text;
using System.Net.PeerToPeer.Collaboration;
using System.Net.PeerToPeer;
using System.Threading;


namespace P2PContacts
{
    class P2PContacts
    {
        static void Main(string[] args)
        {
            // Argument: 1; Value: Number of choice from menu.
            string choice;

            if (args.Length <= 0)
            {
                Console.WriteLine("No arguments entered: P2PContacts.exe <choice_number>.");
                PrintMenu();
                choice = Console.ReadLine();
            }
            else
            {
                choice = args[0];
            }

            //Signing in.
            
            bool tempResult = PeerCollabSignin();

            //Continuously displays the console menu to the user and responds to their requests.
            while (tempResult)
            {   
                switch (choice)
                {
                    case "0":
                        AddContact();
                        break;
                    case "1":
                        RegisterCollabApp();
                        break;
                    case "2":
                        EnumLocalRegisteredApplications();
                        break;
                    case "3":
                        EnumContacts();
                        break;
                    case "4":
                        GiveWatchPermissionsAndStartWatching();
                        break;
                    case "5":
                        DeleteContact();
                        break;
                    case "6":
                        WaitForPresenceChange();
                        break;
                    case "7":
                        GetPresenceInformation();
                        break;
                    case "8":
                        SetPresenceInformation();
                        break;
                    case "9":
                        //Set the temp result to 'false' to break out of loop.                        
                        tempResult = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.\n");
                        break;
                }
                if (tempResult)
                {
                    PrintMenu();
                    choice = Console.ReadLine();
                }
            }

//            Exit;
        }
        
        
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet1>
        //This function signs the users into the Collaboration Infrastructure.
        public static bool PeerCollabSignin()
        {
            bool result = false;
            try
            {
                PeerCollaboration.SignIn(PeerScope.All);
                result = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error signing in: {0}", ex.Message);
            }
            return result;
        }
        // </Snippet1>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------

        //Prints the menu of options to display for the user.
        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("0. Add a contact");
            Console.WriteLine("1. Register collab information");
            Console.WriteLine("2. Enumerate the local registered applications");
            Console.WriteLine("3. Display contacts");
            Console.WriteLine("4. Grant watch permissions to contact, and begin watching contact");
            Console.WriteLine("5. Delete a contact");
            Console.WriteLine("6. Wait for contact presence change");
            Console.WriteLine("7. Get presence information");
            Console.WriteLine("8. Set presence information");
            Console.WriteLine("9. Quit");
            return;
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet2>
        //This function retrieves the peers near me as a PeerNearMeCollection.
        public static PeerNearMeCollection GetPeersNearMe()
        {
            PeerNearMeCollection peers = null;
            try
            {
                peers = PeerCollaboration.GetPeersNearMe();
                if (peers == null ||
                    peers.Count == 0)
                {
                    Console.WriteLine("There are no peers near me.");
                }
                foreach (PeerNearMe pnm in peers)
                {
                    Console.WriteLine("Getting the peers near me: {0}, nickname {1}, isOnline {2}",
                        pnm.ToString(),
                        pnm.Nickname,
                        pnm.IsOnline);
                }
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("Could not obtain an enumeration of the peers near me: {0}", p2pEx.Message);
            }
            catch (InvalidOperationException ioEx)
            {
                Console.WriteLine("The application is no longer signed into the Peer Collaboration Infrastructure: {0}", 
                    ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception caught when trying to enumerate the peers near me: {0}",
                    ex.Message);
            }

            return peers;

        }
        // </Snippet2>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet3>
        // Displays all contacts and asssociated peer endpoints (PeerEndPoint) in the PeerContactCollection.
        private static void DisplayContacts(PeerContactCollection peerContactsCollection)
        {
            if (peerContactsCollection == null ||
                peerContactsCollection.Count == 0)
            {
                Console.WriteLine("No contacts to display. To add a contact select option 0 from the menu.");
            }
            else
            {
                foreach (PeerContact pc in peerContactsCollection)
                {
                    Console.WriteLine("The contact is: {0}", pc.DisplayName);
                    DisplayEndpoints(pc.PeerEndPoints);
                }
            }
            return;
        }
        
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // Displays all peer end points (PeerEndPoint) in the PeerEndPointCollection.
     
        private static void DisplayEndpoints(PeerEndPointCollection endpointCollection)
        {
            if (endpointCollection == null ||  endpointCollection.Count == 0)
                Console.WriteLine("No peer endpoints in the collection to display.");
            else
            {
                foreach (PeerEndPoint pep in endpointCollection)
                {
                    Console.WriteLine("PeerEndPoint is: {0}", pep);
                    Console.WriteLine("PeerEndPoint data is:\n  Name: {0}\n EndPoint IP address: {1}\n . Port: {2}\n",
                        pep.Name,
                        pep.EndPoint.Address,
                        pep.EndPoint.Port);
                }
            }
            return;
        }
        
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        //List PeerNearMe objects that may be added as contacts.
        
        private static void AddContact()
        {
            PeerNearMeCollection pnmc = null;
            PeerContactCollection peerContacts = null;            
            bool peerNameFound = false;

            PeerApplication application = null;

            try
            {
                Console.WriteLine("Listing the existing contacts...");
                peerContacts = PeerCollaboration.ContactManager.GetContacts();
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The Peer Collaboration Infrastructure is not responding to the contact enumeration request: {0}", p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred while attempting to obtain the contact list: {0}", ex.Message);
            }

            DisplayContacts(peerContacts);

            try
            {
                //Adds one of the PeerNearMe objects as a contact.                               
                pnmc = GetPeersNearMe();
                Console.WriteLine("Please enter the nickname of the peer you wish to add as a contact:");
                string peerNameToAdd = Console.ReadLine();

                application = RegisterCollabApp();

                foreach (PeerNearMe pnm in pnmc)
                {
                    PeerInvitationResponse res = null;
                    if (pnm.Nickname.Contains(peerNameToAdd))
                    {
                        peerNameFound = true;
                        if (!peerContacts.ToString().Contains(pnm.Nickname))
                        {
                            Console.WriteLine("Adding peer {0} to the contact list.", pnm.Nickname);
                            pnm.AddToContactManager();
                        }
                        else
                        {
                            Console.WriteLine("This peer already exists in your contact list.");
                            Console.WriteLine("Sending invitation using the Contact structure instead of the PeerNearMe.");
                            foreach (PeerContact pc in peerContacts)
                            {
                                if (pc.Nickname.Equals(pnm.Nickname))
                                {
                                    res = pnm.Invite(application, "Peer Collaboration Sample", application.Data);
                                    if (res.PeerInvitationResponseType == PeerInvitationResponseType.Accepted)
                                    {
                                        Console.WriteLine("Invitation to contact succeeded.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invitation to contact {0}.", res.PeerInvitationResponseType);
                                    }
                                }
                            }

                        }
                    }
                }

                if (!peerNameFound)
                {
                    Console.WriteLine("No such peer exists near you. Cannot add to contacts.");
                    return;
                }

                peerContacts = PeerCollaboration.ContactManager.GetContacts();

                Console.WriteLine("Listing the contacts again...");
                DisplayContacts(peerContacts);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a contact: {0}", ex.Message);
            }
            finally
            {
                application.Dispose();
            }
            return;
        }
        // </Snippet3>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet4>
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
        // </Snippet4>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet5>
        // Enumerating all local registered applications.
        private static void EnumLocalRegisteredApplications()
        {
            PeerApplicationCollection pac = null;
            Console.WriteLine("Attempting to enumerate all local registered collaboration applications...");
            try
            {
                pac = PeerCollaboration.GetLocalRegisteredApplications(PeerApplicationRegistrationType.AllUsers);
                foreach (PeerApplication pa in pac)
                {
                    Console.WriteLine("Registered application:\n ID: {0}\n Description: {1}\n", pa.Id, pa.Description);
                }
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The Peer Collaboration Infrastructure could not return an enumeration of the registered applications: {0}", 
                    p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception caught when trying to enumerate the registered collaboration applications: {0}.", 
                    ex.Message);
            }
            finally
            {
                foreach (PeerApplication pa in pac)
                {
                    pa.Dispose();
                }
            }
            return;
        }
        // </Snippet5>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // Printing the user menu.
        private static PeerContactCollection EnumContacts()
        {
            PeerContactCollection peerContacts = null;
            Console.WriteLine("Enumerating your contacts...");
            try
            {
                peerContacts = PeerCollaboration.ContactManager.GetContacts();

                // The following method displays an enumeration of all available contacts.
                DisplayContacts(peerContacts);
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The Peer Collaboration Infrastructure could not return an enumeration of the available contacts: {0}", 
                    p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error enumerating the contacts: {0}", ex);
            }
            return peerContacts;
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // Printing the user menu.
        private static void GiveWatchPermissionsAndStartWatching()
        {
            Console.WriteLine("Granting watch permissions...");
            return;
        }
        //------------------------------------------------------------------------------------------------------
        // <Snippet6>
        //Enumerating the contacts and letting the user choose which one to delete.
        public static void DeleteContact() 
        {
            PeerContactCollection pcc = null;
            string contactToDelete = "";

            try
            {
                pcc = EnumContacts();
                if (pcc == null ||
                    pcc.Count == 0)
                {
                    Console.WriteLine("Contact list is empty -- no such contact exists.");
                    return;
                }
                Console.Write("Please enter the nickname of the contact you wish to delete: ");
                contactToDelete = Console.ReadLine();

                foreach (PeerContact pc in pcc)
                {
                    if (pc.Nickname.Equals(contactToDelete))
                    {
                        PeerCollaboration.ContactManager.DeleteContact(pc);
                        Console.WriteLine("Contact {0} successfully deleted!", contactToDelete);
                        return;
                    }
                }
                Console.WriteLine("Contact {0} could not be found in the contact collection.", contactToDelete);
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine("The supplied contact is null: {0}", argNullEx.Message);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("The supplied contact \"{0}\" could not be found in the Contact Manager: {1}", 
                    contactToDelete, argEx.Message);
            }
            catch (PeerToPeerException p2pEx)
            {
                Console.WriteLine("The Peer Collaboration Infrastructure could not delete \"{0}\": {1}",
                    contactToDelete, p2pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception when trying to delete a contact : {0}", ex);
            }
            return;
        }
        // </Snippet6>

        //------------------------------------------------------------------------------------------------------
        // Printing the user menu.
        private static void WaitForPresenceChange()
        {
            Console.WriteLine("Waiting for presence change...");
            return;
        }
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet7>
        // If more than one endpoint for a contact exists, let the user choose which to use.
        //Parameters:
        //   pContact - contact to pick an endpoint for
        //   return value: pPeerEndpoint -  the endpoint the user picked
        private static PeerEndPoint PickEndpointForContact(PeerContact pContact)
        {
            PeerEndPointCollection endPointCollection = pContact.PeerEndPoints;
            if (endPointCollection == null)
            {
                Console.WriteLine("Cannot return endpoint for contact {0} -- PeerEndPointCollection is null.", pContact);
                return null;
            }

            if (endPointCollection.Count == 0)
            {
                Console.WriteLine("Cannot return endpoint for contact {0} -- PeerEndPointCollection is empty.", pContact);
                return null;
            }

            foreach (PeerEndPoint pep in endPointCollection)
            {
                Console.WriteLine("PeerEndPoint is {0}:" , pep);
                Console.WriteLine("PeerEndPoint information:\n Name: {0}\n  IP Address: {1}\n  Port: {2}\n", 
                    pep.Name, 
                    pep.EndPoint.Address, 
                    pep.EndPoint.Port);
            }

            return endPointCollection[0];
        }
        // </Snippet7>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // <Snippet8>
        // Getting the presence info for the contacts in the Contact Collection.
        private static void GetPresenceInformation()
        {

            Console.WriteLine("Getting presence information...");
            {
                PeerContactCollection peerContacts = PeerCollaboration.ContactManager.GetContacts();
                if (null == peerContacts)
                {
                    Console.WriteLine("Unable to enumerate contacts.");
                    return;
                }

                // If there are no contacts available to watch, notify the console
                if (peerContacts.Count == 0)
                {
                    Console.WriteLine("No contacts for which to obtain presence information.");
                    return;
                }

                Console.WriteLine("Printing out all contacts in your contact store...");
                PeerEndPoint peerEndPoint = null;

                foreach (PeerContact pc in peerContacts)
                {
                    try
                    {
                        Console.WriteLine("The contact display name is: \"{0}\" and the peer name is \"{1}\".",
                            pc.DisplayName,
                            pc.PeerName);
                        // In case there are multiple endpoints, pick an endpoint for this contact
                        peerEndPoint = PickEndpointForContact(pc);
                        Console.WriteLine("The presence information is: {0}.", 
                            pc.GetPresenceInfo(peerEndPoint).PresenceStatus.ToString());
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine("The provided endpoint is null or is not valid: {0}", argEx.Message);
                    }
                    catch (PeerToPeerException p2pEx)
                    {
                        Console.WriteLine("The Peer Collaboration Infrastructure could not obtain presence data for the endpoint: {0}", 
                            p2pEx.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error enumerating the contacts: {0}", ex);
                    }
                }
                      
            }

            return;
        }
        // </Snippet8>
        //------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------
        // Printing the user menu.
        private static void SetPresenceInformation()
        {
            Console.WriteLine("Setting presence information...");
            return;
        }
        //------------------------------------------------------------------------------------------------------

    } //end class 
} //end namespace
