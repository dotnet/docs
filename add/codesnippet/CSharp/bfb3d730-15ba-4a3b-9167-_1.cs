        Console.WriteLine ("This application will timeout if Send does not return within " + Encoding.ASCII.GetString (s.GetSocketOption (SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 4)));

        // blocks until send returns
        int i = s.Send (msg);

        // blocks until read returns
        byte[] bytes = new byte[1024];

        s.Receive (bytes);

        //Display to the screen
        Console.WriteLine (Encoding.ASCII.GetString (bytes));
        s.Shutdown (SocketShutdown.Both);
        Console.WriteLine ("If data remains to be sent, this application will stay open for " + ((LingerOption)s.GetSocketOption (SocketOptionLevel.Socket, SocketOptionName.Linger)).LingerTime.ToString ());
        s.Close ();