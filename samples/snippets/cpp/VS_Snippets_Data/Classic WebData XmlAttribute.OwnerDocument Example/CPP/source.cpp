

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book><title>Pride And Prejudice</title></book>" );
   
   //Create an attribute.
   XmlAttribute^ attr;
   attr = doc->CreateAttribute( "bk", "genre", "urn:samples" );
   attr->Value = "novel";
   
   //Display the attribute's owner document. Note
   //that although the attribute has not been inserted
   //into the document, it still has an owner document.
   Console::WriteLine( attr->OwnerDocument->OuterXml );
}

// </Snippet1>
