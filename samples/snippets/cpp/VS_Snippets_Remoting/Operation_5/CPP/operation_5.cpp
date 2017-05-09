

// System.Web.Services.Description.Operation
// System.Web.Services.Description.Operation.Operation
// System.Web.Services.Description.Operation.Messages
// System.Web.Services.Description.Operation.Name
// System.Web.Services.Description.Operation.PortType
/* The following program demonstrates 'Operation' class, its contructor
and 'Messages','Name' and 'PortType' properties. It reads the file
'Operation_5_Input_CS.wsdl' which does not have 'PortType' object that
supports 'HttpPost'. It adds a 'PortType' object that supports 'HttpPost'
protocol and writes into 'Operation_5_Output_CS.wsdl'.
*/
// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
Operation^ CreateOperation( String^ myOperationName, String^ myInputMesg, String^ myOutputMesg )
{
   
   // <Snippet2>
   // <Snippet3>
   // <Snippet4>
   // Create an Operation.
   Operation^ myOperation = gcnew Operation;
   myOperation->Name = myOperationName;
   OperationMessage^ myInput = dynamic_cast<OperationMessage^>(gcnew OperationInput);
   myInput->Message = gcnew XmlQualifiedName( myInputMesg );
   OperationMessage^ myOutput = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
   myOutput->Message = gcnew XmlQualifiedName( myOutputMesg );
   
   // Add messages to the OperationMessageCollection.
   myOperation->Messages->Add( myInput );
   myOperation->Messages->Add( myOutput );
   Console::WriteLine( "Operation name is: {0}", myOperation->Name );
   
   // </Snippet4>
   // </Snippet3>
   // </Snippet2>
   return myOperation;
}

int main()
{
   ServiceDescription^ myDescription = ServiceDescription::Read( "Operation_5_Input_CS.wsdl" );
   
   // Create a 'PortType' object.
   PortType^ myPortType = gcnew PortType;
   myPortType->Name = "OperationServiceHttpPost";
   Operation^ myOperation = CreateOperation( "AddNumbers", "s0:AddNumbersHttpPostIn", "s0:AddNumbersHttpPostOut" );
   myPortType->Operations->Add( myOperation );
   
   // <Snippet5>      
   // Get the PortType of the Operation. 
   PortType^ myPort = myOperation->PortType;
   Console::WriteLine( "The port type of the operation is: {0}", myPort->Name );
   
   // </Snippet5>
   // Add the 'PortType's to 'PortTypeCollection' of 'ServiceDescription'.
   myDescription->PortTypes->Add( myPortType );
   
   // Write the 'ServiceDescription' as a WSDL file.
   myDescription->Write( "Operation_5_Output_CS.wsdl" );
   Console::WriteLine( "WSDL file with name 'Operation_5_Output_CS.wsdl' file created Successfully" );
}

// </Snippet1>
