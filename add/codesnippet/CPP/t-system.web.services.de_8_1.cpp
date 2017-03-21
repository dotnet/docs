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
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimeText_Binding_Match_8_Input_CPP.wsdl" );

      // Create a Binding.
      Binding^ myBinding = gcnew Binding;

      // Initialize the Name property of the Binding.
      myBinding->Name = "MimeText_Binding_MatchServiceHttpPost";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MimeText_Binding_MatchServiceHttpPost" );
      myBinding->Type = myXmlQualifiedName;

      // Create an HttpBinding.
      HttpBinding^ myHttpBinding = gcnew HttpBinding;
      myHttpBinding->Verb = "POST";

      // Add the HttpBinding to the Binding.
      myBinding->Extensions->Add( myHttpBinding );

      // Create an OperationBinding.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "AddNumbers";
      HttpOperationBinding^ myHttpOperationBinding = gcnew HttpOperationBinding;
      myHttpOperationBinding->Location = "/AddNumbers";

      // Add the HttpOperationBinding to the OperationBinding.
      myOperationBinding->Extensions->Add( myHttpOperationBinding );

      // Create an InputBinding.
      InputBinding^ myInputBinding = gcnew InputBinding;
      MimeContentBinding^ postMimeContentbinding = gcnew MimeContentBinding;
      postMimeContentbinding->Type = "application/x-www-form-urlencoded";
      myInputBinding->Extensions->Add( postMimeContentbinding );

      // Add the InputBinding to the OperationBinding.
      myOperationBinding->Input = myInputBinding;

      // Create an OutputBinding.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;

      // Create a MimeTextBinding.
      MimeTextBinding^ myMimeTextBinding = gcnew MimeTextBinding;

      // Create a MimeTextMatch.
      MimeTextMatch^ myMimeTextMatch = gcnew MimeTextMatch;
      MimeTextMatchCollection^ myMimeTextMatchCollection;

      // Initialize properties of the MimeTextMatch.
      myMimeTextMatch->Name = "Title";
      myMimeTextMatch->Type = "*/*";
      myMimeTextMatch->Pattern = "'TITLE&gt;(.*?)&lt;";
      myMimeTextMatch->IgnoreCase = true;

      // Initialize a MimeTextMatchCollection.
      myMimeTextMatchCollection = myMimeTextBinding->Matches;

      // Add the MimeTextMatch to the MimeTextMatchCollection.
      myMimeTextMatchCollection->Add( myMimeTextMatch );
      myOutputBinding->Extensions->Add( myMimeTextBinding );

      // Add the OutputBinding to the OperationBinding.
      myOperationBinding->Output = myOutputBinding;

      // Add the OutputBinding to the OperationBinding.
      myOperationBinding->Output = myOutputBinding;

      // Add the OperationBinding to the Binding.
      myBinding->Operations->Add( myOperationBinding );

      // Add the Binding to the BindingCollection of the ServiceDescription.
      myServiceDescription->Bindings->Add( myBinding );

      // Write the ServiceDescription as a WSDL file.
      myServiceDescription->Write( "MimeText_Binding_Match_8_Output_CPP.wsdl" );
      Console::WriteLine( "WSDL file named 'MimeText_Binding_Match_8_Output_CPP.wsdl' was"
      " created successfully." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}