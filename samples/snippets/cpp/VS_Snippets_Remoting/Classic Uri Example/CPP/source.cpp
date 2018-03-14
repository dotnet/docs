

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Net;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   void Method()
   {
      // <Snippet1>
      Uri^ siteUri = gcnew Uri( "http://www.contoso.com/" );
      WebRequest^ wr = WebRequest::Create( siteUri );
      // </Snippet1>
   }
};

void main()
{
   Form1^ f = gcnew Form1;
}
