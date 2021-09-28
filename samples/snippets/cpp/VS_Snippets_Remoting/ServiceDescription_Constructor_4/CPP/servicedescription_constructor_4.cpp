// System.Web.Services.Description.ServiceDescription.ServiceDescription()
// System.Web.Services.Description.ServiceDescription.Read(string)
// System.Web.Services.Description.ServiceDescription.Messages
// System.Web.Services.Description.ServiceDescription.Name

/* 
The following example demonstrates the constructor 'ServiceDescription()', 
properties 'Messages', 'Name' and 'Read'  method of 'ServiceDescription'
class.The input to the program is a WSDL file 'MyWsdl.wsdl'.
This program removes one message from the existing WSDL.
A new Message is defined and added to the ServiceDescription.
A new wsdl with modified ServiceDescription is written in 'MyOutWsdl.wsdl'.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;
using namespace System::Xml;

int main()
{
   // <Snippet1>
   // <Snippet2>
   // <Snippet3>
   // <Snippet4>
   ServiceDescription^ myDescription = gcnew ServiceDescription;
   myDescription = ServiceDescription::Read( "MyWsdl_CS.wsdl" );
   myDescription->Name = "MyServiceDescription";
   Console::WriteLine( "Name: {0}", myDescription->Name );
   MessageCollection^ myMessageCollection = myDescription->Messages;

   // Remove the message at index 0 from the message collection.
   myMessageCollection->Remove( myDescription->Messages[ 0 ] );

   // Build a new message.
   Message^ myMessage = gcnew Message;
   myMessage->Name = "AddSoapIn";

   // Build a new MessagePart.
   MessagePart^ myMessagePart = gcnew MessagePart;
   myMessagePart->Name = "parameters";
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:Add" );
   myMessagePart->Element = myXmlQualifiedName;

   // Add MessageParts to the message.
   myMessage->Parts->Add( myMessagePart );

   // Add the message to the ServiceDescription.
   myDescription->Messages->Add( myMessage );
   myDescription->Write( "MyOutWsdl.wsdl" );
   // </Snippet4>
   // </Snippet3>
   // </Snippet2>
   // </Snippet1>
}
