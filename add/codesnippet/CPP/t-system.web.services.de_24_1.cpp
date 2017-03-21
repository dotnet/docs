#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;

// Displays the properties of the OperationMessageCollection.
void DisplayFlowInputOutput( OperationMessageCollection^ myOperationMessageCollection, String^ myOperation )
{
   Console::WriteLine( "After {0}:", myOperation );
   Console::WriteLine( "Flow : {0}", myOperationMessageCollection->Flow );
   Console::WriteLine( "The first occurrence of operation Input in the collection {0}", myOperationMessageCollection->Input );
   Console::WriteLine( "The first occurrence of operation Output in the collection {0}", myOperationMessageCollection->Output );
   Console::WriteLine();
}

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

      // Get the operation message for the Add operation.
      OperationMessage^ myOperationMessage = myOperationMessageCollection[ 0 ];
      OperationMessage^ myInputOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      myInputOperationMessage->Message = myXmlQualifiedName;

      array<OperationMessage^>^myCollection = gcnew array<OperationMessage^>(myOperationMessageCollection->Count);
      myOperationMessageCollection->CopyTo( myCollection, 0 );
      Console::WriteLine( "Operation name(s) :" );
      for ( int i = 0; i < myCollection->Length; i++ )
      {
         Console::WriteLine( " {0}", myCollection[ i ]->Operation->Name );
      }

      // Add the OperationMessage to the collection.
      myOperationMessageCollection->Add( myInputOperationMessage );
      
      DisplayFlowInputOutput( myOperationMessageCollection, "Add" );
      
      if ( myOperationMessageCollection->Contains( myOperationMessage ) == true )
      {
         int myIndex = myOperationMessageCollection->IndexOf( myOperationMessage );
         Console::WriteLine( " The index of the Add operation message in the collection is : {0}", myIndex );
      }

      myOperationMessageCollection->Remove( myInputOperationMessage );

      // Display Flow, Input, and Output after removing.
      DisplayFlowInputOutput( myOperationMessageCollection, "Remove" );

      // Insert the message at index 0 in the collection.
      myOperationMessageCollection->Insert( 0, myInputOperationMessage );

      // Display Flow, Input, and Output after inserting.
      DisplayFlowInputOutput( myOperationMessageCollection, "Insert" );

      myDescription->Write( "MathService_new_cs.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}