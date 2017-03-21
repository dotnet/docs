        // Display the channel's properties using Keys and Item.
        foreach(string key in clientChannel.Keys)
        {
            Console.WriteLine(
                "clientChannel[{0}] = <{1}>", 
                key, clientChannel[key]);
        }