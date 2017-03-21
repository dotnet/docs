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