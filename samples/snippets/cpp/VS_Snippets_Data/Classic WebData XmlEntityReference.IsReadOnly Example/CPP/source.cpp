

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<!DOCTYPE book [<!ENTITY h 'hardcover'>]>"
   "<book genre='novel' ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "<style>&h;</style>"
   "</book>" );
   
   // Check if the node is read-only.
   XmlEntityReference^ entref = dynamic_cast<XmlEntityReference^>(doc->DocumentElement->LastChild->FirstChild);
   if ( entref->IsReadOnly )
      Console::WriteLine( "Entity reference nodes are always read-only" );
}

// </Snippet1>
