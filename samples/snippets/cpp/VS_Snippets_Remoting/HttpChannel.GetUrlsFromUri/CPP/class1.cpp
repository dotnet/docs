

//<Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Collections;

public ref class HelloService: public MarshalByRefObject{};

int main()
{
   // Create a remotable object.
   HttpChannel^ httpChannel = gcnew HttpChannel( 8085 );
   WellKnownServiceTypeEntry^ WKSTE = gcnew WellKnownServiceTypeEntry( HelloService::typeid,"Service",WellKnownObjectMode::Singleton );
   RemotingConfiguration::RegisterWellKnownServiceType( WKSTE );
   RemotingConfiguration::ApplicationName = "HelloServer";

   // Print out the urls for HelloServer.
   array<String^>^urls = httpChannel->GetUrlsForUri( "HelloServer" );
   IEnumerator^ myEnum = urls->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ url = safe_cast<String^>(myEnum->Current);
      System::Console::WriteLine( "{0}", url );
   }

   return 0;
}
//</Snippet1>
