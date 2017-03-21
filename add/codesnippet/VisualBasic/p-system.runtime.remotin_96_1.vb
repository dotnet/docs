            ' Retrieve and print information about the registered channels.
            Dim myIChannelArray As IChannel() = ChannelServices.RegisteredChannels
            Dim i As Integer
            For i = 0 To myIChannelArray.Length - 1
               Console.WriteLine("Name of Channel: {0}", myIChannelArray(i).ChannelName)
               Console.WriteLine("Priority of Channel: {0}", + myIChannelArray(i).ChannelPriority)
            Next i