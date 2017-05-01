

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlTextWriter^ writer = nullptr;
   try
   {
      writer = gcnew XmlTextWriter( Console::Out );
      
      // Write an element.
      writer->WriteStartElement( "address" );
      
      // Write an e-mail address using entities
      // for the @ and . characters.
      writer->WriteString( "someone" );
      writer->WriteCharEntity( '@' );
      writer->WriteString( "example" );
      writer->WriteCharEntity( '.' );
      writer->WriteString( "com" );
      writer->WriteEndElement();
   }
   finally
   {
      
      // Close the writer.
      if ( writer != nullptr )
            writer->Close();
   }

}

// </Snippet1>
