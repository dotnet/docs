

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create a deep clone.  The cloned node 
   //includes the child node.
   XmlDocument^ deep = dynamic_cast<XmlDocument^>(doc->CloneNode( true ));
   Console::WriteLine( deep->ChildNodes->Count );
   
   //Create a shallow clone.  The cloned node does not 
   //include the child node.
   XmlDocument^ shallow = dynamic_cast<XmlDocument^>(doc->CloneNode( false ));
   Console::WriteLine( "{0}{1}", shallow->Name, shallow->OuterXml );
   Console::WriteLine( shallow->ChildNodes->Count );
}

// </Snippet1>
