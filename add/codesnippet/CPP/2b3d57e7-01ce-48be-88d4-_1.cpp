    // Parse the channel's URI.
    array<String^>^ urls = serverChannel->GetUrlsForUri("RemoteObject.rem");
    if (urls->Length > 0)
    {
        String^ objectUrl = urls[0];
        String^ objectUri;
        String^ channelUri = serverChannel->Parse(objectUrl, objectUri);
        Console::WriteLine("The object URL is {0}.", objectUrl);
        Console::WriteLine("The object URI is {0}.", objectUri);
        Console::WriteLine("The channel URI is {0}.", channelUri);
    }