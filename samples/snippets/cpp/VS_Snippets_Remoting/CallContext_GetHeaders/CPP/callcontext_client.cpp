// System::Runtime::Remoting::CallContext.FreeNamedDataSlot(String*)
// System::Runtime::Remoting::CallContext.GetHeaders()
// System::Runtime::Remoting::CallContext.SetHeaders(Header->Item[])

/* The following example demonstrates 'FreeNamedDataSlot', 'GetHeaders',
and 'SetHeaders' methods of 'CallContext' class.

In the example 'SetData' method is used to set dataSlot. The 'DataSlot' is freed using
'FreeNamedDataSlot' method by passing the Name parameter.
For Setting header an array of type 'Messaging::Header' is passed with method call.
Headers are set in 'HeaderMethod' of remote Object* using 'SetHeaders' method.
Finally the 'GetHeaders' method is used to get all headers.
*/

#using <system.dll>
#using <system.runtime.remoting.dll>
#using <callcontext_share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Security;
using namespace System::Security::Principal;
using namespace System::Collections;

int main()
{
// <Snippet1>
   // Register the channel.
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloService::typeid, "Tcp://localhost:8082" );

   GenericIdentity^ myIdentity = gcnew GenericIdentity( "Bob" );
   array<String^>^ idStr = gcnew array<String^>(1);
   idStr[ 0 ] = "Level1";
   GenericPrincipal^ myPrincipal = gcnew GenericPrincipal( myIdentity, idStr );
   MyLogicalCallContextData ^ myData = gcnew MyLogicalCallContextData( myPrincipal );

   // Set DataSlot with name parameter.
   CallContext::SetData( "test data", myData );

   // Create a remote Object*.
   HelloService ^ myService = gcnew HelloService;
   if ( myService == nullptr )
   {
      Console::WriteLine( "Cannot locate server." );
      return  -1;
   }

   // Call the Remote methods.
   Console::WriteLine( "Remote method output is {0}", myService->HelloMethod( "Microsoft" ) );

   MyLogicalCallContextData ^ myReturnData =
      (MyLogicalCallContextData^)( CallContext::GetData( "test data" ) );
   if ( myReturnData == nullptr )
   {
      Console::WriteLine( "Data is 0." );
   }
   else
   {
      Console::WriteLine( "Data is ' {0}'", myReturnData->numOfAccesses );
   }

   // DataSlot with same Name Parameter which was Set is Freed.
   CallContext::FreeNamedDataSlot( "test data" );
   MyLogicalCallContextData ^ myReturnData1 =
      (MyLogicalCallContextData^)( CallContext::GetData( "test data" ) );
   if ( myReturnData1 == nullptr )
   {
      Console::WriteLine( "FreeNamedDataSlot Successful for test data" );
   }
   else
   {
      Console::WriteLine( "FreeNamedDataSlot Failed  for test data" );
   }
// </Snippet1>

// <Snippet2>
   // Array of Headers with name and values initialized.
   array<Header^>^ myArrSetHeader = { gcnew Header( "Header0","CallContextHeader0" ),
      gcnew Header( "Header1","CallContextHeader1" ) };

   // Pass the Header Array with method call.
   // Header will be set in the method by'CallContext::SetHeaders' method in remote Object*.
   Console::WriteLine( "Remote HeaderMethod output is {0}",
      myService->HeaderMethod( "CallContextHeader", myArrSetHeader ) );

   array<Header^>^ myArrGetHeader;
   // Get Header Array.
   myArrGetHeader = CallContext::GetHeaders();
   if ( nullptr == myArrGetHeader )
   {
      Console::WriteLine( "CallContext::GetHeaders Failed" );
   }
   else
   {
      Console::WriteLine( "Headers:" );
   }

   for each ( Header^ myHeader in myArrGetHeader )
   {
      Console::WriteLine( "Value in Header '{0}' is '{1}'.",
         myHeader->Name, myHeader->Value );
   }
//</Snippet2>
}
