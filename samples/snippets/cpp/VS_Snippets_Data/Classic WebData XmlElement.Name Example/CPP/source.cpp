

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book xmlns:bk='urn:samples'>"
   "<bk:ISBN>1-861001-57-5</bk:ISBN>"
   "<title>Pride And Prejudice</title>"
   "</book>" );
   
   // Display information on the ISBN element.
   XmlElement^ elem = dynamic_cast<XmlElement^>(doc->DocumentElement->FirstChild);
   Console::Write( "{0} = {1}", elem->Name, elem->InnerText );
   Console::WriteLine( "\t namespaceURI={0}", elem->NamespaceURI );
}

// </Snippet1>
