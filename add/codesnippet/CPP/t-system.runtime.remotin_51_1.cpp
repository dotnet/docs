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
}