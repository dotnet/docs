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