#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
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
      IPHostEntry^ hostInfo = Dns::GetHostByName( "www.contoso.com" );
      // </Snippet1>
   }
};
