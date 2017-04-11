/*
* The following example demonstrates the 'Remove', 'CopyTo', 'Insert', 
'Contains', 'IndexOf' method and 'Item[int]' property of FaultBindingCollection 
class
The program reverses the fault bindings that appear in the WSDL file. 
It also reverses the operation faults and displays the resultant WSDL file 
to the console.
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
   PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
   PortType^ myPortType = myPortTypeCollection[ 0 ];
   OperationCollection^ myOperationCollection = myPortType->Operations;
   Operation^ myOperation = myOperationCollection[ 0 ];
   OperationFaultCollection^ myOperationFaultCollection = myOperation->Faults;
   
   // Reverse the operation fault order.
   if ( myOperationFaultCollection->Count > 1 )
   {
      array<OperationFault^>^myOperationFaultArray = gcnew array<OperationFault^>(myOperationFaultCollection->Count);
      
      // Copy the operation fault to a temporary array.
      myOperationFaultCollection->CopyTo( myOperationFaultArray, 0 );
      
      // Remove all the operation fault instances in the fault binding collection.
      for ( int i = 0; i < myOperationFaultArray->Length; i++ )
         myOperationFaultCollection->Remove( myOperationFaultArray[ i ] );
      
      // Insert the operation fault instance in the reverse order.
      for ( int i = 0,j = (myOperationFaultArray->Length - 1); i < myOperationFaultArray->Length; i++,j-- )
         myOperationFaultCollection->Insert( i, myOperationFaultArray[ j ] );
   }
   
   // <Snippet1>
   // <Snippet2>
   // <Snippet3>
   // <Snippet4>
   // <Snippet5>
   // <Snippet6>
   BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
   Binding^ myBinding = myBindingCollection[ 0 ];
   OperationBindingCollection^ myOperationBindingCollection = myBinding->Operations;
   OperationBinding^ myOperationBinding = myOperationBindingCollection[ 0 ];
   FaultBindingCollection^ myFaultBindingCollection = myOperationBinding->Faults;
   
   // Reverse the fault bindings order.
   if ( myFaultBindingCollection->Count > 1 )
   {
      FaultBinding^ myFaultBinding = myFaultBindingCollection[ 0 ];
      array<FaultBinding^>^myFaultBindingArray = gcnew array<FaultBinding^>(myFaultBindingCollection->Count);
      
      // Copy the fault bindings to a temporary array.
      myFaultBindingCollection->CopyTo( myFaultBindingArray, 0 );
      
      // Remove all the fault binding instances in the fault binding collection.
      for ( int i = 0; i < myFaultBindingArray->Length; i++ )
         myFaultBindingCollection->Remove( myFaultBindingArray[ i ] );
      
      // Insert the fault binding instance in the reverse order.
      for ( int i = 0,j = (myFaultBindingArray->Length - 1); i < myFaultBindingArray->Length; i++,j-- )
         myFaultBindingCollection->Insert( i, myFaultBindingArray[ j ] );
      
      // Check if the first element in the collection before the reversal is now the last element.
      if ( myFaultBindingCollection->Contains( myFaultBinding ) && myFaultBindingCollection->IndexOf( myFaultBinding ) == (myFaultBindingCollection->Count - 1) )
            
      // Display the WSDL generated to the console.
      myServiceDescription->Write( Console::Out );
      else
            Console::WriteLine( "Error while reversing" );
   }
   // </Snippet6>
   // </Snippet5>
   // </Snippet4>
   // </Snippet3>
   // </Snippet2>
   // </Snippet1>
}
