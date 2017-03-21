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

      OperationMessage^ myInputOperationMessage = (OperationMessage^)(gcnew OperationInput);
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      myInputOperationMessage->Message = myXmlQualifiedName;

      myOperationMessageCollection->Insert( 0, myInputOperationMessage );

      // Display the operation name of the InputMessage.
      Console::WriteLine( "The operation name is {0}", myInputOperationMessage->Operation->Name );

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