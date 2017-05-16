

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::PageSetupDialog^ PageSetupDialog1;
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::ListBox^ ListBox1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->PageSetupDialog1 = gcnew System::Windows::Forms::PageSetupDialog;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->ListBox1 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 104, 24 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 88, 40 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Modify page settings";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //ListBox1
      //
      this->ListBox1->Dock = System::Windows::Forms::DockStyle::Bottom;
      this->ListBox1->Location = System::Drawing::Point( 0, 106 );
      this->ListBox1->Name = "ListBox1";
      this->ListBox1->Size = System::Drawing::Size( 292, 160 );
      this->ListBox1->TabIndex = 1;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->ListBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   //This method displays a PageSetupDialog object. If the
   // user clicks OK in the dialog, selected results of
   // the dialog are displayed in ListBox1.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Initialize the dialog's PrinterSettings property to hold user
      // defined printer settings.
      PageSetupDialog1->PageSettings = gcnew System::Drawing::Printing::PageSettings;
      
      // Initialize dialog's PrinterSettings property to hold user
      // set printer settings.
      PageSetupDialog1->PrinterSettings = gcnew System::Drawing::Printing::PrinterSettings;
      
      //Do not show the network in the printer dialog.
      PageSetupDialog1->ShowNetwork = false;
      
      //Show the dialog storing the result.
      System::Windows::Forms::DialogResult result = PageSetupDialog1->ShowDialog();
      
      // If the result is OK, display selected settings in
      // ListBox1. These values can be used when printing the
      // document.
      if ( result == ::DialogResult::OK )
      {
         array<Object^>^results = {PageSetupDialog1->PageSettings->Margins,PageSetupDialog1->PageSettings->PaperSize,PageSetupDialog1->PageSettings->Landscape,PageSetupDialog1->PrinterSettings->PrinterName,PageSetupDialog1->PrinterSettings->PrintRange};
         ListBox1->Items->AddRange( results );
      }
      
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
