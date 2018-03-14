#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   String^ _price;

public:
   void Method( XmlReader^ reader )
   {
// <Snippet1>
      if ( reader->MoveToContent() == XmlNodeType::Element &&
         reader->Name->Equals( "price" ) )
      {
         _price = reader->ReadString();
      }
// </Snippet1>
   }
};
