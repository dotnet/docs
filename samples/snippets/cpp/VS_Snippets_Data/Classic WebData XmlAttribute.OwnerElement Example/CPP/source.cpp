

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book><title>Pride And Prejudice</title></book>" );
   
   //Create an attribute.
   XmlAttribute^ attr;
   attr = doc->CreateAttribute( "bk", "genre", "urn:samples" );
   attr->Value = "novel";
   
   //Try to display the attribute's owner element.
   if ( attr->OwnerElement == nullptr )
      Console::WriteLine( "The attribute has not been added to an element\r\n" );
   else
      Console::WriteLine( attr->OwnerElement->OuterXml );

   
   //Add the attribute to an element.
   doc->DocumentElement->SetAttributeNode( attr );
   
   //Display the attribute's owner element.
   Console::WriteLine( "Display the owner element..." );
   Console::WriteLine( attr->OwnerElement->OuterXml );
}

// </Snippet1>
