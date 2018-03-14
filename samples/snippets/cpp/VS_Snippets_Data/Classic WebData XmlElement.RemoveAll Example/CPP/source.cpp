

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   // Remove all attributes and child nodes from the book element.
   XmlElement^ root = doc->DocumentElement;
   root->RemoveAll();
   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->InnerXml );
}

// </Snippet1>
