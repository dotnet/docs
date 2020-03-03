

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create an XML declaration. 
   XmlDeclaration^ xmldecl;
   xmldecl = doc->CreateXmlDeclaration( "1.0", nullptr, nullptr );
   
   //Add the new node to the document.
   XmlElement^ root = doc->DocumentElement;
   doc->InsertBefore( xmldecl, root );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
