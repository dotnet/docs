

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   XmlElement^ root = doc->DocumentElement;
   
   // Remove the genre attribute.
   root->RemoveAttribute( "genre" );
   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->InnerXml );
}

// </Snippet1>
