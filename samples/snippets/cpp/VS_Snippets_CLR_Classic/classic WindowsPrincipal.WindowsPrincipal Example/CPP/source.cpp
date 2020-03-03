#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

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
      WindowsIdentity^ wi = WindowsIdentity::GetCurrent();
      WindowsPrincipal^ wp = gcnew WindowsPrincipal( wi );
      // </Snippet1>
   }
};
