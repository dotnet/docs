#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   void Method( XmlSchemaCollection^ xsc )
   {
      // <Snippet1>
      if ( xsc->Contains( "urn:bookstore-schema" ) )
      {
         XmlSchema^ schema = xsc[ "urn:bookstore-schema" ];
         StringWriter^ sw = gcnew StringWriter;
         XmlTextWriter^ xmlWriter = gcnew XmlTextWriter( sw );
         xmlWriter->Formatting = Formatting::Indented;
         xmlWriter->Indentation = 2;
         schema->Write( xmlWriter );
         Console::WriteLine( sw );
      }
      // </Snippet1>
   }
};
