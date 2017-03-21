    static AuthenticationSchemes AuthenticationSchemeForClient(HttpListenerRequest request)
    {
        Console.WriteLine("Client authentication protocol selection in progress...");
        // Do not authenticate local machine requests.
        if (request.RemoteEndPoint.Address.Equals (IPAddress.Loopback))
        {
            return AuthenticationSchemes.None;
        }
        else
        {
            return AuthenticationSchemes.IntegratedWindowsAuthentication;
        }
    }