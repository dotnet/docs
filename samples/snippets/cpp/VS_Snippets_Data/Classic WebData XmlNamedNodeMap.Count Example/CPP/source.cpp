

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' publicationdate='1997'>   <title>Pride And Prejudice</title></book>" );
   XmlAttributeCollection^ attrColl = doc->DocumentElement->Attributes;
   Console::WriteLine( "Display all the attributes for this book..." );
   for ( int i = 0; i < attrColl->Count; i++ )
   {
      Console::WriteLine( "{0} = {1}", attrColl->Item( i )->Name, attrColl->Item( i )->Value );

   }
}

// </Snippet1>
