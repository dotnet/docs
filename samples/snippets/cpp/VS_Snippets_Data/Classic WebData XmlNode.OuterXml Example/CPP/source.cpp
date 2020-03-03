

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "</book>" );
   XmlNode^ root = doc->DocumentElement;
   
   // OuterXml includes the markup of current node.
   Console::WriteLine( "Display the OuterXml property..." );
   Console::WriteLine( root->OuterXml );
   
   // InnerXml does not include the markup of the current node.
   // As a result, the attributes are not displayed.
   Console::WriteLine();
   Console::WriteLine( "Display the InnerXml property..." );
   Console::WriteLine( root->InnerXml );
}

// </Snippet1>
