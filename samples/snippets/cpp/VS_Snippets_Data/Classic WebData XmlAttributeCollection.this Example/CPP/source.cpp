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
   Console::WriteLine( "Display all the attributes in the collection...\r\n" );
   for ( int i = 0; i < attrColl->Count; i++ )
   {
      Console::Write( "{0} = ", attrColl[ i ]->Name );
      Console::Write( "{0}", attrColl[ i ]->Value );
      Console::WriteLine();

   }
}
// </Snippet1>
