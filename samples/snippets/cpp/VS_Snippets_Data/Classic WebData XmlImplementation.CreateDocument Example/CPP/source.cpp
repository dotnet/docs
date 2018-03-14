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
   DataSet^ dataset;

public:
   void Method()
   {
// <Snippet1>
      XmlImplementation^ imp = gcnew XmlImplementation;
      XmlDocument^ doc1 = imp->CreateDocument();
      XmlDocument^ doc2 = imp->CreateDocument();
// </Snippet1>
   }
};
