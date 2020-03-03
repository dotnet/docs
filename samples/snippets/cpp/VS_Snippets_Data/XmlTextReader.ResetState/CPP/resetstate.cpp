

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Xml;
int main()
{
   Encoding^ enc = gcnew UTF8Encoding;
   array<Byte>^utf8Buffer = enc->GetBytes( "<root> 12345 </root>" );
   enc = gcnew UnicodeEncoding;
   array<Byte>^unicodeBuffer = enc->GetBytes( "<?xml version='1.0' ?><unicode> root </unicode>" );
   MemoryStream^ memStrm = gcnew MemoryStream;
   memStrm->Write( unicodeBuffer, 0, unicodeBuffer->Length );
   memStrm->Write( utf8Buffer, 0, utf8Buffer->Length );
   memStrm->Position = 0;
   XmlTextReader^ reader = gcnew XmlTextReader( memStrm );
   while ( reader->Read() )
   {
      Console::WriteLine( "NodeType: {0}", reader->NodeType );
      if ( XmlNodeType::EndElement == reader->NodeType && "root" == reader->Name )
            break;
      if ( XmlNodeType::EndElement == reader->NodeType )
            reader->ResetState();
   }
}

//</snippet1>
