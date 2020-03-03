

// System.Runtime.Remoting.Channels.ChannelServices.SyncDispatchMessage(IMessage)
/*
   The following example demonstrates 'SyncDispatchMessage' method of 
   'ChannelServices' class. In the example, 'MyProxy' extends 'RealProxy'
   class and overrides its constructor and 'Invoke' messages. In the 'Main' 
   method, the 'MyProxy' class is instantiated and 'MyPrintMethod' method 
   is called on it.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <ChannelServices_SyncDispatchMessage_Share.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Proxies;
using namespace System::Runtime::Remoting::Messaging;

// <Snippet1>
// Create a custom 'RealProxy'.
public ref class MyProxy: public RealProxy
{
private:
   String^ myURIString;
   MarshalByRefObject^ myMarshalByRefObject;

public:
   MyProxy( Type^ myType )
      : RealProxy( myType )
   {
      
      // RealProxy uses the Type to generate a transparent proxy.
      myMarshalByRefObject = dynamic_cast<MarshalByRefObject^>(Activator::CreateInstance(myType));
      
      // Get 'ObjRef', for transmission serialization between application domains.
      ObjRef^ myObjRef = RemotingServices::Marshal( myMarshalByRefObject );
      
      // Get the 'URI' property of 'ObjRef' and store it.
      myURIString = myObjRef->URI;
      Console::WriteLine( "URI :{0}", myObjRef->URI );
   }

   virtual IMessage^ Invoke ( IMessage^ myIMessage ) override 
	{
      Console::WriteLine( "MyProxy.Invoke Start" );
      Console::WriteLine( "" );
      if ( dynamic_cast<IMethodCallMessage^>(myIMessage) )
            Console::WriteLine( "IMethodCallMessage" );

      if ( dynamic_cast<IMethodReturnMessage^>(myIMessage) )
            Console::WriteLine( "IMethodReturnMessage" );

      Type^ msgType = myIMessage->GetType();
      Console::WriteLine( "Message Type: {0}", msgType );
      Console::WriteLine( "Message Properties" );
      IDictionary^ myIDictionary = myIMessage->Properties;
      
      // Set the '__Uri' property of 'IMessage' to 'URI' property of 'ObjRef'.
      myIDictionary->default[ "__Uri" ] = myURIString;
      IDictionaryEnumerator^ myIDictionaryEnumerator = dynamic_cast<IDictionaryEnumerator^>(myIDictionary->GetEnumerator());
      while ( myIDictionaryEnumerator->MoveNext() )
      {
         Object^ myKey = myIDictionaryEnumerator->Key;
         String^ myKeyName = myKey->ToString();
         Object^ myValue = myIDictionaryEnumerator->Value;
         Console::WriteLine( "\t{0} : {1}", myKeyName, myIDictionaryEnumerator->Value );
         if ( myKeyName->Equals( "__Args" ) )
         {
            array<Object^>^myObjectArray = (array<Object^>^)myValue;
            for ( int aIndex = 0; aIndex < myObjectArray->Length; aIndex++ )
               Console::WriteLine( "\t\targ: {0} myValue: {1}", aIndex, myObjectArray[ aIndex ] );
         }

         if ( (myKeyName->Equals( "__MethodSignature" )) && (nullptr != myValue) )
         {
            array<Object^>^myObjectArray = (array<Object^>^)myValue;
            for ( int aIndex = 0; aIndex < myObjectArray->Length; aIndex++ )
               Console::WriteLine( "\t\targ: {0} myValue: {1}", aIndex, myObjectArray[ aIndex ] );
         }
      }

      IMessage^ myReturnMessage;
      myIDictionary->default[ "__Uri" ] = myURIString;
      Console::WriteLine( "__Uri {0}", myIDictionary->default[ "__Uri" ] );
      Console::WriteLine( "ChannelServices.SyncDispatchMessage" );
      myReturnMessage = ChannelServices::SyncDispatchMessage( myIMessage );
      
      // Push return value and OUT parameters back onto stack.
      IMethodReturnMessage^ myMethodReturnMessage = dynamic_cast<IMethodReturnMessage^>(myReturnMessage);
      Console::WriteLine( "IMethodReturnMessage.ReturnValue: {0}", myMethodReturnMessage->ReturnValue );
      Console::WriteLine( "MyProxy.Invoke - Finish" );
      return myReturnMessage;
   }
};
// </Snippet1>

int main()
{
   try
   {
      TcpChannel^ myTcpChannel = gcnew TcpChannel( 8086 );
      ChannelServices::RegisterChannel( myTcpChannel, false );
	  MyProxy^ myProxyObject = gcnew MyProxy( PrintServer::typeid);
      PrintServer^ myPrintServer = dynamic_cast<PrintServer^>(myProxyObject->GetTransparentProxy());
      if ( myPrintServer == nullptr )
            Console::WriteLine( "Could not locate server" );
      else
            Console::WriteLine( myPrintServer->MyPrintMethod( "String1", 1.2, 6 ) );
      Console::WriteLine( "Calling the Proxy" );
      int kValue = myPrintServer->MyPrintMethod( "String1", 1.2, 6 );
      Console::WriteLine( "Checking result" );
      if ( kValue == 6 )
      {
         Console::WriteLine( "PrintServer.MyPrintMethod PASSED : returned {0}", kValue );
      }
      else
      {
         Console::WriteLine( "PrintServer.MyPrintMethod FAILED : returned {0}", kValue );
      }
      Console::WriteLine( "Sample Done" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "The source of exception: {0}", e->Source );
      Console::WriteLine( "The Message of exception: {0}", e->Message );
   }
}
