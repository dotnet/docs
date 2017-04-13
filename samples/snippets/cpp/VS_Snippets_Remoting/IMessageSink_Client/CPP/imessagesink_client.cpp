

// System.Runtime.Remoting.Messaging.IMessage
// System.Runtime.Remoting.Messaging.IMessage.Properties
// System.Runtime.Remoting.Messaging.IMessageSink
// System.Runtime.Remoting.Messaging.IMessageSink.SyncProcessMessage(IMessage)
/* The following example demonstrates 'IMessage.Properties', 'IMessage' interface,
'IMessageSink.SyncProcessMessage' and 'IMessageSink' interface.
In the example the MyProxy is derived from 'RealProxy' class. In MyProxy 
'MessageSink' is created using 'CreateMessageSink' method of 'IChannelSender' 
interface. The 'IMessageSink' return by 'CreateMessageSink' is used to demonstrate 
'IMessageSink.SyncProcessMessage' of 'IMessageSink' interface. The 'Invoke' method
is overridden in 'MyProxy' class.to demonstrate its properties.
*/
//<Snippet1>
//<Snippet3>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <IMessageSink_Share.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Threading;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Permissions;
using namespace Share;

public ref class MyProxy: public RealProxy
{
private:
   String^ myUrl;
   String^ myObjectURI;
   IMessageSink^ myMessageSink;

public:
	[System::Security::Permissions::PermissionSetAttribute(System::Security::Permissions::SecurityAction::LinkDemand)]

   MyProxy( Type^ myType, String^ myUrl1 )
      : RealProxy( myType )
   {
      myUrl = myUrl1;
      array<IChannel^>^myRegisteredChannels = ChannelServices::RegisteredChannels;
      IEnumerator^ myEnum = myRegisteredChannels->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IChannel^ channel = safe_cast<IChannel^>(myEnum->Current);
         if ( dynamic_cast<IChannelSender^>(channel) )
         {
            IChannelSender^ myChannelSender = dynamic_cast<IChannelSender^>(channel);
            myMessageSink = myChannelSender->CreateMessageSink( myUrl, nullptr, myObjectURI );
            if ( myMessageSink != nullptr )
                        break;
         }
      }

      if ( myMessageSink == nullptr )
      {
         throw gcnew Exception( String::Format( "A supported channel could not be found for myUrl1:{0}", myUrl ) );
      }
   }

   virtual IMessage^ Invoke( IMessage^ myMesg ) override
   {
      Console::WriteLine( "MyProxy.Invoke Start" );
      if ( dynamic_cast<IMethodCallMessage^>(myMesg) )
            Console::WriteLine( "IMethodCallMessage" );

      if ( dynamic_cast<IMethodReturnMessage^>(myMesg) )
            Console::WriteLine( "IMethodReturnMessage" );

      
      //<Snippet2>
      Console::WriteLine( "Message Properties" );
      IDictionary^ myDictionary = myMesg->Properties;
      IDictionaryEnumerator^ myEnum = dynamic_cast<IDictionaryEnumerator^>(myDictionary->GetEnumerator());
      while ( myEnum->MoveNext() )
      {
         Object^ myKey = myEnum->Key;
         String^ myKeyName = myKey->ToString();
         Object^ myValue = myEnum->Value;
         Console::WriteLine( "{0} : {1}", myKeyName, myEnum->Value );
         if ( myKeyName->Equals( "__Args" ) )
         {
            array<Object^>^myArgs = (array<Object^>^)myValue;
            for ( int myInt = 0; myInt < myArgs->Length; myInt++ )
               Console::WriteLine( "arg: {0} myValue: {1}", myInt, myArgs[ myInt ] );
         }

         if ( (myKeyName->Equals( "__MethodSignature" )) && (nullptr != myValue) )
         {
            array<Object^>^myArgs = (array<Object^>^)myValue;
            for ( int myInt = 0; myInt < myArgs->Length; myInt++ )
               Console::WriteLine( "arg: {0} myValue: {1}", myInt, myArgs[ myInt ] );
         }
      }

      Console::WriteLine( "myUrl1 {0} object URI{1}", myUrl, myObjectURI );
      myDictionary->default[ "__Uri" ] = myUrl;
      Console::WriteLine( "URI {0}", myDictionary->default[ "__URI" ] );
      
      //</Snippet2>
      //<Snippet4>
      IMessage^ myRetMsg = myMessageSink->SyncProcessMessage( myMesg );
      if ( dynamic_cast<IMethodReturnMessage^>(myRetMsg) )
      {
         IMethodReturnMessage^ myMethodReturnMessage = dynamic_cast<IMethodReturnMessage^>(myRetMsg);
      }

      
      //</Snippet4>
      Console::WriteLine( "MyProxy.Invoke - Finish" );
      return myRetMsg;
   }

};


//
// Main function that drives the whole sample
//
int main()
{
   ChannelServices::RegisterChannel( gcnew HttpChannel, false );
   Console::WriteLine( "Remoting Sample:" );
   Console::WriteLine( "Generate a new MyProxy using the Type" );
   Type^ myType = MyHelloService::typeid;
   String^ myUrl1 = "http://localhost/myServiceAccess.soap";
   MyProxy^ myProxy = gcnew MyProxy( myType,myUrl1 );
   Console::WriteLine( "Obtain the transparent proxy from myProxy" );
   MyHelloService^ myService = dynamic_cast<MyHelloService^>(myProxy->GetTransparentProxy());
   Console::WriteLine( "Calling the Proxy" );
   String^ myReturnString = myService->myFunction( "bill" );
   Console::WriteLine( "Checking result : {0}", myReturnString );
   if ( myReturnString->Equals( "Hi there bill, you are using .NET Remoting" ) )
   {
      Console::WriteLine( "myService.HelloMethod PASSED : returned {0}", myReturnString );
   }
   else
   {
      Console::WriteLine( "myService.HelloMethod FAILED : returned {0}", myReturnString );
   }
}

//</Snippet1>
//</Snippet3>
