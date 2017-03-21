    // Show the URIs associated with the channel.
    ChannelDataStore^ data = (ChannelDataStore^) serverChannel->ChannelData;
    for each (String^ uri in data->ChannelUris)
    {
        Console::WriteLine("The channel URI is {0}.", uri);
    }