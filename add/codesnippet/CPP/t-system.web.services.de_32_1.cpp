#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Xml;
using namespace System::Web::Services::Description;
int main()
{
   try
   {
      // Read the 'MathService_Input_cs.wsdl' file.
      ServiceDescription^ myDescription = ServiceDescription::Read( "MathService_Input_cs.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myDescription->PortTypes;

      // Get the 'OperationCollection' for 'SOAP' protocol.

      OperationCollection^ myOperationCollection = myPortTypeCollection[ 0 ]->Operations;
      Operation^ myOperation = gcnew Operation;
      myOperation->Name = "Add";
      OperationMessage^ myOperationMessageInput = (OperationMessage^)(gcnew OperationInput);
      myOperationMessageInput->Message = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      OperationMessage^ myOperationMessageOutput = (OperationMessage^)(gcnew OperationOutput);
      myOperationMessageOutput->Message = gcnew XmlQualifiedName( "AddSoapOut",myDescription->TargetNamespace );
      myOperation->Messages->Add( myOperationMessageInput );
      myOperation->Messages->Add( myOperationMessageOutput );
      myOperationCollection->Add( myOperation );

      if ( myOperationCollection->Contains( myOperation ) == true )
      {
         Console::WriteLine( "The index of the added 'myOperation' operation is : {0}", myOperationCollection->IndexOf( myOperation ) );
      }

      myOperationCollection->Remove( myOperation );
      
      // Insert the 'myOpearation' operation at the index '0'.
      myOperationCollection->Insert( 0, myOperation );
      Console::WriteLine( "The operation at index '0' is : {0}", myOperationCollection[ 0 ]->Name );

      array<Operation^>^myOperationArray = gcnew array<Operation^>(myOperationCollection->Count);
      myOperationCollection->CopyTo( myOperationArray, 0 );
      Console::WriteLine( "The operation(s) in the collection are :" );
      for ( int i = 0; i < myOperationCollection->Count; i++ )
      {
         Console::WriteLine( " {0}", myOperationArray[ i ]->Name );
      }

      myDescription->Write( "MathService_New_cs.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}