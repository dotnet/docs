

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;

[assembly:AssemblyCompany("Microsoft")];
[assembly:AssemblyProduct("Test")];
[assembly:AssemblyVersion("1.0.*")];
namespace CodeExamples
{
   public ref class AboutDialog: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ buttonOK;
      System::Windows::Forms::Label ^ labelVersionInfo;
      System::ComponentModel::Container^ components;

   public:
      AboutDialog()
      {
         InitializeComponent();
      }

   protected:
   ~AboutDialog()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

   private:
      void InitializeComponent()
      {
         this->labelVersionInfo = gcnew System::Windows::Forms::Label;
         this->buttonOK = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // labelVersionInfo
         //
         this->labelVersionInfo->Location = System::Drawing::Point( 8, 8 );
         this->labelVersionInfo->Name = "labelVersionInfo";
         this->labelVersionInfo->Size = System::Drawing::Size( 360, 23 );
         this->labelVersionInfo->TabIndex = 0;
         this->labelVersionInfo->Text = "label1";

         //
         // buttonOK
         //
         this->buttonOK->Location = System::Drawing::Point( 296, 64 );
         this->buttonOK->Name = "buttonOK";
         this->buttonOK->TabIndex = 3;
         this->buttonOK->Text = "&OK";

         //
         // AboutDialog
         //
         this->ClientSize = System::Drawing::Size( 392, 109 );
         array<System::Windows::Forms::Control^>^temp0 = {this->buttonOK,this->labelVersionInfo};
         this->Controls->AddRange( temp0 );
         this->Name = "AboutDialog";
         this->Text = "About";
         this->Load += gcnew System::EventHandler( this, &AboutDialog::AboutDialog_Load );
         this->ResumeLayout( false );
      }

      // <snippet1>
      void AboutDialog_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Display the application information in the label.
         this->labelVersionInfo->Text = String::Format(  "{0} {1} Version: {2}", this->CompanyName, this->ProductName, this->ProductVersion );
      }
      // </snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew CodeExamples::AboutDialog );
}
