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
   System::Windows::Forms::ProgressBar^ progressBar1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::StatusBar^ statusBar1;
   System::Windows::Forms::StatusBarPanel^ statusBarPanel1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      time = gcnew Timer;
      
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
   void InitializeComponent()
   {
      this->progressBar1 = gcnew System::Windows::Forms::ProgressBar;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->statusBar1 = gcnew System::Windows::Forms::StatusBar;
      this->statusBarPanel1 = gcnew System::Windows::Forms::StatusBarPanel;
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel1))->BeginInit();
      this->SuspendLayout();

      // 
      // progressBar1
      // 
      this->progressBar1->Location = System::Drawing::Point( 24, 24 );
      this->progressBar1->Name = "progressBar1";
      this->progressBar1->Size = System::Drawing::Size( 192, 24 );
      this->progressBar1->Step = 1;
      this->progressBar1->TabIndex = 0;

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 224, 24 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // statusBar1
      // 
      this->statusBar1->Location = System::Drawing::Point( 0, 272 );
      this->statusBar1->Name = "statusBar1";
      array<System::Windows::Forms::StatusBarPanel^>^temp0 = {this->statusBarPanel1};
      this->statusBar1->Panels->AddRange( temp0 );
      this->statusBar1->ShowPanels = true;
      this->statusBar1->Size = System::Drawing::Size( 368, 22 );
      this->statusBar1->TabIndex = 2;
      this->statusBar1->Text = "statusBar1";

      // 
      // statusBarPanel1
      // 
      this->statusBarPanel1->AutoSize = System::Windows::Forms::StatusBarPanelAutoSize::Spring;
      this->statusBarPanel1->Text = "Ready";
      this->statusBarPanel1->Width = 352;

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 368, 294 );
      array<System::Windows::Forms::Control^>^temp1 = {this->statusBar1,this->button1,this->progressBar1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->statusBarPanel1))->EndInit();
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      InitializeMyTimer();
   }

   //<Snippet1>
private:
   Timer^ time;

   // Call this method from the constructor of the form.
   void InitializeMyTimer()
   {
      // Set the interval for the timer.
      time->Interval = 250;

      // Connect the Tick event of the timer to its event handler.
      time->Tick += gcnew EventHandler( this, &Form1::IncreaseProgressBar );

      // Start the timer.
      time->Start();
   }

   void IncreaseProgressBar( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Increment the value of the ProgressBar a value of one each time.
      progressBar1->Increment( 1 );

      // Display the textual value of the ProgressBar in the StatusBar control's first panel.
      statusBarPanel1->Text = String::Concat( progressBar1->Value, "% Completed" );

      // Determine if we have completed by comparing the value of the Value property to the Maximum value.
      if ( progressBar1->Value == progressBar1->Maximum )

      // Stop the timer.
      time->Stop();
   }
   //</Snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
