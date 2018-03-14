

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<items>"
   "  <item>First item</item>"
   "  <item>Second item</item>"
   "</items>" );
   
   //Get and display the last item node.
   XmlElement^ root = doc->DocumentElement;
   XmlNodeList^ nodeList = root->GetElementsByTagName( "item" );
   Console::WriteLine( nodeList->Item( 1 )->InnerXml );
}

// </Snippet1>
