

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book>  <title>Oberon's Legacy</title>  <price>5.95</price></book>" );
   
   // Create a new element node.
   XmlNode^ newElem = doc->CreateNode( "element", "pages", "" );
   newElem->InnerText = "290";
   Console::WriteLine( "Add the new element to the document..." );
   XmlElement^ root = doc->DocumentElement;
   root->AppendChild( newElem );
   Console::WriteLine( "Display the modified XML document..." );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
