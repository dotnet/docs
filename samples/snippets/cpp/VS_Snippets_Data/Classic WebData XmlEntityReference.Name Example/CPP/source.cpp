

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<!DOCTYPE book [<!ENTITY h 'hardcover'>]>"
   "<book genre='novel' ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "<style>&h;</style>"
   "</book>" );
   
   // Display information on the entity reference node.
   XmlEntityReference^ entref = dynamic_cast<XmlEntityReference^>(doc->DocumentElement->LastChild->FirstChild);
   Console::WriteLine( "Name of the entity reference:  {0}", entref->Name );
   Console::WriteLine( "The entity replacement text:  {0}", entref->InnerText );
}

// </Snippet1>
