   // From textReaderText, create a continuous paragraph 
   // with two spaces between each sentence.
      String^ aLine;
   String^ aParagraph;
   StringReader^ strReader = gcnew StringReader( textReaderText );
   while ( true )
   {
      aLine = strReader->ReadLine();
      if ( aLine != nullptr )
      {
         aParagraph = String::Concat( aParagraph, aLine,  " " );
      }
      else
      {
         aParagraph = String::Concat( aParagraph,  "\n" );
         break;
      }
   }

   Console::WriteLine(  "Modified text:\n\n{0}", aParagraph );
   