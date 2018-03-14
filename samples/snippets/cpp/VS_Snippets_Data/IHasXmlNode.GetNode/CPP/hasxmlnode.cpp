

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::XPath;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   
   // Create an XPathNavigator and select all books by Plato.
   XPathNavigator^ nav = doc->CreateNavigator();
   XPathNodeIterator^ ni = nav->Select("descendant::book[author/name='Plato']");
   ni->MoveNext();
   
   // Get the first matching node and change the book price.
   XmlNode^ book = dynamic_cast<IHasXmlNode^>(ni->Current)->GetNode();
   book->LastChild->InnerText = "12.95";
   Console::WriteLine( book->OuterXml );
}

//</snippet1>
