

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book>  <title>Pride And Prejudice</title>  <price/></book>" );
   XmlElement^ currNode = dynamic_cast<XmlElement^>(doc->DocumentElement->LastChild);
   if ( currNode->IsEmpty )
      currNode->InnerXml = "19.95";

   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
