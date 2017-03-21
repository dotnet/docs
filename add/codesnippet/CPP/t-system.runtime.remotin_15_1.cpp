[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ClientSinkProvider: public IClientChannelSinkProvider
{
private:

   // The next provider in the chain.
   IClientChannelSinkProvider^ nextProvider;

public:
   property IClientChannelSinkProvider^ Next 
   {
      virtual IClientChannelSinkProvider^ get()
      {
         return (nextProvider);
      }

      virtual void set( IClientChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }

   virtual IClientChannelSink^ CreateSink( IChannelSender^ channel, String^ url, Object^ remoteChannelData )
   {
      Console::WriteLine( "Creating ClientSink for {0}", url );
      
      // Create the next sink in the chain.
      IClientChannelSink^ nextSink = nextProvider->CreateSink( channel, url, remoteChannelData );
      
      // Hook our sink up to it.
      return (gcnew ClientSink( nextSink ));
   }

   // This constructor is required in order to use the provider in file-based configuration.
   // It need not do anything unless you want to use the information in the parameters.
   ClientSinkProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}
};