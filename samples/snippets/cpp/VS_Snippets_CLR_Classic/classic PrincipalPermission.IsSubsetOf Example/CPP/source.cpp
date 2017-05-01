#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Policy;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

public:
   void Method()
   {
      // <Snippet1>
      //Define users and roles.
      PrincipalPermission^ ppBob = gcnew PrincipalPermission( "Bob", "Manager" );
      PrincipalPermission^ ppLouise = gcnew PrincipalPermission( "Louise", "Supervisor" );
      PrincipalPermission^ ppGreg = gcnew PrincipalPermission( "Greg", "Employee" );
      
      //Define groups of users.
      PrincipalPermission^ pp1 = (PrincipalPermission^) (ppBob->Union( ppLouise ));
      PrincipalPermission^ pp2 = (PrincipalPermission^) (ppGreg->Union( pp1 ));
      // </Snippet1>
   }
};
