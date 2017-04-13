

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Data;
using namespace System::Windows::Forms;

// <Snippet1>
void WriteXml( XmlDocument^ doc )
{
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   writer->Formatting = Formatting::Indented;
   doc->WriteTo( writer );
   writer->Flush();
   Console::WriteLine();
}

// </Snippet1>
