// System.Web.Services.Description.OperationMessage
// System.Web.Services.Description.OperationMessage.OperationMessage
// System.Web.Services.Description.OperationMessage.Message
// System.Web.Services.Description.OperationMessage.Operation

/*
The following example demonstrates the usage of the 'OperationMessage'
class, its constructor and the properties 'Message' and 'Operation'.
The input to the program is a WSDL file 'MathService_input_cs.wsdl' without
the input message of 'Add' operation for the SOAP
protocol. In this example a new input message for the 'Add' operation is created.
The input message in the ServiceDescription instance is loaded with values for
'InputMessage'. The instance is then written to 'MathService_new_cs.wsdl'.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      ServiceDescription^ myDescription = ServiceDescription::Read( "MathService_input_cs.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myDescription->PortTypes;

      // Get the OperationCollection for the SOAP protocol.
      OperationCollection^ myOperationCollection = myPortTypeCollection[ 0 ]->Operations;

      // Get the OperationMessageCollection for the Add operation.
      OperationMessageCollection^ myOperationMessageCollection = myOperationCollection[ 0 ]->Messages;

      // <Snippet2>
      // <Snippet4>
      // <Snippet3>
      OperationMessage^ myInputOperationMessage = (OperationMessage^)(gcnew OperationInput);
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      myInputOperationMessage->Message = myXmlQualifiedName;
      // </Snippet3>

      myOperationMessageCollection->Insert( 0, myInputOperationMessage );

      // Display the operation name of the InputMessage.
      Console::WriteLine( "The operation name is {0}", myInputOperationMessage->Operation->Name );
      // </Snippet4>
      // </Snippet2>

      // Add the OperationMessage to the collection.
      myDescription->Write( "MathService_new_cs.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
// </Snippet1>
