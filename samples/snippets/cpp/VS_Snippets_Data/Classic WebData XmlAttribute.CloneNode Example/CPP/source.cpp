

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create an XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "2elems.xml" );
   
   //Create an attribute.
   XmlAttribute^ attr;
   attr = doc->CreateAttribute( "bk", "genre", "urn:samples" );
   attr->Value = "novel";
   
   //Add the attribute to the first book.
   XmlElement^ currNode = dynamic_cast<XmlElement^>(doc->DocumentElement->FirstChild);
   currNode->SetAttributeNode( attr );
   
   //An attribute cannot be added to two different elements.  
   //You must clone the attribute and add it to the second book.
   XmlAttribute^ attr2;
   attr2 = dynamic_cast<XmlAttribute^>(attr->CloneNode( true ));
   currNode = dynamic_cast<XmlElement^>(doc->DocumentElement->LastChild);
   currNode->SetAttributeNode( attr2 );
   Console::WriteLine( "Display the modified XML...\r\n" );
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   doc->WriteContentTo( writer );
}

// </Snippet1>
