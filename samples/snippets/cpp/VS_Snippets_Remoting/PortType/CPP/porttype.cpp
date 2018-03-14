

// System.Web.Services.Description.PortType.Operations
// System.Web.Services.Description.PortType.PortType()
// System.Web.Services.Description.PortType.Name
/*The following sample demonstrates the properties 'Operations','Name' and constructor
'PortType()' of class 'PortType'.This sample reads the contents of a file 'MathService_cs.wsdl'
into a 'ServiceDescription' instance. It gets the collection of 'PortType'
instances from 'ServiceDescription'. It removes a 'PortType' from the collection, creates a 
new 'PortType' and adds it into collection.The programs writes a new web service description 
file 'MathService_New.wsdl'.
*/
// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;
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
   try
   {
      // <Snippet2>
      // <Snippet3>
      PortTypeCollection^ myPortTypeCollection;
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes : {0}", noOfPortTypes );
      PortType^ myPortType = myPortTypeCollection[ "MathServiceSoap" ];
      myPortTypeCollection->Remove( myPortType );
      
      // Create a new PortType.
      PortType^ myNewPortType = gcnew PortType;
      myNewPortType->Name = "MathServiceSoap";
      OperationCollection^ myOperationCollection = myServiceDescription->PortTypes[ 0 ]->Operations;
      String^ inputMsg;
      String^ outputMsg;
      for ( int i = 0; i < myOperationCollection->Count; i++ )
      {
         inputMsg = String::Concat( myOperationCollection[ i ]->Name, "SoapIn" );
         outputMsg = String::Concat( myOperationCollection[ i ]->Name, "SoapOut" );
         Console::WriteLine( " Operation = {0}", myOperationCollection[ i ]->Name );
         myNewPortType->Operations->Add( CreateOperation( myOperationCollection[ i ]->Name, inputMsg, outputMsg, myServiceDescription->TargetNamespace ) );

      }
      myPortTypeCollection->Add( myNewPortType );
      noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes : {0}", noOfPortTypes );
      myServiceDescription->Write( "MathService_New.wsdl" );
      // </Snippet3>
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception:{0}", e->Message );
   }

}
// </Snippet1>
