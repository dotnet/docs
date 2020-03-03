

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "http://localhost/uri.xml" );
   
   //Display information on the entity reference node.
   XmlEntityReference^ entref = dynamic_cast<XmlEntityReference^>(doc->DocumentElement->LastChild->FirstChild);
   Console::WriteLine( "Name of the entity reference:  {0}", entref->Name );
   Console::WriteLine( "Base URI of the entity reference:  {0}", entref->BaseURI );
   Console::WriteLine( "The entity replacement text:  {0}", entref->InnerText );
}

// </Snippet1>
