

//<snippet1>
#using <System.dll>
#using <System.XML.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Encode and decode a name with spaces.
   String^ name1 = XmlConvert::EncodeName( "Order Detail" );
   Console::WriteLine( "Encoded name: {0}", name1 );
   Console::WriteLine( "Decoded name: {0}", XmlConvert::DecodeName( name1 ) );
   
   // Encode and decode a local name.
   String^ name2 = XmlConvert::EncodeLocalName( "a:book" );
   Console::WriteLine( "Encoded local name: {0}", name2 );
   Console::WriteLine( "Decoded local name: {0}", XmlConvert::DecodeName( name2 ) );
}

//</snippet1>
