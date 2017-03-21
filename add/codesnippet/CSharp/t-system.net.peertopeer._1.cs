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