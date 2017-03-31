

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;

int main()
{
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   Uri^ baseUri = gcnew Uri( "http://servername/tmp/test.xsl" );
   Uri^ fulluri = resolver->ResolveUri( baseUri, "includefile.xsl" );

   // Get a stream object containing the XSL file
   Stream^ s = dynamic_cast<Stream^>(resolver->GetEntity( fulluri, nullptr, Stream::typeid ));

   // Read the stream object displaying the contents of the XSL file
   XmlTextReader^ reader = gcnew XmlTextReader( s );
   while ( reader->Read() )
   {
      Console::WriteLine( reader->ReadOuterXml() );
   }
}
// </Snippet1>
