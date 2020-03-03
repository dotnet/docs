

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Create a document fragment.
   XmlDocumentFragment^ docFrag = doc->CreateDocumentFragment();
   
   // Set the contents of the document fragment.
   docFrag->InnerXml = "<item>widget</item>";
   
   // Display the document fragment.
   Console::WriteLine( docFrag->InnerXml );
}

// </Snippet1>
