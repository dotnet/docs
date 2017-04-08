
//#pragma comment(linker, "/CLRUNMANAGEDCODECHECK:NO")
//<Snippet1>
// The following HTML code can be used to call the user control in this sample.
//
//<HTML>
// <BODY>
//  <OBJECT id="usercontrol" classid="usercontrol.dll#UserControl.UserControl1" width="800"
//  height="300" style="font-size:12;">
//  </OBJECT>
//  <p>
// </BODY>
//</HTML>
// To run this test control you must create a strong name key, snkey.snk, and
// a code group that gives full trust to assemblies signed with snkey.snk.
// The user control displays an OpenFileDialog box, then displays a text box containing the name of
// the file selected and a list box that displays the contents of the file.  The selected file must
// contain text in order for the control to display the data properly.
// Caution  This sample demonstrates the use of the Assert method.  Calling Assert removes the
// requirement that all code in the call chain must be granted permission to access the specified
// resource, it can open up security vulnerabilities if used incorrectly or inappropriately. Therefore,
// it should be used with great caution.  Assert should always be followed with a RevertAssert
// command to restore the security settings.
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Data;
using namespace System::Windows::Forms;
using namespace System::IO;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;

// This strong name key is used to create a code group that gives permissions to this assembly.
// The AllowPartiallyTrustedCallersAttribute requires the assembly to be signed with a strong name key.
// This attribute is necessary since the control is called by either an intranet or Internet
// Web page that should be running under restricted permissions.
// The userControl1 displays an OpenFileDialog box, then displays a text box containing the name of 
// the file selected and a list box that displays the contents of the file.  The selected file must 
// contain text in order for the control to display the data properly.

[assembly:AssemblyKeyFile("snKey.snk")];
[assembly:AssemblyVersion("1.0.0.0")];
[assembly:AllowPartiallyTrustedCallers];
public ref class UserControl1: public System::Windows::Forms::UserControl
{
private:
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::ListBox^ listBox1;

   // Required designer variable.
   System::ComponentModel::Container^ components;

public:
// Demand the zone requirement for the calling application.
[ZoneIdentityPermission(SecurityAction::Demand, Zone = SecurityZone::Intranet)]
   UserControl1()
   {
      
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();
      
      // The OpenFileDialog box should not require any special permissions.
      OpenFileDialog^ fileDialog = gcnew OpenFileDialog;
      if ( fileDialog->ShowDialog() == DialogResult::OK )
      {
         
         // Reading the name of the selected file from the OpenFileDialog box
         // and reading the file requires FileIOPermission.  The user control should 
         // have this permission granted through its code group; the Web page that calls the 
         // control should not have this permission.  The Assert command prevents a stack walk 
         // that would fail because the caller does not have the required FileIOPermission.  
         // The use of Assert can open up security vulnerabilities if used incorrectly or 
         // inappropriately. Therefore, it should be used with great caution.
         // The Assert command should be followed by a RevertAssert as soon as the file operation 
         // is completed.
         (gcnew FileIOPermission( PermissionState::Unrestricted ))->Assert();
         textBox1->Text = fileDialog->FileName;

         // Display the contents of the file in the text box.
         FileStream^ fsIn = gcnew FileStream( textBox1->Text,FileMode::Open,FileAccess::Read,FileShare::Read );
         StreamReader^ sr = gcnew StreamReader( fsIn );
         
         // Process every line in the file
         for ( String ^ Line = sr->ReadLine(); Line != nullptr; Line = sr->ReadLine() )
         {
            listBox1->Items->Add( Line );

         }

         // file operations.
         FileIOPermission::RevertAssert();
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify 
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();
      
      // 
      // textBox1
      // 
      this->textBox1->Location = System::Drawing::Point( 208, 112 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 320, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";
      this->textBox1->TextChanged += gcnew System::EventHandler( this,&UserControl1::textBox1_TextChanged );
      
      // 
      // listBox1
      // 
      this->listBox1->Location = System::Drawing::Point( 200, 184 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 336, 108 );
      this->listBox1->TabIndex = 1;
      
      // 
      // UserControl1
      // 
      this->Controls->Add( this->listBox1 );
      this->Controls->Add( this->textBox1 );
      this->Name = "UserControl1";
      this->Size = System::Drawing::Size( 592, 400 );
      this->Load += gcnew System::EventHandler( this,&UserControl1::UserControl1_Load );
      this->ResumeLayout( false );
   }

   void UserControl1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

   void textBox1_TextChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

};

//</Snippet1>
