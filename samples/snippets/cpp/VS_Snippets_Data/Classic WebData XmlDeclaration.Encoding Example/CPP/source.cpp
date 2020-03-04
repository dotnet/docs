

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create and load the XML document.
   XmlDocument^ doc = gcnew XmlDocument;
   String^ xmlString = "<book><title>Oberon's Legacy</title></book>";
   doc->Load( gcnew StringReader( xmlString ) );
   
   // Create an XML declaration. 
   XmlDeclaration^ xmldecl;
   xmldecl = doc->CreateXmlDeclaration( "1.0", nullptr, nullptr );
   xmldecl->Encoding = "UTF-8";
   xmldecl->Standalone = "yes";
   
   // Add the new node to the document.
   XmlElement^ root = doc->DocumentElement;
   doc->InsertBefore( xmldecl, root );
   
   // Display the modified XML document 
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
