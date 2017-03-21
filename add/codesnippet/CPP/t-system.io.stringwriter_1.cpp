using namespace System;
using namespace System::IO;
int main()
{
   String^ textReaderText = "TextReader is the abstract base "
   "class of StreamReader and StringReader, which read "
   "characters from streams and strings, respectively.\n\n"
   "Create an instance of TextReader to open a text file "
   "for reading a specified range of characters, or to "
   "create a reader based on an existing stream.\n\n"
   "You can also use an instance of TextReader to read "
   "text from a custom backing store using the same "
   "APIs you would use for a string or a stream.\n\n";
   Console::WriteLine(  "Original text:\n\n{0}", textReaderText );

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
   
   // Re-create textReaderText from aParagraph.
   int intCharacter;
   Char convertedCharacter;
   StringWriter^ strWriter = gcnew StringWriter;
   strReader = gcnew StringReader( aParagraph );
   while ( true )
   {
      intCharacter = strReader->Read();
      
      // Check for the end of the string 
      // before converting to a character.
      if ( intCharacter == -1 )
            break;

      
      convertedCharacter = Convert::ToChar( intCharacter );
      if ( convertedCharacter == '.' )
      {
         strWriter->Write(  ".\n\n" );
         
         // Bypass the spaces between sentences.
         strReader->Read();
         strReader->Read();
      }
      else
      {
         strWriter->Write( convertedCharacter );
      }
   }

   Console::WriteLine(  "\nOriginal text:\n\n{0}", strWriter->ToString() );
}
