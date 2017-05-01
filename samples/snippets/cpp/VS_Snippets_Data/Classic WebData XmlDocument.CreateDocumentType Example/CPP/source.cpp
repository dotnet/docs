

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   
   //Create a document type node and  
   //add it to the document.
   XmlDocumentType^ doctype;
   doctype = doc->CreateDocumentType( "book", nullptr, nullptr, "<!ELEMENT book ANY>" );
   doc->AppendChild( doctype );
   
   //Create the root element and 
   //add it to the document.
   doc->AppendChild( doc->CreateElement( "book" ) );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
