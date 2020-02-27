

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = gcnew XmlTextReader( "books.xml" );
   reader->WhitespaceHandling = WhitespaceHandling::None;
   
   // Move the reader to the first book element.
   reader->MoveToContent();
   reader->Read();
   
   // Create a writer that outputs to the console.
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   
   // Write the start tag.
   writer->WriteStartElement( "myBooks" );
   
   // Write the first book.
   writer->WriteNode( reader, false );
   
   // Skip the second book.
   reader->Skip();
   
   // Write the last book.
   writer->WriteNode( reader, false );
   writer->WriteEndElement();
   
   // Close the writer and the reader.
   writer->Close();
   reader->Close();
}

//</snippet1>
