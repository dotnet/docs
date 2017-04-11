// System::Web::Services::Description.MimePartCollection::MimePartCollection()
// System::Web::Services::Description.MimePartCollection::Item->Item[System::Int32 index]
// System::Web::Services::Description.MimePartCollection::Insert
// System::Web::Services::Description.MimePartCollection::IndexOf
// System::Web::Services::Description.MimePartCollection->Add
// System::Web::Services::Description.MimePartCollection::Contains
// System::Web::Services::Description.MimePartCollection::CopyTo
// System::Web::Services::Description.MimePartCollection::Remove

/* This program demostrates constructor, 'Item' property , 'Insert', 'IndexOf', 'Add',
'Contains', 'CopyTo', and 'Remove' methods of 'MimePartCollection' class.
It takes 'MimePartCollection_8_Input_cpp.wsdl' as an input file which contains
one 'MimePart' object that supports 'HttpPost'. A mimepartcollection object is
created and new mimepart objects are added to mimepartcollection using 'Insert'
and 'Add' methods. A mimepart object is removed from the mimepartcollection using
'Remove'method.The ServiceDescription is finally written into output wsdl file
'MimePartCollection_8_out_CS::wsdl'.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimePartCollection_8_Input_cpp.wsdl" );
   ServiceDescriptionCollection^ myServiceDescriptionCol = gcnew ServiceDescriptionCollection;
   myServiceDescriptionCol->Add( myServiceDescription );
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "MimeServiceHttpPost","http://tempuri.org/" );
   
   // Create a binding object.
   Binding^ myBinding = myServiceDescriptionCol->GetBinding( myXmlQualifiedName );
   OperationBinding^ myOperationBinding = nullptr;
   for ( int i = 0; i < myBinding->Operations->Count; i++ )
      if ( myBinding->Operations[ i ]->Name->Equals( "AddNumbers" ) )
            myOperationBinding = myBinding->Operations[ i ];

   OutputBinding^ myOutputBinding = myOperationBinding->Output;
   
   // <Snippet1>
   // <Snippet2>
   // <Snippet3>
   // <Snippet4>
   MimeMultipartRelatedBinding^ myMimeMultipartRelatedBinding = nullptr;
   IEnumerator^ myIEnumerator = myOutputBinding->Extensions->GetEnumerator();
   while ( myIEnumerator->MoveNext() )
      myMimeMultipartRelatedBinding = (MimeMultipartRelatedBinding^)myIEnumerator->Current;

   // Create an instance of 'MimePartCollection'.
   MimePartCollection^ myMimePartCollection = gcnew MimePartCollection;
   myMimePartCollection = myMimeMultipartRelatedBinding->Parts;
   Console::WriteLine( "Total number of mimepart elements in the collection initially  is: {0}", myMimePartCollection->Count );

   // Get the type of first 'Item' in collection.
   Console::WriteLine( "The first object in collection is of type: {0}", myMimePartCollection[ 0 ] );
   MimePart^ myMimePart1 = gcnew MimePart;

   // Create an instance of 'MimeXmlBinding'.
   MimeXmlBinding^ myMimeXmlBinding1 = gcnew MimeXmlBinding;
   myMimeXmlBinding1->Part = "body";
   myMimePart1->Extensions->Add( myMimeXmlBinding1 );

   //  a mimepart at first position.
   myMimePartCollection->Insert( 0, myMimePart1 );
   Console::WriteLine( "Inserting a mimepart object..." );

   // Check whether 'Insert' was successful or not.
   if ( myMimePartCollection->Contains( myMimePart1 ) )
   {
      // Display the index of inserted 'MimePart'.
      Console::WriteLine( "'MimePart' is succesfully inserted at position: {0}", myMimePartCollection->IndexOf( myMimePart1 ) );
   }
   // </Snippet4>
   // </Snippet3>
   // </Snippet2>
   // </Snippet1>

   Console::WriteLine( "Total number of mimepart elements after inserting is: {0}", myMimePartCollection->Count );
   
   // <Snippet5>
   // <Snippet6>
   MimePart^ myMimePart2 = gcnew MimePart;
   MimeXmlBinding^ myMimeXmlBinding2 = gcnew MimeXmlBinding;
   myMimeXmlBinding2->Part = "body";
   myMimePart2->Extensions->Add( myMimeXmlBinding2 );

   // Add a mimepart to the mimepartcollection.
   myMimePartCollection->Add( myMimePart2 );
   Console::WriteLine( "Adding a mimepart object..." );

   // Check if collection contains added mimepart object.
   if ( myMimePartCollection->Contains( myMimePart2 ) )
      Console::WriteLine( "'MimePart' is succesfully added at position: {0}", myMimePartCollection->IndexOf( myMimePart2 ) );
   // </Snippet6>
   // </Snippet5>

   Console::WriteLine( "Total number of mimepart elements after adding is: {0}", myMimePartCollection->Count );
   
   // <Snippet7>
   array<MimePart^>^myArray = gcnew array<MimePart^>(myMimePartCollection->Count);
   
   // Copy the mimepartcollection to an array.
   myMimePartCollection->CopyTo( myArray, 0 );
   Console::WriteLine( "Displaying the array copied from mimepartcollection" );
   for ( int j = 0; j < myMimePartCollection->Count; j++ )
   {
      Console::WriteLine( "Mimepart object at position : {0}", j );
      for ( int i = 0; i < myArray[ j ]->Extensions->Count; i++ )
      {
         MimeXmlBinding^ myMimeXmlBinding3 = (MimeXmlBinding^)(myArray[ j ]->Extensions[ i ]);
         Console::WriteLine( "Part: {0}", (myMimeXmlBinding3->Part) );
      }
   }
   // </Snippet7>
   // <Snippet8>
   Console::WriteLine( "Removing a mimepart object..." );
   
   // Remove the mimepart from the mimepartcollection.
   myMimePartCollection->Remove( myMimePart1 );
   
   // Check whether the mimepart is removed or not.
   if (  !myMimePartCollection->Contains( myMimePart1 ) )
      Console::WriteLine( "Mimepart is succesfully removed from mimepartcollection" );
   // </Snippet8>

   Console::WriteLine( "Total number of elements in collection after removing is: {0}", myMimePartCollection->Count );
   array<MimePart^>^myArray1 = gcnew array<MimePart^>(myMimePartCollection->Count);
   myMimePartCollection->CopyTo( myArray1, 0 );
   Console::WriteLine( "Dispalying the 'MimePartCollection' after removing" );
   for ( int j = 0; j < myMimePartCollection->Count; j++ )
   {
      Console::WriteLine( "Mimepart object at position : {0}", j );
      for ( int i = 0; i < myArray1[ j ]->Extensions->Count; i++ )
      {
         MimeXmlBinding^ myMimeXmlBinding3 = (MimeXmlBinding^)(myArray1[ j ]->Extensions[ i ]);
         Console::WriteLine( "part: {0}", (myMimeXmlBinding3->Part) );
      }
   }
   myServiceDescription->Write( "MimePartCollection_8_output.wsdl" );
   Console::WriteLine( "MimePartCollection_8_output.wsdl has been generated successfully." );
}
