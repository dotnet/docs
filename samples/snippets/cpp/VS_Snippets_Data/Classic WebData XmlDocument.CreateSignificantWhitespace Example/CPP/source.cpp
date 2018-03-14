

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<author xml:space='preserve'><first-name>Eva</first-name><last-name>Corets</last-name></author>" );
   Console::WriteLine( "InnerText before..." );
   Console::WriteLine( doc->DocumentElement->InnerText );
   
   // Add white space.     
   XmlNode^ currNode = doc->DocumentElement;
   XmlSignificantWhitespace^ sigws = doc->CreateSignificantWhitespace( "\t" );
   currNode->InsertAfter( sigws, currNode->FirstChild );
   Console::WriteLine();
   Console::WriteLine( "InnerText after..." );
   Console::WriteLine( doc->DocumentElement->InnerText );
}

// </Snippet1>
