

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Collections;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' publicationdate='1997' "
   "      ISBN='1-861001-57-5'>"
   "  <title>Pride And Prejudice</title>"
   "</book>" );
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   Console::WriteLine( "Display all the attributes for this book..." );
   IEnumerator^ ienum = attrColl->GetEnumerator();
   while ( ienum->MoveNext() )
   {
      XmlAttribute^ attr = dynamic_cast<XmlAttribute^>(ienum->Current);
      Console::WriteLine( "{0} = {1}", attr->Name, attr->Value );
   }
}

// </Snippet1>
