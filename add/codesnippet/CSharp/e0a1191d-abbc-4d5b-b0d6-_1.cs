            System.Console.WriteLine("Hit <enter> to unregister the channels...");
            System.Console.ReadLine();
            // Unregister the 'HttpChannel' and 'TcpChannel' channels.
            ChannelServices.UnregisterChannel(myTcpChannel);
            ChannelServices.UnregisterChannel(myHttpChannel);
            Console.WriteLine("Unregistered the channels.");