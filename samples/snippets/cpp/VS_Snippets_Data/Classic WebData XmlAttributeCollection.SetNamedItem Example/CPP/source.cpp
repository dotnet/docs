

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create a new attribute.
   XmlAttribute^ newAttr = doc->CreateAttribute( "genre" );
   newAttr->Value = "novel";
   
   //Create an attribute collection and add the new attribute
   //to the collection.
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   attrColl->SetNamedItem( newAttr );
   Console::WriteLine( "Display the modified XML...\r\n" );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
