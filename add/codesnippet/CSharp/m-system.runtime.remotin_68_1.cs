         HttpChannel myClientChannel = new HttpChannel(myProperties,
            new SoapClientFormatterSinkProvider(),
            new SoapServerFormatterSinkProvider());
         ChannelServices.RegisterChannel(myClientChannel);
         // Get the registered channel. 
         Console.WriteLine("Channel Name : "+ChannelServices.GetChannel(
            myClientChannel.ChannelName).ChannelName);
         Console.WriteLine("Channel Priorty : "+ChannelServices.GetChannel(
            myClientChannel.ChannelName).ChannelPriority);