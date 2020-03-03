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
   void Method( IntPtr userToken )
   {
      // <Snippet1>
      WindowsImpersonationContext^ ImpersonationCtx = WindowsIdentity::Impersonate( userToken );
      
      //Do something under the context of the impersonated user.

      ImpersonationCtx->Undo();
      // </Snippet1>
   }
};
