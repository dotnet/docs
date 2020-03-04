#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;

public ref class Class1
{
   // <Snippet1>
public:
   void DisplayAttributes( XmlReader^ reader )
   {
      if ( reader->HasAttributes )
      {
         Console::WriteLine( "Attributes of <{0}>", reader->Name );
         for ( int i = 0; i < reader->AttributeCount; i++ )
         {
            reader->MoveToAttribute( i );
            Console::Write( " {0}={1}", reader->Name, reader->Value );

         }
         reader->MoveToElement(); //Moves the reader back to the element node.
      }
   }
   // </Snippet1>
};
