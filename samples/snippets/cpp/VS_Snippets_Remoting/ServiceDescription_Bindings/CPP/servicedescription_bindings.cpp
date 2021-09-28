// System.Web.Services.Description.ServiceDescription.Bindings

/* 
The following example demonstrates the property 'Bindings' of 
'ServiceDescription' class. The input to the program is a WSDL file 
'MyWsdl_CS.wsdl'. This program removes one 'Binding' from the existing WSDL.
A new Binding is defined and added to the ServiceDescription object.
The program generates a new Web Service Description document.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services;
using namespace System::Web::Services::Description;
using namespace System::Xml;

// Used to create OperationBinding instances within 'Binding'.
OperationBinding^ CreateOperationBinding( String^ operation, String^ targetNamespace )
{
   // Create OperationBinding instance for operation.
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = operation;

   // Create InputBinding for operation.
   InputBinding^ myInputBinding = gcnew InputBinding;
   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   myInputBinding->Extensions->Add( mySoapBodyBinding );

   // Create OutputBinding for operation.
   OutputBinding^ myOutputBinding = gcnew OutputBinding;
   myOutputBinding->Extensions->Add( mySoapBodyBinding );

   // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
   myOperationBinding->Input = myInputBinding;
   myOperationBinding->Output = myOutputBinding;

   // Create extensibility element for 'SoapOperationBinding'.
   SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
   mySoapOperationBinding->Style = SoapBindingStyle::Document;
   mySoapOperationBinding->SoapAction = targetNamespace + operation;

   // Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
   myOperationBinding->Extensions->Add( mySoapOperationBinding );
   return myOperationBinding;
}

int main()
{
   try
   {
      // <Snippet1>
      // Obtain the ServiceDescription from existing WSDL.
      ServiceDescription^ myDescription = ServiceDescription::Read( "MyWsdl_CS.wsdl" );

      // Remove the Binding from the BindingCollection of 
      // the ServiceDescription.
      BindingCollection^ myBindingCollection = myDescription->Bindings;
      myBindingCollection->Remove( myBindingCollection[ 0 ] );

      // Form a new Binding.
      Binding^ myBinding = gcnew Binding;
      myBinding->Name = "Service1Soap";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:Service1Soap" );
      myBinding->Type = myXmlQualifiedName;
      SoapBinding^ mySoapBinding = gcnew SoapBinding;
      mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
      mySoapBinding->Style = SoapBindingStyle::Document;
      OperationBinding^ addOperationBinding = CreateOperationBinding( "Add", myDescription->TargetNamespace );
      myBinding->Operations->Add( addOperationBinding );
      myBinding->Extensions->Add( mySoapBinding );

      // Add the Binding to the ServiceDescription.
      myDescription->Bindings->Add( myBinding );
      myDescription->Write( "MyOutWsdl.wsdl" );
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
