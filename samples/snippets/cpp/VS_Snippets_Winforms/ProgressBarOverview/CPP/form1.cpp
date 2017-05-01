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

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;
   System::Windows::Forms::Button^ button1;
   ProgressBar^ pBar1;

public:
   Form1()
   {
      components = nullptr;
      pBar1 = gcnew ProgressBar;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      pBar1->Bounds = Rectangle(10,50,200,20);
      this->Controls->Add( pBar1 );

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }


private:
   bool CopyFile( String^ filename )
   {
      #if defined(DEBUG)
      System::Diagnostics::Debug::WriteLine( "File Being Copied = {0}", filename );
      #endif
      return true;
   }

   // <snippet1>
private:
   void CopyWithProgress( array<String^>^filenames )
   {
      // Display the ProgressBar control.
      pBar1->Visible = true;

      // Set Minimum to 1 to represent the first file being copied.
      pBar1->Minimum = 1;

      // Set Maximum to the total number of files to copy.
      pBar1->Maximum = filenames->Length;

      // Set the initial value of the ProgressBar.
      pBar1->Value = 1;

      // Set the Step property to a value of 1 to represent each file being copied.
      pBar1->Step = 1;

      // Loop through all files to copy.
      for ( int x = 1; x <= filenames->Length; x++ )
      {
         // Copy the file and increment the ProgressBar if successful.
         if ( CopyFile( filenames[ x - 1 ] ) == true )
         {
            // Perform the increment on the ProgressBar.
            pBar1->PerformStep();
         }
      }
   }
   // </snippet1>

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
      this->button1->Location = System::Drawing::Point( 288, 72 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 120, 16 );
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 472, 398 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      array<String^>^tempFiles = gcnew array<String^>(5);
      tempFiles[ 0 ] = "file1.txt";
      tempFiles[ 1 ] = "file2.txt";
      tempFiles[ 2 ] = "file3.txt";
      tempFiles[ 3 ] = "file4.txt";
      tempFiles[ 4 ] = "file5.txt";
      CopyWithProgress( tempFiles );
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
