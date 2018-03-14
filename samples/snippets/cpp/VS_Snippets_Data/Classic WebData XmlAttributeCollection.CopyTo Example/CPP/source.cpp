

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   
   //Create an attribute collection.
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   
   //Declare the array.
   array<XmlAttribute^>^arr = gcnew array<XmlAttribute^>(2);
   int index = 0;
   
   //Copy all the attributes into the array.
   attrColl->CopyTo( arr, index );
   Console::WriteLine( "Display all the attributes in the array.." );
   System::Collections::IEnumerator^ myEnum = arr->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      XmlAttribute^ attr = safe_cast<XmlAttribute^>(myEnum->Current);
      Console::WriteLine( "{0} = {1}", attr->Name, attr->Value );
   }
}

// </Snippet1>
