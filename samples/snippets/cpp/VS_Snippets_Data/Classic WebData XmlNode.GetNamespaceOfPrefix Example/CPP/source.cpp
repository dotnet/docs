

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
   
   //Create a new attribute.
   String^ ns = root->GetNamespaceOfPrefix( "bk" );
   XmlNode^ attr = doc->CreateNode( XmlNodeType::Attribute, "genre", ns );
   attr->Value = "novel";
   
   //Add the attribute to the document.
   root->Attributes->SetNamedItem( attr );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
