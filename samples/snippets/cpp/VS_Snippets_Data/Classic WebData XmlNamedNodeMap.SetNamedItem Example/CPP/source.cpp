

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' publicationdate='1997'> <title>Pride And Prejudice</title></book>" );
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   
   // Add a new attribute to the collection.
   XmlAttribute^ attr = doc->CreateAttribute( "style" );
   attr->Value = "hardcover";
   attrColl->SetNamedItem( attr );
   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
