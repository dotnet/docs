
// <Snippet1>
#using <system.dll>
#using <System.Drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Threading;
using namespace System::Windows::Forms;
ref class UICulture: public Form
{
public:
   UICulture()
   {
      
      // Set the user interface to display in the
      // same culture as that set in Control Panel.
      Thread::CurrentThread->CurrentUICulture = Thread::CurrentThread->CurrentCulture;
      
      // Add additional code.
   }
};


int main()
{
   Application::Run( gcnew UICulture );
}
// </Snippet1>
