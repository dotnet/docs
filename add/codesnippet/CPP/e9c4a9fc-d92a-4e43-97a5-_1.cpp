public ref class HelloServer: public MarshalByRefObject
{
public:
   HelloServer()
   {
      Console::WriteLine( "HelloServer activated." );
   }

   [OneWay]
   void SayHelloToServer( String^ name )
   {
      Console::WriteLine( "Client invoked SayHelloToServer(\" {0}\").", name );
   }

   // IsOneWay: Note the lack of the OneWayAttribute adornment on this method.
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
   String^ SayHelloToServerAndWait( String^ name )
   {
      Console::WriteLine( "Client invoked SayHelloToServerAndWait(\" {0}\").", name );
      Console::WriteLine( "Client waiting for return? {0}", RemotingServices::IsOneWay( MethodBase::GetCurrentMethod() ) ? (String^)"No" : "Yes" );
      return String::Format( "Hi there, {0}.", name );
   }
};