

#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Runtime::Remoting::Channels;

public ref class SampleService: public ContextBoundObject
{
public:
   bool UpdateServer( int i, double d, String^ s )
   {
      Console::WriteLine( "SampleService::UpdateServer called: {0}, {1}, {2}", i, d, s );
      return true;
   }

};

public ref class ReplicationSink: public IDynamicMessageSink
{
private:
   static const String^ replicatedServiceUri = "/SampleServiceUri";
   static const String^ replicationServerUrl = "tcp://localhost:9001";

public:

   // System::Runtime::Remoting::RemotingServices.ExecuteMessage
   // System::Runtime::Remoting::RemotingServices.GetSessionIdForMethodMessage
   // <Snippet1>
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void ProcessMessageStart( IMessage^ requestMessage, bool /*bClientSide*/, bool /*bAsyncCall*/ )
   {
      Console::WriteLine( "\nProcessMessageStart" );
      Console::WriteLine( "requestMessage = {0}", requestMessage );
      try
      {
         Console::WriteLine( "SessionId = {0}.", RemotingServices::GetSessionIdForMethodMessage( dynamic_cast<IMethodMessage^>(requestMessage) ) );
      }
      catch ( InvalidCastException^ ) 
      {
         Console::WriteLine( "The requestMessage is not an IMethodMessage*." );
      }

      IMethodCallMessage^ requestMethodCallMessage;
      try
      {
         requestMethodCallMessage = dynamic_cast<IMethodCallMessage^>(requestMessage);

         // Prints the details of the IMethodCallMessage* to the console.
         Console::WriteLine( "\nMethodCall details" );
         Console::WriteLine( "Uri = {0}", requestMethodCallMessage->Uri );
         Console::WriteLine( "TypeName = {0}", requestMethodCallMessage->TypeName );
         Console::WriteLine( "MethodName = {0}", requestMethodCallMessage->MethodName );
         Console::WriteLine( "ArgCount = {0}", requestMethodCallMessage->ArgCount );
         Console::WriteLine( "MethodCall::Args" );
         IEnumerator^ myEnum = requestMethodCallMessage->Args->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Object^ o = safe_cast<Object^>(myEnum->Current);
            Console::WriteLine( "\t {0}", o );

            // Sends this method call message to another server to replicate
            // the call at the second server.
            if ( requestMethodCallMessage->Uri == replicatedServiceUri )
            {
               String^ repSvr = String::Format(  "{0}{1}", const_cast<String^>(replicationServerUrl), const_cast<String^>(replicatedServiceUri) );
               SampleService^ replicationService = dynamic_cast<SampleService^>(Activator::GetObject( SampleService::typeid, repSvr ));
               IMethodReturnMessage^ returnMessage = RemotingServices::ExecuteMessage( replicationService, requestMethodCallMessage );

               // Prints the results of the method call stored in the IMethodReturnMessage*.
               Console::WriteLine( "\nMessage returned by ExecuteMessage." );
               Console::WriteLine( "\tException = {0}", returnMessage->Exception );
               Console::WriteLine( "\tReturnValue = {0}", returnMessage->ReturnValue );
               Console::WriteLine( "\tOutArgCount = {0}", returnMessage->OutArgCount );
               Console::WriteLine( "Return message OutArgs" );
               IEnumerator^ myEnum = requestMethodCallMessage->Args->GetEnumerator();
               while ( myEnum->MoveNext() )
               {
                  Object^ o = safe_cast<Object^>(myEnum->Current);
                  Console::WriteLine( "\t {0}", o );
               }
            }
         }
      }
      catch ( InvalidCastException^ ) 
      {
         Console::WriteLine( "The requestMessage is not a MethodCall" );
      }
   }
   // </Snippet1>

   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual void ProcessMessageFinish( IMessage^ requestMessage, bool /*bClientSide*/, bool /*bAsyncCall*/ )
   {
      Console::WriteLine( "\nProcessMessageFinish" );
      Console::WriteLine( "requestMessage = {0}", requestMessage );
      ReturnMessage^ requestMethodReturn;
      try
      {
         requestMethodReturn = static_cast<ReturnMessage^>(requestMessage);

         // Print the details of the ReturnMessage to the console
         Console::WriteLine( "\nReturnMessage details" );
         Console::WriteLine( "\tException = {0}", requestMethodReturn->Exception );
         Console::WriteLine( "\tReturnValue = {0}", requestMethodReturn->ReturnValue );
         Console::WriteLine( "\tOutArgCount = {0}", requestMethodReturn->OutArgCount );
         Console::WriteLine( "Return message OutArgs" );
         IEnumerator^ myEnum = requestMethodReturn->Args->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Object^ o = safe_cast<Object^>(myEnum->Current);
            Console::WriteLine( "\t {0}", o );
         }
      }
      catch ( InvalidCastException^ ) 
      {
         Console::WriteLine( "The requestMessage is not a ReturnMessage." );
      }
   }
};

public ref class ReplicationSinkProp: public IDynamicProperty, public IContributeDynamicSink
{
public:

   property String^ Name 
   {
      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand,
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual String^ get()
      {
         return "ReplicationSinkProp";
      }
   }
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand,
   Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
   virtual IDynamicMessageSink^ GetDynamicSink()
   {
      return gcnew ReplicationSink;
   }
};
