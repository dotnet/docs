

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Create a procesing instruction.
   XmlProcessingInstruction^ newPI;
   String^ PItext = "type='text/xsl' href='book.xsl'";
   newPI = doc->CreateProcessingInstruction( "xml-stylesheet", PItext );
   
   // Display the target and data information.
   Console::WriteLine( "<?{0} {1}?>", newPI->Target, newPI->Data );
   
   // Add the processing instruction node to the document.
   doc->AppendChild( newPI );
}

// </Snippet1>
