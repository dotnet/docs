#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::IO;
using namespace System::Security::Permissions;
using namespace System::Windows::Forms;
using namespace System::Security;

public ref class Form1: public Form
{
protected:
   void Method()
   {
// <Snippet1>
 FileIOPermission^ f = gcnew FileIOPermission( PermissionState::None );
 f->AllLocalFiles = FileIOPermissionAccess::Read;
 try
 {
	 f->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }
// </Snippet1>

// <Snippet2>
 FileIOPermission^ f2 = gcnew FileIOPermission( FileIOPermissionAccess::Read,"C:\\test_r" );
 f2->AddPathList( (FileIOPermissionAccess) (FileIOPermissionAccess::Write | FileIOPermissionAccess::Read), "C:\\example\\out.txt" );
 try
 {
	 f2->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }
// </Snippet2>

 // <Snippet3>
 FileIOPermission^ f3 = gcnew FileIOPermission( PermissionState::None );
 f->AllFiles = FileIOPermissionAccess::Read;
 try
 {
	 f3->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }
// </Snippet3>
   }
};
