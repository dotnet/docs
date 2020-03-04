

#using <System.dll>
#using <System.Data.dll>
#using <System.Security.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Security::Principal;
using namespace System::Windows::Forms;

void main()
{
   // <Snippet1>
   Console::WriteLine( Uri::CheckHostName( "www.contoso.com" ) );
   // </Snippet1>
}
