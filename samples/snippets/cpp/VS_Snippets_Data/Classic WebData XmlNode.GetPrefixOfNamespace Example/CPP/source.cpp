

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "</book>" );
   XmlNode^ root = doc->FirstChild;
   
   //Create a new node.
   String^ prefix = root->GetPrefixOfNamespace( "urn:samples" );
   XmlElement^ elem = doc->CreateElement( prefix, "style", "urn:samples" );
   elem->InnerText = "hardcover";
   
   //Add the node to the document.
   root->AppendChild( elem );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
