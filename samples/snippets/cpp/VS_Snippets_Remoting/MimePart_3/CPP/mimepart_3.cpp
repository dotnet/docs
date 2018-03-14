

// System.Web.Services.Description.MimePart
// System.Web.Services.Description.MimePart.ctor()
// System.Web.Services.Description.MimePart.Extensions
/* The following program demonstrates the 'MimePart' class, constructor 
and 'Extensions' property of 'MimePart' class. It reads 
'MimePart_3_Input_cpp.wsdl' file which does not have 'MimePart' object
supporting 'OutPut' of 'HttpPost'. It adds the 'MimePart' and finally 
writes into 'MimePart_3_OutPut_cpp.wsdl' file.
*/
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimePart_3_Input_cpp.wsdl" );
   ServiceDescriptionCollection^ myServiceDescriptionCol = gcnew ServiceDescriptionCollection;
   myServiceDescriptionCol->Add( myServiceDescription );
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "MimeServiceHttpPost","http://tempuri.org/" );

   // Create the Binding.
   Binding^ myBinding = myServiceDescriptionCol->GetBinding( myXmlQualifiedName );
   OperationBinding^ myOperationBinding = nullptr;
   for ( int i = 0; i < myBinding->Operations->Count; i++ )
   {
      if ( myBinding->Operations[ i ]->Name->Equals( "AddNumbers" ) )
      {
         myOperationBinding = myBinding->Operations[ i ];
      }
   }

   // <Snippet2>
   // <Snippet3>
   // Create the OutputBinding.
   OutputBinding^ myOutputBinding = myOperationBinding->Output;
   MimeXmlBinding^ myMimeXmlBinding = gcnew MimeXmlBinding;
   myMimeXmlBinding->Part = "body";

   // Create the MimePart.
   MimePart^ myMimePart = gcnew MimePart;
   myMimePart->Extensions->Add( myMimeXmlBinding );
   MimeMultipartRelatedBinding^ myMimePartRelatedBinding = gcnew MimeMultipartRelatedBinding;

   // Add the MimePart to the MimePartRelatedBinding.
   myMimePartRelatedBinding->Parts->Add( myMimePart );
   myOutputBinding->Extensions->Add( myMimePartRelatedBinding );
   // </Snippet3>
   // </Snippet2>

   myServiceDescription->Write( "MimePart_3_Output_CPP.wsdl" );
   Console::WriteLine( "MimePart_3_Output_CPP.wsdl has been generated successfully." );
}
// </Snippet1>
