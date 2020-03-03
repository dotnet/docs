

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   XmlNode^ lastNode = doc->DocumentElement->LastChild;
   Console::WriteLine( "Last book..." );
   Console::WriteLine( lastNode->OuterXml );
   XmlNode^ prevNode = lastNode->PreviousSibling;
   Console::WriteLine( "\r\nPrevious book..." );
   Console::WriteLine( prevNode->OuterXml );
}

// </Snippet1>
