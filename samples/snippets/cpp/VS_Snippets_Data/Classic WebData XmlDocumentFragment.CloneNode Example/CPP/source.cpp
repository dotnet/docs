

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<items/>" );
   
   // Create a document fragment.
   XmlDocumentFragment^ docFrag = doc->CreateDocumentFragment();
   
   // Set the contents of the document fragment.
   docFrag->InnerXml = "<item>widget</item>";
   
   // Create a deep clone.  The cloned node
   // includes child nodes.
   XmlNode^ deep = docFrag->CloneNode( true );
   Console::WriteLine( "Name: {0}", deep->Name );
   Console::WriteLine( "OuterXml: {0}", deep->OuterXml );
   
   // Create a shallow clone.  The cloned node does
   // not include any child nodes.
   XmlNode^ shallow = docFrag->CloneNode( false );
   Console::WriteLine( "Name: {0}", shallow->Name );
   Console::WriteLine( "OuterXml: {0}", shallow->OuterXml );
}

// </Snippet1>
