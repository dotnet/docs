/*
* The following example demonstrates the 'Item[String*]' property of
FaultBindingCollection class 
* The program removes a fault binding with the name 'ErrorString' 
from the WSDL file. It also removes a operation fault with the name 
'ErrorString' and displays the resultant WSDL file to the console.
* 
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   
   // Read the 'StockQuote::wsdl' file as input.
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "StockQuote.wsdl" );
   
   // Get the operation fault collection and remove the operation fault with the name 'ErrorString'.
   PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
   PortType^ myPortType = myPortTypeCollection[ 0 ];
   OperationCollection^ myOperationCollection = myPortType->Operations;
   Operation^ myOperation = myOperationCollection[ 0 ];
   OperationFaultCollection^ myOperationFaultCollection = myOperation->Faults;
   if ( myOperationFaultCollection->Contains( myOperationFaultCollection[ "ErrorString" ] ) )
      myOperationFaultCollection->Remove( myOperationFaultCollection[ "ErrorString" ] );

   
   // Get the fault binding collection and remove the fault binding with the name 'ErrorString'.
   // <Snippet1>
   BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
   Binding^ myBinding = myBindingCollection[ 0 ];
   OperationBindingCollection^ myOperationBindingCollection = myBinding->Operations;
   OperationBinding^ myOperationBinding = myOperationBindingCollection[ 0 ];
   FaultBindingCollection^ myFaultBindingCollection = myOperationBinding->Faults;
   if ( myFaultBindingCollection->Contains( myFaultBindingCollection[ "ErrorString" ] ) )
      myFaultBindingCollection->Remove( myFaultBindingCollection[ "ErrorString" ] );

   
   // </Snippet1>
   myServiceDescription->Write( Console::Out );
}
