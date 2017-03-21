        public static void EndAuthenticateCallback (IAsyncResult ar)
        {
            // Get the saved data.
            ClientState cState = (ClientState) ar.AsyncState;
            TcpClient clientRequest = cState.Client;
            NegotiateStream authStream = (NegotiateStream) cState.AuthenticatedStream;
            Console.WriteLine("Ending authentication.");
            // Any exceptions that occurred during authentication are
            // thrown by the EndAuthenticateAsServer method.
            try 
            {
                // This call blocks until the authentication is complete.
                authStream.EndAuthenticateAsServer(ar);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Authentication failed - closing connection.");
                cState.Waiter.Set();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Closing connection.");
                cState.Waiter.Set();
                return;
            }
            // Display properties of the authenticated client.
            IIdentity id = authStream.RemoteIdentity;
            Console.WriteLine("{0} was authenticated using {1}.", 
                id.Name, 
                id.AuthenticationType
                );
            cState.Waiter.Set();

    }