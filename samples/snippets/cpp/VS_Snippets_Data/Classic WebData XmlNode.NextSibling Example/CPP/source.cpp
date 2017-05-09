

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   XmlNode^ currNode = doc->DocumentElement->FirstChild;
   Console::WriteLine( "First book..." );
   Console::WriteLine( currNode->OuterXml );
   XmlNode^ nextNode = currNode->NextSibling;
   Console::WriteLine( "\r\nSecond book..." );
   Console::WriteLine( nextNode->OuterXml );
}

// </Snippet1>
