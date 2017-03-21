#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Serialization;

public ref class RemoteObject: public MarshalByRefObject
{
public:
   void Method1( LocalObject^ param )
   {
      Console::WriteLine( "Invoked: Method1( {0})", param );
   }
};

int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel( 8090 ) );
   WellKnownServiceTypeEntry^ wkste = gcnew WellKnownServiceTypeEntry( RemoteObject::typeid,"RemoteObject",WellKnownObjectMode::Singleton );
   RemotingConfiguration::RegisterWellKnownServiceType( wkste );
   RemoteObject^ RObj = dynamic_cast<RemoteObject^>(Activator::GetObject( RemoteObject::typeid, "http://localhost:8090/RemoteObject" ));
   LocalObject^ LObj = gcnew LocalObject;
   RObj->Method1( LObj );
   Console::WriteLine( "Press Return to exit..." );
   Console::ReadLine();
}