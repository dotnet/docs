// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "http://localhost/baseuri.xml" );
   
   //Display information on the attribute node. The value
   //returned for BaseURI is 'http://localhost/baseuri.xml'.
   XmlAttribute^ attr = doc->DocumentElement->Attributes[ 0 ];
   Console::WriteLine( "Name of the attribute:  {0}", attr->Name );
   Console::WriteLine( "Base URI of the attribute:  {0}", attr->BaseURI );
   Console::WriteLine( "The value of the attribute:  {0}", attr->InnerText );
}
// </Snippet1>
