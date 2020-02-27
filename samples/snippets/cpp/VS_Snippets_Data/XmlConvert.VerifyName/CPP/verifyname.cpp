

//<snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlTextWriter^ writer = gcnew XmlTextWriter( "out.xml", nullptr );
   String^ tag = "item name";
   try
   {
      
      // Write the root element.
      writer->WriteStartElement( "root" );
      writer->WriteStartElement( XmlConvert::VerifyName( tag ) );
   }
   catch ( XmlException^ e ) 
   {
      Console::WriteLine( e->Message );
      Console::WriteLine( "Convert to a valid name..." );
      writer->WriteStartElement( XmlConvert::EncodeName( tag ) );
   }

   writer->WriteString( "hammer" );
   writer->WriteEndElement();
   
   // Write the end tag for the root element.
   writer->WriteEndElement();
   writer->Close();
}

//</snippet1>
