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