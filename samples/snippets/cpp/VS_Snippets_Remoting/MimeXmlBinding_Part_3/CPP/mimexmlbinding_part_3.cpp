

// System.Web.Services.Description.MimeXmlBinding
// System.Web.Services.Description.MimeXmlBinding.MimeXmlBinding()
// System.Web.Services.Description.MimeXmlBinding.Part
/* The following program demonstrates constructor and 'Part'property
of 'MimeXmlBinding' class. This program takes 'MimeXmlBinding_Part_3_Input_CPP.wsdl'
as input, which does not contain 'Binding' object that supports 'HttpPost'.
It sets message part property to 'Body' on which 'MimeXmlBinding' is
applied and finally writes into 'MimeXmlBinding_Part_3_Output_CPP.wsdl'.
*/
// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;
int main()
{
   try
   {
      ServiceDescription^ myDescription = ServiceDescription::Read( "MimeXmlBinding_Part_3_Input_CPP.wsdl" );

      // Create the 'Binding' object.
      Binding^ myBinding = gcnew Binding;

      // Initialize 'Name' property of 'Binding' class.
      myBinding->Name = "MimeXmlBinding_Part_3_ServiceHttpPost";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MimeXmlBinding_Part_3_ServiceHttpPost" );
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
      MimeContentBinding^ myMimeContentBinding = gcnew MimeContentBinding;
      myMimeContentBinding->Type = "application/x-www-form-urlencoded";
      myInputBinding->Extensions->Add( myMimeContentBinding );

      // Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding->Input = myInputBinding;

      // <Snippet2>
      // <Snippet3>
      // Create an OutputBinding.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      MimeXmlBinding^ myMimeXmlBinding = gcnew MimeXmlBinding;

      // Initialize the Part property of the MimeXmlBinding.
      myMimeXmlBinding->Part = "Body";

      // Add the MimeXmlBinding to the OutputBinding.
      myOutputBinding->Extensions->Add( myMimeXmlBinding );
      // </Snippet3>
      // </Snippet2>

      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutputBinding;

      // Add the 'OperationBinding' to 'Binding'.
      myBinding->Operations->Add( myOperationBinding );

      // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription->Bindings->Add( myBinding );

      // Write the 'ServiceDescription' as a WSDL file.
      myDescription->Write( "MimeXmlBinding_Part_3_Output_CPP.wsdl" );
      Console::WriteLine( "WSDL file with name 'MimeXmlBinding_Part_3_Output_CPP.wsdl' is"
      " created successfully." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
