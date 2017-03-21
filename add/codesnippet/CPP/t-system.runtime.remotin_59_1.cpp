[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ServerSinkProvider: public IServerChannelSinkProvider
{
   // The next provider in the chain.
private:
   IServerChannelSinkProvider^ nextProvider;

public:
   property IServerChannelSinkProvider^ Next 
   {
      virtual IServerChannelSinkProvider^ get()
      {
         return (nextProvider);
      }

      virtual void set( IServerChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }

   virtual IServerChannelSink^ CreateSink( IChannelReceiver^ channel )
   {
      Console::WriteLine( "Creating ServerSink" );

      // Create the next sink in the chain.
      IServerChannelSink^ nextSink = nextProvider->CreateSink( channel );

      // Hook our sink up to it.
      return (gcnew ServerSink( nextSink ));
   }

   virtual void GetChannelData( IChannelDataStore^ /*channelData*/ ){}

   // This constructor is required in order to use the provider in file-based configuration.
   // It need not do anything unless you want to use the information in the parameters.
   ServerSinkProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}
};