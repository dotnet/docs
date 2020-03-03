

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create a new node and add it to the document.
   XmlNode^ elem = doc->CreateNode( XmlNodeType::Element, "price", nullptr );
   elem->InnerText = "19.95";
   doc->DocumentElement->AppendChild( elem );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
