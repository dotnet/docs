

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book xmlns:bk='urn:samples' bk:genre='novel'><title>Pride And Prejudice</title></book>" );
   
   //Create an attribute collection.
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   Console::WriteLine( "Display information on each of the attributes... \r\n" );
   System::Collections::IEnumerator^ myEnum = attrColl->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      XmlAttribute^ attr = safe_cast<XmlAttribute^>(myEnum->Current);
      Console::Write( "{0} = {1}", attr->Name, attr->Value );
      Console::WriteLine( "\t namespaceURI={0}", attr->NamespaceURI );
   }
}

// </Snippet1>
