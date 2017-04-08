

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "<price>19.95</price>"
   "</book>" );
   XmlNode^ root = doc->FirstChild;
   
   //Create a deep clone.  The cloned node 
   //includes the child nodes.
   XmlNode^ deep = root->CloneNode( true );
   Console::WriteLine( deep->OuterXml );
   
   //Create a shallow clone.  The cloned node does not 
   //include the child nodes, but does include its attribute.
   XmlNode^ shallow = root->CloneNode( false );
   Console::WriteLine( shallow->OuterXml );
}

// </Snippet1>
