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