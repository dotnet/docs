

// System.Web.Services.Description.OperationMessageCollection
// System.Web.Services.Description.OperationMessageCollection.Item
// System.Web.Services.Description.OperationMessageCollection.CopyTo
// System.Web.Services.Description.OperationMessageCollection.Add
// System.Web.Services.Description.OperationMessageCollection.Contains
// System.Web.Services.Description.OperationMessageCollection.IndexOf
// System.Web.Services.Description.OperationMessageCollection.Remove
// System.Web.Services.Description.OperationMessageCollection.Insert
// System.Web.Services.Description.OperationMessageCollection.Flow
// System.Web.Services.Description.OperationMessageCollection.Input
// System.Web.Services.Description.OperationMessageCollection.Output

/*
The following example demonstrates the usage of the
'OperationMessageCollection' class and various methods and properties of it.
The input to the program is a WSDL file 'MathService_input_vb.wsdl' without
the input message of 'Add' operation for the SOAP
protocol. In a way it tries to simulate a scenario
wherein the operation flow was 'Notification', however later operation
flow changed to 'Request-Response'.The WSDL file is
modified by inserting a new input message for the 'Add' operation. The
input message in the ServiceDescription instance is loaded with values for
'Input Message'. The instance is then written to 'MathService_new_vb.wsdl'.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;

// <Snippet9>
// <Snippet10>
// <Snippet11>
// Displays the properties of the OperationMessageCollection.
void DisplayFlowInputOutput( OperationMessageCollection^ myOperationMessageCollection, String^ myOperation )
{
   Console::WriteLine( "After {0}:", myOperation );
   Console::WriteLine( "Flow : {0}", myOperationMessageCollection->Flow );
   Console::WriteLine( "The first occurrence of operation Input in the collection {0}", myOperationMessageCollection->Input );
   Console::WriteLine( "The first occurrence of operation Output in the collection {0}", myOperationMessageCollection->Output );
   Console::WriteLine();
}
// </Snippet11>
// </Snippet10>
// </Snippet9>

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

      // Display the Flow, Input, and Output properties.
      DisplayFlowInputOutput( myOperationMessageCollection, "Start" );

      // <Snippet2>
      // <Snippet4>
      // Get the operation message for the Add operation.
      OperationMessage^ myOperationMessage = myOperationMessageCollection[ 0 ];
      OperationMessage^ myInputOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      myInputOperationMessage->Message = myXmlQualifiedName;

      // <Snippet3>
      array<OperationMessage^>^myCollection = gcnew array<OperationMessage^>(myOperationMessageCollection->Count);
      myOperationMessageCollection->CopyTo( myCollection, 0 );
      Console::WriteLine( "Operation name(s) :" );
      for ( int i = 0; i < myCollection->Length; i++ )
      {
         Console::WriteLine( " {0}", myCollection[ i ]->Operation->Name );
      }
      // </Snippet3>

      // Add the OperationMessage to the collection.
      myOperationMessageCollection->Add( myInputOperationMessage );
      
      // </Snippet4>
      DisplayFlowInputOutput( myOperationMessageCollection, "Add" );
      
      // <Snippet5>
      // <Snippet6>
      if ( myOperationMessageCollection->Contains( myOperationMessage ) == true )
      {
         int myIndex = myOperationMessageCollection->IndexOf( myOperationMessage );
         Console::WriteLine( " The index of the Add operation message in the collection is : {0}", myIndex );
      }
      // </Snippet6>
      // </Snippet5>
      // </Snippet2>

      // <Snippet7>
      // <Snippet8>
      myOperationMessageCollection->Remove( myInputOperationMessage );

      // Display Flow, Input, and Output after removing.
      DisplayFlowInputOutput( myOperationMessageCollection, "Remove" );

      // Insert the message at index 0 in the collection.
      myOperationMessageCollection->Insert( 0, myInputOperationMessage );

      // Display Flow, Input, and Output after inserting.
      DisplayFlowInputOutput( myOperationMessageCollection, "Insert" );
      // </Snippet8>
      // </Snippet7>

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
