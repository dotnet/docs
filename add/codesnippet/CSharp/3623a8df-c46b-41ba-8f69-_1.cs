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