#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   
   //Load the the document with the last book node.
   XmlTextReader^ reader = gcnew XmlTextReader( "books.xml" );
   reader->WhitespaceHandling = WhitespaceHandling::None;
   reader->MoveToContent();
   reader->Read();
   reader->Skip(); //Skip the first book.
   reader->Skip(); //Skip the second book.
   doc->Load( reader );
   doc->Save( Console::Out );
}
