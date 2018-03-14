

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   
   // Display the first two book nodes.
   XmlNode^ book = doc->DocumentElement->FirstChild;
   Console::WriteLine( book->OuterXml );
   Console::WriteLine();
   Console::WriteLine( book->NextSibling->OuterXml );
}

// </Snippet1>
