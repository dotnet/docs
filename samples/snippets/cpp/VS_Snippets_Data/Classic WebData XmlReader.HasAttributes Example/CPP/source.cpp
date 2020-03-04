#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;
using namespace System::Xml::Schema;

public ref class Class1
{
// <Snippet1>
public:
   void DisplayAttributes( XmlReader^ reader )
   {
      if ( reader->HasAttributes )
      {
         Console::WriteLine( "Attributes of <{0}>", reader->Name );
         while ( reader->MoveToNextAttribute() )
         {
            Console::WriteLine( " {0}={1}", reader->Name, reader->Value );
         }
      }
   }
// </Snippet1>
};
