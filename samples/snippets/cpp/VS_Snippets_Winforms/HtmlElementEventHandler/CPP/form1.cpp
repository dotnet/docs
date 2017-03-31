#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Security::Permissions;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::WebBrowser^ WebBrowser1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::IContainer^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

public:

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
   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void InitializeComponent()
   {
      this->WebBrowser1 = gcnew System::Windows::Forms::WebBrowser;
      this->SuspendLayout();

      // 
      // WebBrowser1
      // 
      this->WebBrowser1->Dock = System::Windows::Forms::DockStyle::Fill;
      this->WebBrowser1->Location = System::Drawing::Point( 0, 0 );
      this->WebBrowser1->Name = "WebBrowser1";
      this->WebBrowser1->Size = System::Drawing::Size( 824, 440 );
      this->WebBrowser1->TabIndex = 0;
      this->WebBrowser1->DocumentCompleted += gcnew System::Windows::Forms::WebBrowserDocumentCompletedEventHandler( this, &Form1::webBrowser1_DocumentCompleted );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 824, 440 );
      this->Controls->Add( this->WebBrowser1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<SNIPPET1>
private:
   void webBrowser1_DocumentCompleted( Object^ /*sender*/, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^ /*e*/ )
   {
      WebBrowser1->Document->MouseDown += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseDown );
      WebBrowser1->Document->MouseMove += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseMove );
      WebBrowser1->Document->MouseUp += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseUp );
   }

   void Document_MouseDown( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }

   void Document_MouseMove( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }

   void Document_MouseUp( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }
   //</SNIPPET1>
};


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew Form1 );
}
