// System::Web::Services::Description.MessagePartCollection::Item Property(Int32);
// System::Web::Services::Description.MessagePart::Message;
// System::Web::Services::Description.MessagePartCollection::CopyTo;
// System::Web::Services::Description.MessagePartCollection::Item Property (String);
// System::Web::Services::Description.MessagePartCollection::Contains;
// System::Web::Services::Description.MessagePartCollection::IndexOf;
// System::Web::Services::Description.MessagePartCollection::Remove;
// System::Web::Services::Description.MessagePartCollection;

/* The program reads a wsdl document S"MathService::wsdl" and gets ServiceDescription instance.
A MessagePartCollection instance is then retrieved from each Message and it's members are demonstrated.
*/

// <Snippet8>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   Console::WriteLine( "" );
   Console::WriteLine( "MessagePartCollection Sample" );
   Console::WriteLine( "============================" );
   Console::WriteLine( "" );
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService.wsdl" );

   // Get the message collection.
   MessageCollection^ myMessageCollection = myServiceDescription->Messages;
   Console::WriteLine( "Total Messages in the document = {0}", myServiceDescription->Messages->Count );
   Console::WriteLine( "" );
   Console::WriteLine( "Enumerating PartCollection for each message..." );
   Console::WriteLine( "" );

   // <Snippet1>
   // <Snippet2>
   // Get the message part collection for each message.
   for ( int i = 0; i < myMessageCollection->Count; ++i )
   {
      Console::WriteLine( "Message      : {0}", myMessageCollection[ i ]->Name );

      // Get the message part collection.
      MessagePartCollection^ myMessagePartCollection = myMessageCollection[ i ]->Parts;

      // Display the part collection.
      for ( int k = 0; k < myMessagePartCollection->Count; k++ )
      {
         Console::WriteLine( "\t       Part Name     : {0}", myMessagePartCollection[ k ]->Name );
         Console::WriteLine( "\t       Message Name  : {0}", myMessagePartCollection[ k ]->Message->Name );
      }
      Console::WriteLine( "" );
   }
   // </Snippet2>
   // </Snippet1>

   Console::WriteLine( "MessagePartCollection for the message AddHttpGetIn." );
   // <Snippet3>
   // <Snippet4>
   Message^ myLocalMessage = myServiceDescription->Messages[ "AddHttpPostOut" ];
   if ( myMessageCollection->Contains( myLocalMessage ) )
   {
      Console::WriteLine( "Message      : {0}", myLocalMessage->Name );

      // Get the message part collection.
      MessagePartCollection^ myMessagePartCollection = myLocalMessage->Parts;
      array<MessagePart^>^myMessagePart = gcnew array<MessagePart^>(myMessagePartCollection->Count);
      
      // Copy the MessagePartCollection to an array.
      myMessagePartCollection->CopyTo( myMessagePart, 0 );
      for ( int k = 0; k < myMessagePart->Length; k++ )
         Console::WriteLine( "\t       Part Name : {0}", myMessagePartCollection[ k ]->Name );
      Console::WriteLine( "" );
   }
   // </Snippet4>
   // </Snippet3>

   // <Snippet5>
   // <Snippet6>
   // <Snippet7>
   Console::WriteLine( "Checking if message is AddHttpPostOut..." );
   Message^ myMessage = myServiceDescription->Messages[ "AddHttpPostOut" ];
   if ( myMessageCollection->Contains( myMessage ) )
   {
      // Get the mssage part collection.
      MessagePartCollection^ myMessagePartCollection = myMessage->Parts;

      // Get the part named Body.
      MessagePart^ myMessagePart = myMessage->Parts[ "Body" ];
      if ( myMessagePartCollection->Contains( myMessagePart ) )
      {
         // Get the part named Body.
         Console::WriteLine( "Index of Body in MessagePart collection = {0}", myMessagePartCollection->IndexOf( myMessagePart ) );
         Console::WriteLine( "Deleting Body from MessagePart collection..." );
         myMessagePartCollection->Remove( myMessagePart );
         if ( myMessagePartCollection->IndexOf( myMessagePart ) == -1 )
                  Console::WriteLine( "from the message AddHttpPostOut." );
      }
   }
   // </Snippet7>
   // </Snippet6>
   // </Snippet5>
}
// </Snippet8>
