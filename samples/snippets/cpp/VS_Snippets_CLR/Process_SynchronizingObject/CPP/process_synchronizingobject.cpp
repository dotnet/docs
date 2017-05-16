// System::Diagnostics::Process::SynchronizingObject

/*
The following example demonstrates the property 'SynchronizingObject'
of 'Process' class.

It starts a process 'mspaint.exe' on button click. 
It attaches 'MyProcessExited' method of 'MyButton' class as EventHandler to
'Exited' event of the process.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

ref class Form1: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;

   // <Snippet1>
   ref class MyButton: public Button
   {
   public:
      void MyProcessExited( Object^ source, EventArgs^ e )
      {
         MessageBox::Show( "The process has exited." );
      }
   };

public:
   MyButton^ button1;
private:
   void MyProcessExited( Object^ source, EventArgs^ e )
   {
       MessageBox::Show( "The process has exited." );
   }
   void button1_Click( Object^ sender, EventArgs^ e )
   {
      Process^ myProcess = gcnew Process;
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo( "mspaint" );
      myProcess->StartInfo = myProcessStartInfo;
      myProcess->Start();
      myProcess->Exited += gcnew System::EventHandler( this, &Form1::MyProcessExited );

      // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
      myProcess->EnableRaisingEvents = true;

      // Set method handling the exited event to be called  ;
      // on the same thread on which MyButton was created.
      myProcess->SynchronizingObject = button1;
      MessageBox::Show( "Waiting for the process 'mspaint' to exit...." );
      myProcess->WaitForExit();
      myProcess->Close();
   }
   // </Snippet1>

   void InitializeComponent()
   {
      this->button1 = gcnew MyButton;
      this->SuspendLayout();

      // 
      // button1
      //
      this->button1->Location = System::Drawing::Point( 40, 80 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 168, 32 );
      this->button1->TabIndex = 0;
      this->button1->Text = "Click Me";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      //
      this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^newControls = {this->button1};
      this->Controls->AddRange( newControls );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

public:
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

public:
   Form1()
      : components( nullptr )
   {
      InitializeComponent();
   }
};

[STAThread]
void main()
{
   Application::Run( gcnew Form1 );
}
