

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
   //The text node is the content of the price element.
   XmlElement^ elem = doc->CreateElement( "price" );
   XmlText^ text = doc->CreateTextNode( "19.95" );
   doc->DocumentElement->AppendChild( elem );
   doc->DocumentElement->LastChild->AppendChild( text );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
