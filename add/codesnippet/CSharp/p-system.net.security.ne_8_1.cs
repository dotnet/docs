         static void DisplayAuthenticationProperties(NegotiateStream stream)
        {
             Console.WriteLine("IsAuthenticated: {0}", stream.IsAuthenticated);
            Console.WriteLine("IsMutuallyAuthenticated: {0}", stream.IsMutuallyAuthenticated);
            Console.WriteLine("IsEncrypted: {0}", stream.IsEncrypted);
            Console.WriteLine("IsSigned: {0}", stream.IsSigned);
            Console.WriteLine("ImpersonationLevel: {0}", stream.ImpersonationLevel);
            Console.WriteLine("IsServer: {0}", stream.IsServer);
        }