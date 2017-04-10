

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "2books.xml" );
   
   // Create a new element.
   XmlElement^ elem = doc->CreateElement( "misc" );
   elem->InnerText = "hardcover";
   elem->SetAttribute( "publisher", "WorldWide Publishing" );
   
   // Clone the element so we can add one to each of the book nodes.
   XmlNode^ elem2 = elem->CloneNode( true );
   
   // Add the new elements.
   doc->DocumentElement->FirstChild->AppendChild( elem );
   doc->DocumentElement->LastChild->AppendChild( elem2 );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
