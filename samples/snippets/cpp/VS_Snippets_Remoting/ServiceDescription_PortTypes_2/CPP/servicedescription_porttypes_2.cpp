// System.Web.Services.Description.ServiceDescription.PortTypes
// System.Web.Services.Description.ServiceDescription.CanRead

/* 
The following example demonstrates the 'PortTypes' property
and 'CanRead' method of 'ServiceDescription' class.
The input to the program is a WSDL file 'MyWsdl_CS.wsdl'.
This program checks the validity of WSDL file.One of the existing 
port types is removed.A new PortType is defined and added to the 
port types collection of the service description. A modified WSDL 
is the output of the program.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;
using namespace System::Xml;

// <Snippet1>
// <Snippet2>
// Creates an Operation for a PortType.
Operation^ CreateOperation( String^ operationName, String^ inputMessage, String^ outputMessage, String^ targetNamespace )
{
   Operation^ myOperation = gcnew Operation;
   myOperation->Name = operationName;
   OperationMessage^ input = dynamic_cast<OperationMessage^>(gcnew OperationInput);
   input->Message = gcnew XmlQualifiedName( inputMessage,targetNamespace );
   OperationMessage^ output = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
   output->Message = gcnew XmlQualifiedName( outputMessage,targetNamespace );
   myOperation->Messages->Add( input );
   myOperation->Messages->Add( output );
   return myOperation;
}

int main()
{
   String^ myWsdlFileName = "MyWsdl_CS.wsdl";
   XmlTextReader^ myReader = gcnew XmlTextReader( myWsdlFileName );
   if ( ServiceDescription::CanRead( myReader ) )
   {
      ServiceDescription^ myDescription = ServiceDescription::Read( myWsdlFileName );

      // Remove the PortType at index 0 of the collection.
      PortTypeCollection^ myPortTypeCollection = myDescription->PortTypes;
      myPortTypeCollection->Remove( myDescription->PortTypes[ 0 ] );

      // Build a new PortType.
      PortType^ myPortType = gcnew PortType;
      myPortType->Name = "Service1Soap";
      Operation^ myOperation = CreateOperation( "Add", "s0:AddSoapIn", "s0:AddSoapOut", "" );
      myPortType->Operations->Add( myOperation );

      // Add a new PortType to the PortType collection of 
      // the ServiceDescription.
      myDescription->PortTypes->Add( myPortType );
      myDescription->Write( "MyOutWsdl.wsdl" );
      Console::WriteLine( "New WSDL file generated successfully." );
   }
   else
   {
      Console::WriteLine( "This file is not a WSDL file." );
   }
}
// </Snippet2>
// </Snippet1>
