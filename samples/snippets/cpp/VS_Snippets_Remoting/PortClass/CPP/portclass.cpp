

// System.Web.Services.Description.Port.ctor().
// System.Web.Services.Description.Port.Binding().
// System.Web.Services.Description.Portt.Extensions.
// System.Web.Services.Description.Port.Name.
// System.Web.Services.Description.Port.Service.
/* The following example demonstrates the constructor and the properties 'Binding',
  'Extensions','Name', and 'Service' of the 'Port' class.
  The input to the program is a WSDL file 'AddNumbers_cs.wsdl'.
  It creates a 'ServiceDescription' instance by using the static read method
  of 'ServiceDescription' by passing the  'AddNumbers.wsdl' name as an argument.
  It creates  a 'Binding' object and adds that binding object to
  'ServiceDescription'. It adds the 'PortType',Messages to the 'ServiceDescription'
  object. Finally it writes the 'ServiceDescrption' as a WSDL file with
  name 'AddNumbersOne.wsdl.
 */
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Web;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   try
   {
      ServiceDescription^ myDescription = ServiceDescription::Read( "AddNumbers_cs.wsdl" );

      // Create the 'Binding' object.
      Binding^ myBinding = gcnew Binding;
      myBinding->Name = "PortServiceHttpPost";
      XmlQualifiedName^ qualifiedName = gcnew XmlQualifiedName( "s0:PortServiceHttpPost" );
      myBinding->Type = qualifiedName;

      // Create the 'HttpBinding' object.
      HttpBinding^ myHttpBinding = gcnew HttpBinding;
      myHttpBinding->Verb = "POST";

      // Add the 'HttpBinding' to the 'Binding'.
      myBinding->Extensions->Add( myHttpBinding );

      // Create the 'OperationBinding' object.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "AddNumbers";
      HttpOperationBinding^ myOperation = gcnew HttpOperationBinding;
      myOperation->Location = "/AddNumbers";

      // Add the 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding->Extensions->Add( myOperation );

      // Create the 'InputBinding' object.
      InputBinding^ myInput = gcnew InputBinding;
      MimeContentBinding^ postMimeContentbinding = gcnew MimeContentBinding;
      postMimeContentbinding->Type = "application/x-www-form-urlencoded";
      myInput->Extensions->Add( postMimeContentbinding );

      // Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding->Input = myInput;

      // Create the 'OutputBinding' object.
      OutputBinding^ myOutput = gcnew OutputBinding;
      MimeXmlBinding^ postMimeXmlbinding = gcnew MimeXmlBinding;
      postMimeXmlbinding->Part = "Body";
      myOutput->Extensions->Add( postMimeXmlbinding );

      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutput;

      // Add the 'OperationBinding' to 'Binding'.
      myBinding->Operations->Add( myOperationBinding );

      // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription->Bindings->Add( myBinding );

      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
      // <Snippet5>
      // Create a Port.
      Port^ postPort = gcnew Port;
      postPort->Name = "PortServiceHttpPost";
      postPort->Binding = gcnew XmlQualifiedName( "s0:PortServiceHttpPost" );
      // </Snippet4>
      // </Snippet2>

      // Create an HttpAddressBinding.
      HttpAddressBinding^ postAddressBinding = gcnew HttpAddressBinding;
      postAddressBinding->Location = "http://localhost/PortClass/PortService_cs.asmx";

      // Add the HttpAddressBinding to the Port.
      postPort->Extensions->Add( postAddressBinding );
      // </Snippet3>

      // Get the Service of the postPort.
      Service^ myService = postPort->Service;

      // Print the service name for the port.
      Console::WriteLine( "This is the service name of the postPort:*{0}*", myDescription->Services[ 0 ]->Ports[ 0 ]->Service->Name );

      // Add the Port to the PortCollection of the ServiceDescription.
      myDescription->Services[ 0 ]->Ports->Add( postPort );
      // </Snippet5>
      // </Snippet1>

      // Create a 'PortType' object.
      PortType^ postPortType = gcnew PortType;
      postPortType->Name = "PortServiceHttpPost";
      Operation^ postOperation = gcnew Operation;
      postOperation->Name = "AddNumbers";
      OperationMessage^ postInput = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      postInput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostIn" );
      OperationMessage^ postOutput = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
      postOutput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostOut" );
      postOperation->Messages->Add( postInput );
      postOperation->Messages->Add( postOutput );

      // Add the 'Operation' to 'PortType'.
      postPortType->Operations->Add( postOperation );

      // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
      myDescription->PortTypes->Add( postPortType );

      // Create  the 'Message' object.
      Message^ postMessage1 = gcnew Message;
      postMessage1->Name = "AddNumbersHttpPostIn";

      // Create the 'MessageParts'.
      MessagePart^ postMessagePart1 = gcnew MessagePart;
      postMessagePart1->Name = "firstnumber";
      postMessagePart1->Type = gcnew XmlQualifiedName( "s:string" );
      MessagePart^ postMessagePart2 = gcnew MessagePart;
      postMessagePart2->Name = "secondnumber";
      postMessagePart2->Type = gcnew XmlQualifiedName( "s:string" );

      // Add the 'MessagePart' objects to 'Messages'.
      postMessage1->Parts->Add( postMessagePart1 );
      postMessage1->Parts->Add( postMessagePart2 );

      // Create another 'Message' object.
      Message^ postMessage2 = gcnew Message;
      postMessage2->Name = "AddNumbersHttpPostOut";
      MessagePart^ postMessagePart3 = gcnew MessagePart;
      postMessagePart3->Name = "Body";
      postMessagePart3->Element = gcnew XmlQualifiedName( "s0:int" );

      // Add the 'MessagePart' to 'Message'
      postMessage2->Parts->Add( postMessagePart3 );

      // Add the 'Message' objects to 'ServiceDescription'.
      myDescription->Messages->Add( postMessage1 );
      myDescription->Messages->Add( postMessage2 );

      // Write the 'ServiceDescription' as a WSDL file.
      myDescription->Write( "AddNumbersOne.wsdl" );
      Console::WriteLine( "WSDL file with name 'AddNumbersOne.Wsdl' file created Successfully" );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Exception {0} occurred", ex->Message );
   }
}
