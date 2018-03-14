

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "booksort.xml" );
   XmlNode^ book;
   XmlNode^ root = doc->DocumentElement;
   book = root->SelectSingleNode( "descendant::book[author/last-name='Austen']" );
   
   //Change the price on the book.
   book->LastChild->InnerText = "15.95";
   Console::WriteLine( "Display the modified XML document...." );
   doc->Save( Console::Out );
}

// </Snippet1>
