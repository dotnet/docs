#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <common.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Security::Permissions;

[SecurityPermission(SecurityAction::Demand)]
int main(array<String^>^ args)
{
    // Create the server channel.
    TcpChannel^ serverChannel = gcnew TcpChannel(9090);

    // Register the server channel.
    ChannelServices::RegisterChannel(serverChannel);

    // Show the name of the channel.
    Console::WriteLine("The name of the channel is {0}.", 
        serverChannel->ChannelName);

    // Show the priority of the channel.
    Console::WriteLine("The priority of the channel is {0}.", 
        serverChannel->ChannelPriority);

    // Show the URIs associated with the channel.
    ChannelDataStore^ data = (ChannelDataStore^) serverChannel->ChannelData;
    for each (String^ uri in data->ChannelUris)
    {
        Console::WriteLine("The channel URI is {0}.", uri);
    }

    // Expose an object for remote calls.
    RemotingConfiguration::RegisterWellKnownServiceType(
        RemoteObject::typeid, "RemoteObject.rem", 
        WellKnownObjectMode::Singleton);

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
        
    // Wait for the user prompt.
    Console::WriteLine("Press ENTER to exit the server.");
    Console::ReadLine();
}