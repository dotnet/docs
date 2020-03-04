#using <System.dll>
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
   void DisplaySchemas( XmlSchemaCollection^ xsc )
   {
      XmlSchemaCollectionEnumerator^ ienum = xsc->GetEnumerator();
      while ( ienum->MoveNext() )
      {
         XmlSchema^ schema = ienum->Current;
         StringWriter^ sw = gcnew StringWriter;
         XmlTextWriter^ writer = gcnew XmlTextWriter( sw );
         writer->Formatting = Formatting::Indented;
         writer->Indentation = 2;
         schema->Write( writer );
         Console::WriteLine( sw );
      }
   }
   // </Snippet1>
};
