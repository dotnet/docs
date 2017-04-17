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
   System::Windows::Forms::ListBox^ listBox1;
   System::Windows::Forms::TextBox^ textBox1;

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
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();

      //
      // listBox1
      //
      array<Object^>^temp0 = {"C:\\Windows\\Windows Update.log"};
      this->listBox1->Items->AddRange( temp0 );
      this->listBox1->Location = System::Drawing::Point( 32, 24 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 200, 108 );
      this->listBox1->TabIndex = 0;
      this->listBox1->DoubleClick += gcnew System::EventHandler( this, &Form1::listBox1_DoubleClick );

      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 32, 144 );
      this->textBox1->Multiline = true;
      this->textBox1->Name = "textBox1";
      this->textBox1->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
      this->textBox1->Size = System::Drawing::Size( 448, 240 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "textBox1";

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 520, 446 );
      array<System::Windows::Forms::Control^>^temp1 = {this->textBox1,this->listBox1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
   // This example uses the DoubleClick event of a ListBox to load text files
   // listed in the ListBox into a TextBox control. This example
   // assumes that the ListBox, named listBox1, contains a list of valid file
   // names with path and that this event handler method
   // is connected to the DoublClick event of a ListBox control named listBox1.
   // This example requires code access permission to access files.
private:
   void listBox1_DoubleClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the name of the file to open from the ListBox.
      String^ file = listBox1->SelectedItem->ToString();
      try
      {
         // Determine if the file exists before loading.
         if ( System::IO::File::Exists( file ) )
         {
            
            // Open the file and use a TextReader to read the contents into the TextBox.
            System::IO::FileInfo^ myFile = gcnew System::IO::FileInfo( listBox1->SelectedItem->ToString() );
            System::IO::TextReader^ myData = myFile->OpenText();
            ;
            textBox1->Text = myData->ReadToEnd();
            myData->Close();
         }
      }
      // Exception is thrown by the OpenText method of the FileInfo class.
      catch ( System::IO::FileNotFoundException^ ) 
      {
         MessageBox::Show( "The file you specified does not exist." );
      }
      // Exception is thrown by the ReadToEnd method of the TextReader class.
      catch ( System::IO::IOException^ ) 
      {
         MessageBox::Show( "There was a problem loading the file into the TextBox. Ensure that the file is a valid text file." );
      }
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
