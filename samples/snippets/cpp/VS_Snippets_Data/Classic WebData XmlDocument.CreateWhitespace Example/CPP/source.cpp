

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<author><first-name>Eva</first-name><last-name>Corets</last-name></author>" );
   Console::WriteLine( "InnerText before..." );
   Console::WriteLine( doc->DocumentElement->InnerText );
   
   // Add white space.     
   XmlNode^ currNode = doc->DocumentElement;
   XmlWhitespace^ ws = doc->CreateWhitespace( "\r\n" );
   currNode->InsertAfter( ws, currNode->FirstChild );
   Console::WriteLine();
   Console::WriteLine( "InnerText after..." );
   Console::WriteLine( doc->DocumentElement->InnerText );
}

// </Snippet1>
