

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' publicationdate='1997'>   <title>Pride And Prejudice</title></book>" );
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   
   // Remove the publicationdate attribute.
   attrColl->RemoveNamedItem( "publicationdate" );
   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
