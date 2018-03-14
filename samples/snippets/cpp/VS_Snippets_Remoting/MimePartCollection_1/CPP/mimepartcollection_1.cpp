// System::Web::Services::Description.MimePartCollection

/* The following program demostrates 'MimePartCollection' class. It
takes 'MimePartCollection_1_Input_cpp.wsdl' as input which
contains one 'MimePart' Object* that supports 'HttpPost'.
A mimepartcollection Object* is created and mimepart is added to the
mimepartcollection at the specified location, finally writes
into the file'MimePartCollection_1_Output_cpp.wsdl'.
*/

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimePartCollection_1_Input_cpp.wsdl" );
   ServiceDescriptionCollection^ myServiceDescriptionCol = gcnew ServiceDescriptionCollection;
   myServiceDescriptionCol->Add( myServiceDescription );
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "MimeServiceHttpPost","http://tempuri.org/" );
   
   // Create a 'Binding' object.
   Binding^ myBinding = myServiceDescriptionCol->GetBinding( myXmlQualifiedName );
   OperationBinding^ myOperationBinding = nullptr;
   for ( int i = 0; i < myBinding->Operations->Count; i++ )
      if ( myBinding->Operations[ i ]->Name->Equals( "AddNumbers" ) )
            myOperationBinding = myBinding->Operations[ i ];

   OutputBinding^ myOutputBinding = myOperationBinding->Output;
   MimeMultipartRelatedBinding^ myMimeMultipartRelatedBinding = nullptr;
   IEnumerator^ myIEnumerator = myOutputBinding->Extensions->GetEnumerator();
   while ( myIEnumerator->MoveNext() )
      myMimeMultipartRelatedBinding = dynamic_cast<MimeMultipartRelatedBinding^>(myIEnumerator->Current);

   // Create an instances of 'MimePartCollection'.
   MimePartCollection^ myMimePartCollection = gcnew MimePartCollection;
   myMimePartCollection = myMimeMultipartRelatedBinding->Parts;
   Console::WriteLine( "Total number of mimepart elements initially is: {0}", myMimePartCollection->Count );

   // Create an instance of 'MimePart'.
   MimePart^ myMimePart = gcnew MimePart;

   // Create an instance of 'MimeXmlBinding'.
   MimeXmlBinding^ myMimeXmlBinding = gcnew MimeXmlBinding;
   myMimeXmlBinding->Part = "body";
   myMimePart->Extensions->Add( myMimeXmlBinding );

   // Insert a mimepart at first position.
   myMimePartCollection->Insert( 0, myMimePart );
   Console::WriteLine( "Inserting a mimepart object..." );
   if ( myMimePartCollection->Contains( myMimePart ) )
   {
      Console::WriteLine( "'MimePart' is succesffully added at position: {0}", myMimePartCollection->IndexOf( myMimePart ) );
      Console::WriteLine( "Total number of mimepart elements after inserting is: {0}", myMimePartCollection->Count );
   }

   myServiceDescription->Write( "MimePartCollection_1_Output_cpp.wsdl" );
   Console::WriteLine( "MimePartCollection_1_Output_cpp.wsdl has been generated successfully." );
}
// </Snippet1>
