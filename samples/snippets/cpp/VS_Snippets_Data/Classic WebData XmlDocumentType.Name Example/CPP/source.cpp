

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
   
   // Display information on the DocumentType node.
   XmlDocumentType^ doctype = doc->DocumentType;
   Console::WriteLine( "Name of the document type:  {0}", doctype->Name );
   Console::WriteLine( "The internal subset of the document type:  {0}", doctype->InternalSubset );
}

// </Snippet1>
