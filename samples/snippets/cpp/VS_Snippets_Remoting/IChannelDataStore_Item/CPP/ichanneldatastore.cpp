// System.Runtime.Remoting.Channels.IChannelDataStore
// System.Runtime.Remoting.Channels.IChannelDataStore.ChannelUris
// System.Runtime.Remoting.Channels.IChannelDataStore.Item[object]

/* The following example demonstrates 'ChannelUris', 'Item' and 'IChannelDataStore'
class.
In the example after registering the channel, the object is registered with remoting
infrastructure by calling 'RemotingServices.Marshal' method. After registering the
object the channel information is obtained. From the channel information the required
'IChannelInfo' is collected and displayed.
*/

// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Services;

// Marshal ByRef Object class.
public ref class MyServiceClass: public MarshalByRefObject
{
public:
   String^ HelloWorld()
   {
      return "Hello World";
   }
};

int main()
{
   // <Snippet2>
   // <Snippet3>
   TcpChannel^ myChannel = gcnew TcpChannel( 8085 );
   ChannelServices::RegisterChannel( myChannel );
   MyServiceClass^ myService = gcnew MyServiceClass;
   
   // After the channel is registered, register the object
   // with remoting infrastructure by calling Marshal method.
   ObjRef^ myObjRef = RemotingServices::Marshal( myService, "TcpService" );
   
   // Get the information contributed by active channel.
   IChannelInfo^ myChannelInfo = myObjRef->ChannelInfo;
   IChannelDataStore^ myIChannelData;
   System::Collections::IEnumerator^ myEnum = myChannelInfo->ChannelData->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ myChannelData = safe_cast<Object^>(myEnum->Current);
      if ( dynamic_cast<IChannelDataStore^>(myChannelData) )
      {
         myIChannelData = dynamic_cast<IChannelDataStore^>(myChannelData);
         System::Collections::IEnumerator^ myEnum1 = myIChannelData->ChannelUris->GetEnumerator();
         while ( myEnum1->MoveNext() )
         {
            String^ myUri = safe_cast<String^>(myEnum1->Current);
            Console::WriteLine( "Channel Uris are -> {0}", myUri );
         }
         String^ myKey = "Key1";
         myIChannelData[ myKey ] = "My Data";
         Console::WriteLine( myIChannelData[ myKey ] );
      }
   }
   // </Snippet3>
   // </Snippet2>
}
// </Snippet1>
