

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
   Uri^ myUri = gcnew Uri(  "http://www.contoso.com/Hello%20World.htm",true );
   // </Snippet1>
}
