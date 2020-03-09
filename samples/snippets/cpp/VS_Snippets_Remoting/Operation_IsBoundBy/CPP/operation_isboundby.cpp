// System.Web.Services.Description.Operation.IsBoundBy
/* The following program demonstrates the 'IsBoundBy' method of 
   'Operation' class. It takes "Operation_IsBoundBy_Input_CS.wsdl"
   as input which does not contain 'PortType' and 'Binding' objects
   supporting 'HttpPost'.It then adds those objects and writes into
   'Operation_IsBoundBy_Output_CS.wsdl'.
*/

#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Operation_IsBoundBy_Input_CS.wsdl" );

   // Create the 'Binding' object.
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "MyOperationIsBoundByServiceHttpPost";
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:OperationServiceHttpPost" );
   myBinding->Type = myXmlQualifiedName;
   
   // Create the 'HttpBinding' object.
   HttpBinding^ myHttpBinding = gcnew HttpBinding;
   myHttpBinding->Verb = "POST";
   
   // Add the 'HttpBinding' to the 'Binding'.
   myBinding->Extensions->Add( myHttpBinding );
   
   // Create the 'OperationBinding' object.
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = "AddNumbers";
   HttpOperationBinding^ myHttpOperationBinding = gcnew HttpOperationBinding;
   myHttpOperationBinding->Location = "/AddNumbers";
   
   // Add the 'HttpOperationBinding' to 'OperationBinding'.
   myOperationBinding->Extensions->Add( myHttpOperationBinding );
   
   // Create the 'InputBinding' object.
   InputBinding^ myInputBinding = gcnew InputBinding;
   MimeContentBinding^ myPostMimeContentBinding = gcnew MimeContentBinding;
   myPostMimeContentBinding->Type = "application/x-www-form-urlencoded";
   myInputBinding->Extensions->Add( myPostMimeContentBinding );
   
   // Add the 'InputBinding' to 'OperationBinding'.
   myOperationBinding->Input = myInputBinding;
   
   // Create the 'OutputBinding' object.
   OutputBinding^ myOutputBinding = gcnew OutputBinding;
   MimeXmlBinding^ myPostMimeXmlBinding = gcnew MimeXmlBinding;
   myPostMimeXmlBinding->Part = "Body";
   myOutputBinding->Extensions->Add( myPostMimeXmlBinding );
   
   // Add the 'OutPutBinding' to 'OperationBinding'.
   myOperationBinding->Output = myOutputBinding;
   
   // Add the 'OperationBinding' to 'Binding'.
   myBinding->Operations->Add( myOperationBinding );
   
   // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
   myServiceDescription->Bindings->Add( myBinding );
   
   // Create a 'PortType' object.
   PortType^ myPostPortType = gcnew PortType;
   myPostPortType->Name = "OperationServiceHttpPost";
   
// <Snippet1>
   Operation^ myPostOperation = gcnew Operation;
   myPostOperation->Name = myOperationBinding->Name;
   Console::WriteLine( "'Operation' instance uses 'OperationBinding': {0}",
      myPostOperation->IsBoundBy( myOperationBinding ) );
// </Snippet1>

   OperationMessage^ myOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationInput);
   myOperationMessage->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostIn" );
   OperationMessage^ myOperationMessage1 = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
   myOperationMessage1->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostOut" );
   myPostOperation->Messages->Add( myOperationMessage );
   myPostOperation->Messages->Add( myOperationMessage1 );
   
   // Add the 'Operation' to 'PortType'.
   myPostPortType->Operations->Add( myPostOperation );
   
   // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
   myServiceDescription->PortTypes->Add( myPostPortType );
   
   // Write the 'ServiceDescription' as a WSDL file.
   myServiceDescription->Write( "Operation_IsBoundBy_Output_CS.wsdl" );
   Console::WriteLine( "WSDL file with name 'Operation_IsBoundBy_Output_CS.wsdl' created Successfully" );
}
