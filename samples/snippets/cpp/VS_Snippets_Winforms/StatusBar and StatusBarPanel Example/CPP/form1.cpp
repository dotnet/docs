#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 152, 96 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 376, 293 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void CreateMyStatusBar()
   {
      // Create a StatusBar control.
      StatusBar^ statusBar1 = gcnew StatusBar;

      // Create two StatusBarPanel objects to display in the StatusBar.
      StatusBarPanel^ panel1 = gcnew StatusBarPanel;
      StatusBarPanel^ panel2 = gcnew StatusBarPanel;

      // Display the first panel with a sunken border style.
      panel1->BorderStyle = StatusBarPanelBorderStyle::Sunken;

      // Initialize the text of the panel.
      panel1->Text = "Ready...";

      // Set the AutoSize property to use all remaining space on the StatusBar.
      panel1->AutoSize = StatusBarPanelAutoSize::Spring;

      // Display the second panel with a raised border style.
      panel2->BorderStyle = StatusBarPanelBorderStyle::Raised;

      // Create ToolTip text that displays the time the application
      // was started.
      panel2->ToolTipText = System::DateTime::Now.ToShortTimeString();

      // Set the text of the panel to the current date.
      panel2->Text = "Started: " + System::DateTime::Today.ToLongDateString();

      // Set the AutoSize property to size the panel to the size of the contents.
      panel2->AutoSize = StatusBarPanelAutoSize::Contents;

      // Display panels in the StatusBar control.
      statusBar1->ShowPanels = true;

      // Add both panels to the StatusBarPanelCollection of the StatusBar.   
      statusBar1->Panels->Add( panel1 );
      statusBar1->Panels->Add( panel2 );

      // Add the StatusBar to the form.
      this->Controls->Add( statusBar1 );
   }
   //</snippet1>

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      CreateMyStatusBar();
   }
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
