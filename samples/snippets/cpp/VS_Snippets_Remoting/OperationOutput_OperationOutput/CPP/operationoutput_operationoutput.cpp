// System.Web.Services.Description.OperationOutput
// System.Web.Services.Description.OperationOutput.OperationOutput

/*
The following example demonstrates the usage of the 'OperationOutput'
class and its constructor 'OperationOutput'. It creates a
'ServiceDescription' object by reading the file 'AddNumbersIn_cs.wsdl' and 
then creates 'AddNumbersOut_cs.wsdl' file which corresponds to added
attributes in the 'ServiceDescription' instance.
*/

// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

int main()
{
   try
   {
      ServiceDescription^ myDescription = ServiceDescription::Read( "AddNumbersIn_cs.wsdl" );

      // Add the ServiceHttpPost binding.
      Binding^ myBinding = gcnew Binding;
      myBinding->Name = "ServiceHttpPost";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:ServiceHttpPost" );
      myBinding->Type = myXmlQualifiedName;
      HttpBinding^ myHttpBinding = gcnew HttpBinding;
      myHttpBinding->Verb = "POST";
      myBinding->Extensions->Add( myHttpBinding );

      // Add the operation name AddNumbers.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "AddNumbers";
      HttpOperationBinding^ myOperation = gcnew HttpOperationBinding;
      myOperation->Location = "/AddNumbers";
      myOperationBinding->Extensions->Add( myOperation );

      // Add the input binding.
      InputBinding^ myInput = gcnew InputBinding;
      MimeContentBinding^ postMimeContentbinding = gcnew MimeContentBinding;
      postMimeContentbinding->Type = "application/x-www-form-urlencoded";
      myInput->Extensions->Add( postMimeContentbinding );

      // Add the InputBinding to the OperationBinding.
      myOperationBinding->Input = myInput;

      // Add the ouput binding.
      OutputBinding^ myOutput = gcnew OutputBinding;
      MimeXmlBinding^ postMimeXmlbinding = gcnew MimeXmlBinding;
      postMimeXmlbinding->Part = "Body";
      myOutput->Extensions->Add( postMimeXmlbinding );

      // Add the OutPutBinding to the OperationBinding.
      myOperationBinding->Output = myOutput;
      myBinding->Operations->Add( myOperationBinding );
      myDescription->Bindings->Add( myBinding );

      // Add the port definition.
      Port^ postPort = gcnew Port;
      postPort->Name = "ServiceHttpPost";
      postPort->Binding = gcnew XmlQualifiedName( "s0:ServiceHttpPost" );
      HttpAddressBinding^ postAddressBinding = gcnew HttpAddressBinding;
      postAddressBinding->Location = "http://localhost/Service_cs.asmx";
      postPort->Extensions->Add( postAddressBinding );
      myDescription->Services[ 0 ]->Ports->Add( postPort );

      // Add the post port type definition.
      PortType^ postPortType = gcnew PortType;
      postPortType->Name = "ServiceHttpPost";
      Operation^ postOperation = gcnew Operation;
      postOperation->Name = "AddNumbers";
      OperationMessage^ postInput = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      postInput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostIn" );

      // <Snippet2>
      OperationOutput^ postOutput = gcnew OperationOutput;
      postOutput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostOut" );
      postOperation->Messages->Add( postInput );
      postOperation->Messages->Add( postOutput );
      postPortType->Operations->Add( postOperation );
      // </Snippet2>

      myDescription->PortTypes->Add( postPortType );

      // Add the first message information.
      Message^ postMessage1 = gcnew Message;
      postMessage1->Name = "AddNumbersHttpPostIn";
      MessagePart^ postMessagePart1 = gcnew MessagePart;
      postMessagePart1->Name = "firstnumber";
      postMessagePart1->Type = gcnew XmlQualifiedName( "s:string" );

      // Add the second message information.
      MessagePart^ postMessagePart2 = gcnew MessagePart;
      postMessagePart2->Name = "secondnumber";
      postMessagePart2->Type = gcnew XmlQualifiedName( "s:string" );
      postMessage1->Parts->Add( postMessagePart1 );
      postMessage1->Parts->Add( postMessagePart2 );
      Message^ postMessage2 = gcnew Message;
      postMessage2->Name = "AddNumbersHttpPostOut";
      
      // Add the third message information.
      MessagePart^ postMessagePart3 = gcnew MessagePart;
      postMessagePart3->Name = "Body";
      postMessagePart3->Element = gcnew XmlQualifiedName( "s0:int" );
      postMessage2->Parts->Add( postMessagePart3 );
      myDescription->Messages->Add( postMessage1 );
      myDescription->Messages->Add( postMessage2 );

      // Write the ServiceDescription as a WSDL file.
      myDescription->Write( "AddNumbersOut_cs.wsdl" );
      Console::WriteLine( "WSDL file named AddNumbersOut_cs.Wsdl"
      " created successfully." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
// </Snippet1>
