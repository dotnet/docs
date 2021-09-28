// System.Web.Services.Description.OperationBindingCollection
// System.Web.Services.Description.OperationBindingCollection.Contains
// System.Web.Services.Description.OperationBindingCollection.Add
// System.Web.Services.Description.OperationBindingCollection.Item
// System.Web.Services.Description.OperationBindingCollection.Remove
// System.Web.Services.Description.OperationBindingCollection.Insert
// System.Web.Services.Description.OperationBindingCollection.IndexOf
// System.Web.Services.Description.OperationBindingCollection.CopyTo

/*
The following example demonstrates the usage of the
'OperationBindingCollection' class, the 'Item' property and various methods of the
class. The input to the program is a WSDL file 'MathService_input_cpp.wsdl' without
the add operation binding of SOAP protocol. In this example the WSDL file
is modified to insert a new 'OperationBinding' for SOAP. The
'OperationBindingCollection' is populated based on WSDL document
structure defined in WSDL specification. The updated instance is then
written to 'MathService_new_cpp.wsdl'.
*/

// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
int main()
{
   try
   {
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input_cpp.wsdl" );
      
      // Add the OperationBinding for the Add operation.
      OperationBinding^ addOperationBinding = gcnew OperationBinding;
      String^ addOperation = "Add";
      String^ myTargetNamespace = myServiceDescription->TargetNamespace;
      addOperationBinding->Name = addOperation;
      
      // Add the InputBinding for the operation.
      InputBinding^ myInputBinding = gcnew InputBinding;
      SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
      mySoapBodyBinding->Use = SoapBindingUse::Literal;
      myInputBinding->Extensions->Add( mySoapBodyBinding );
      addOperationBinding->Input = myInputBinding;
      
      // Add the OutputBinding for the operation.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      myOutputBinding->Extensions->Add( mySoapBodyBinding );
      addOperationBinding->Output = myOutputBinding;
      
      // Add the extensibility element for the SoapOperationBinding.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->Style = SoapBindingStyle::Document;
      mySoapOperationBinding->SoapAction = String::Concat( myTargetNamespace, addOperation );
      addOperationBinding->Extensions->Add( mySoapOperationBinding );
      
      // Get the BindingCollection from the ServiceDescription.
      BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
      
      // Get the OperationBindingCollection of SOAP binding from
      // the BindingCollection.
      OperationBindingCollection^ myOperationBindingCollection = myBindingCollection[ 0 ]->Operations;
      
      // <Snippet2>
      // Check for the Add OperationBinding in the collection.
      bool contains = myOperationBindingCollection->Contains( addOperationBinding );
      Console::WriteLine( "\nWhether the collection contains the Add OperationBinding : {0}", contains );
      // </Snippet2>

      // <Snippet3>
      // Add the Add OperationBinding to the collection.
      myOperationBindingCollection->Add( addOperationBinding );
      Console::WriteLine( "\nAdded the OperationBinding of the Add"
      " operation to the collection." );
      // </Snippet3>

      // <Snippet4>
      // <Snippet5>
      // Get the OperationBinding of the Add operation from the collection.
      OperationBinding^ myOperationBinding = myOperationBindingCollection[ 3 ];

      // Remove the OperationBinding of the Add operation from
      // the collection.
      myOperationBindingCollection->Remove( myOperationBinding );
      Console::WriteLine( "\nRemoved the OperationBinding of the "
      "Add operation from the collection." );
      // </Snippet5>
      // </Snippet4>

      // <Snippet6>
      // <Snippet7>
      // Insert the OperationBinding of the Add operation at index 0.
      myOperationBindingCollection->Insert( 0, addOperationBinding );
      Console::WriteLine( "\nInserted the OperationBinding of the "
      "Add operation in the collection." );

      // Get the index of the OperationBinding of the Add
      // operation from the collection.
      int index = myOperationBindingCollection->IndexOf( addOperationBinding );
      Console::WriteLine( "\nThe index of the OperationBinding of the Add operation : {0}", index );
      // </Snippet7>
      // </Snippet6>

      Console::WriteLine( "" );
      
      // <Snippet8>
      array<OperationBinding^>^operationBindingArray =
            gcnew array<OperationBinding^>(myOperationBindingCollection->Count);

      // Copy this collection to the OperationBinding array.
      myOperationBindingCollection->CopyTo( operationBindingArray, 0 );
      Console::WriteLine( "The operations supported by this service "
      "are :" );

      for each(OperationBinding^ myOperationBinding1 in operationBindingArray)
      {
         Binding^ myBinding = myOperationBinding1->Binding;
         Console::WriteLine(" Binding : "+ myBinding->Name + " Name of " +
            "operation : " + myOperationBinding1->Name);
      }
      // </Snippet8>

      // Save the ServiceDescription to an external file.
      myServiceDescription->Write( "MathService_new_cpp.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
// </Snippet1>
