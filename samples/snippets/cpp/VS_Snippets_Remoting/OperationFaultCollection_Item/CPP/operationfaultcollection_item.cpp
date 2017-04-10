// System::Web::Services::Description.OperationFaultCollection::Item->Item[String*]

/*
The following example demonstrates the 'Item' property of the
'OperationFaultCollection' class. The program removes a fault binding
with the name 'ErrorString' from the WSDL file. It also removes an
operation fault with the name 'ErrorString' and generates a WSDL file.
*/

#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
int main()
{
   try
   {
      // Read the 'StockQuote::wsdl' file as input.
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "StockQuote_cpp.wsdl" );

      // Remove the operation fault with the name 'ErrorString'.
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      PortType^ myPortType = myPortTypeCollection[ 0 ];
      OperationCollection^ myOperationCollection = myPortType->Operations;
      Operation^ myOperation = myOperationCollection[ 0 ];

      // <Snippet1>
      OperationFaultCollection^ myOperationFaultCollection = myOperation->Faults;
      OperationFault^ myOperationFault = myOperationFaultCollection[ "ErrorString" ];
      if ( myOperationFault != nullptr )
            myOperationFaultCollection->Remove( myOperationFault );
      // </Snippet1>

      // Remove the fault binding with the name 'ErrorString'.
      BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
      Binding^ myBinding = myBindingCollection[ 0 ];
      OperationBindingCollection^ myOperationBindingCollection = myBinding->Operations;
      OperationBinding^ myOperationBinding = myOperationBindingCollection[ 0 ];
      FaultBindingCollection^ myFaultBindingCollection = myOperationBinding->Faults;
      if ( myFaultBindingCollection->Contains( myFaultBindingCollection[ "ErrorString" ] ) )
            myFaultBindingCollection->Remove( myFaultBindingCollection[ "ErrorString" ] );
      myServiceDescription->Write( "OperationFaultCollection_out.wsdl" );
      Console::WriteLine( "WSDL file with name 'OperationFaultCollection_out.wsdl'  created Successfully" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
