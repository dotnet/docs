

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book>  <title>Oberon's Legacy</title>  <price>5.95</price></book>" );
   
   // Create a new element node.
   XmlNode^ newElem;
   newElem = doc->CreateNode( XmlNodeType::Element, "g" , "ISBN" , "https://global.ISBN/list" );
   newElem->InnerText = "1-861001-57-5";
    
   // Add the new element to the document
   XmlElement^ root = doc->DocumentElement;
   root->AppendChild( newElem );
    
   // Display the modified XML document
   Console::WriteLine( doc->OuterXml );
    
    // Output:
    // <book><title>Oberon's Legacy</title><price>5.95</price><g:ISBN xmlns:g="https://global.ISBN/list">1-861001-57-5</g:ISBN></book>
}

// </Snippet1>
