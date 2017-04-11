

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
   
   // Display the owner document of the document fragment.
   Console::WriteLine( docFrag->OwnerDocument->OuterXml );
   
   // Add nodes to the document fragment. Notice that the
   // new element is created using the owner document of 
   // the document fragment.
   XmlElement^ elem = doc->CreateElement( "item" );
   elem->InnerText = "widget";
   docFrag->AppendChild( elem );
   Console::WriteLine( "Display the document fragment..." );
   Console::WriteLine( docFrag->OuterXml );
}

// </Snippet1>
