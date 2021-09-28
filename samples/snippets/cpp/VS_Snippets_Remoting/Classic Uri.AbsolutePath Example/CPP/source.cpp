

#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Data;
using namespace System::Security::Principal;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   void Method()
   {
      // <Snippet1>
      Uri^ baseUri = gcnew Uri( "http://www.contoso.com/" );
      Uri^ myUri = gcnew Uri( baseUri,"catalog/shownew.htm?date=today" );
      Console::WriteLine( myUri->AbsolutePath );
      // </Snippet1>
   }
};

void main()
{
   Form1^ f = gcnew Form1;
}
