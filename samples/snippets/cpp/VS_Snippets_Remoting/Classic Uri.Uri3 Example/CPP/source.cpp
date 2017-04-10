

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
   Uri^ baseUri = gcnew Uri(  "http://www.contoso.com" );
   Uri^ myUri = gcnew Uri( baseUri, "catalog/shownew.htm" );
   Console::WriteLine( myUri->ToString() );
   // </Snippet1>
}
