#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Sample
{
private:
   // <Snippet1>
   void serializer_UnknownNode( Object^ /*sender*/, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode Name: {0}", e->Name );
   }
   // </Snippet1>
};
