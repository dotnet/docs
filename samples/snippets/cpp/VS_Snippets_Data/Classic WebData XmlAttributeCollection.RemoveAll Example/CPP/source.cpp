

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create an attribute collection and remove all attributes
   //from the collection.
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   attrColl->RemoveAll();
   Console::WriteLine( "Display the modified XML...\r\n" );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
