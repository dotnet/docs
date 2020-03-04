// System::Web::Services::Description.Message::FindPartsByName
// System::Web::Services::Description.Message::ServiceDescription
// System::Web::Services::Description.Message::FindPartByName

/* The following program demonstrates the property ' ServiceDescription' and
methods 'FindPartsByName', 'FindPartByName' of class 'Message'. The program
reads a wsdl document S"MathService::wsdl" and instantiates a
ServiceDescription instance from WSDL document.
The program invokes 'FindPartsByName' to obtain an array of MessageParts and also invokes
'FindPartByName' to retrieve a specific 'MessagePart'.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   try
   {
      // <Snippet2>
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_cpp.wsdl" );
      
      // <Snippet1>
      // Get message from ServiceDescription.
      Message^ myMessage1 = myServiceDescription->Messages[ "AddHttpPostIn" ];
      Console::WriteLine( "ServiceDescription : {0}", myMessage1->ServiceDescription );
      
      // </Snippet2>
      array<String^>^myParts = gcnew array<String^>(2);
      myParts[ 0 ] = "a";
      myParts[ 1 ] = "b";
      array<MessagePart^>^myMessageParts = myMessage1->FindPartsByName( myParts );
      Console::WriteLine( "Results of FindPartsByName operation:" );
      for ( int i = 0; i < myMessageParts->Length; ++i )
      {
         Console::WriteLine( "Part Name: {0}", myMessageParts[ i ]->Name );
         Console::WriteLine( "Part Type: {0}", myMessageParts[ i ]->Type );
      }
      // </Snippet1>
      // <Snippet3>
      // Get another message from ServiceDescription.
      Message^ myMessage2 = myServiceDescription->Messages[ "DivideHttpGetOut" ];
      MessagePart^ myMessagePart = myMessage2->FindPartByName( "Body" );
      Console::WriteLine( "Results of FindPartByName operation:" );
      Console::WriteLine( "Part Name: {0}", myMessagePart->Name );
      Console::WriteLine( "Part Element: {0}", myMessagePart->Element );
      // </Snippet3>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
