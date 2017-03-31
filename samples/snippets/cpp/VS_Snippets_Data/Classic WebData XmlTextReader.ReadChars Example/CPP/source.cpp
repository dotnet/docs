

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;

// Reads an XML document using ReadChars
int main()
{
   XmlTextReader^ reader = nullptr;
   String^ filename = "items.xml";
   try
   {
      
      // Declare variables used by ReadChars
      array<Char>^buffer;
      int iCnt = 0;
      int charbuffersize;
      
      // Load the reader with the data file.  Ignore white space.
      reader = gcnew XmlTextReader( filename );
      reader->WhitespaceHandling = WhitespaceHandling::None;
      
      // Set variables used by ReadChars.
      charbuffersize = 10;
      buffer = gcnew array<Char>(charbuffersize);
      
      // Parse the file.  Read the element content
      // using the ReadChars method.
      reader->MoveToContent();
      while ( (iCnt = reader->ReadChars( buffer, 0, charbuffersize )) > 0 )
      {
         
         // Print out chars read and the buffer contents.
         Console::WriteLine( "  Chars read to buffer:{0}", iCnt );
         Console::WriteLine( "  Buffer: [{0}]", gcnew String( buffer,0,iCnt ) );
         
         // Clear the buffer.
         Array::Clear( buffer, 0, charbuffersize );
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
