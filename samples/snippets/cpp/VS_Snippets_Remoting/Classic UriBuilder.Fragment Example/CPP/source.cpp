

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
   UriBuilder^ uBuild = gcnew UriBuilder( "http://www.contoso.com/" );
   uBuild->Path = "index.htm";
   uBuild->Fragment = "main";
   Uri^ myUri = uBuild->Uri;
   // </Snippet1>
}
