

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "</book>" );
   XmlNode^ root = doc->FirstChild;
   
   // Because WriteContentTo saves only the child nodes of the node
   // to the writer none of the attributes are displayed.
   Console::WriteLine( "Display the contents of the node..." );
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   root->WriteContentTo( writer );
}

// </Snippet1>
