        // sets the send time out using the SendTimeout public property.
        tcpClient.SendTimeout = 5;

        // gets the send time out using the SendTimeout public property.
        if (tcpClient.SendTimeout == 5)
            Console.WriteLine ("The send time out limit was successfully set " + tcpClient.SendTimeout.ToString ());
