

//<Snippet1>
// The following example displays an application that provides the ability to
// open rich text files (rtf) into the RichTextBox. The example demonstrates
// using the FolderBrowserDialog to set the default directory for opening files.
// The OpenFileDialog is used to open the file.
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::IO;
public ref class FolderBrowserDialogExampleForm: public System::Windows::Forms::Form
{
private:
   FolderBrowserDialog^ folderBrowserDialog1;
   OpenFileDialog^ openFileDialog1;
   RichTextBox^ richTextBox1;
   MainMenu^ mainMenu1;
   MenuItem^ fileMenuItem;
   MenuItem^ openMenuItem;
   MenuItem^ folderMenuItem;
   MenuItem^ closeMenuItem;
   String^ openFileName;
   String^ folderName;
   bool fileOpened;

public:

   // Constructor.
   FolderBrowserDialogExampleForm()
   {
      fileOpened = false;
      this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->fileMenuItem = gcnew System::Windows::Forms::MenuItem;
      this->openMenuItem = gcnew System::Windows::Forms::MenuItem;
      this->folderMenuItem = gcnew System::Windows::Forms::MenuItem;
      this->closeMenuItem = gcnew System::Windows::Forms::MenuItem;
      this->openFileDialog1 = gcnew System::Windows::Forms::OpenFileDialog;
      this->folderBrowserDialog1 = gcnew System::Windows::Forms::FolderBrowserDialog;
      this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->mainMenu1->MenuItems->Add( this->fileMenuItem );
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->openMenuItem,this->closeMenuItem,this->folderMenuItem};
      this->fileMenuItem->MenuItems->AddRange( temp0 );
      this->fileMenuItem->Text = "File";
      this->openMenuItem->Text = "Open...";
      this->openMenuItem->Click += gcnew System::EventHandler( this, &FolderBrowserDialogExampleForm::openMenuItem_Click );
      this->folderMenuItem->Text = "Select Directory...";
      this->folderMenuItem->Click += gcnew System::EventHandler( this, &FolderBrowserDialogExampleForm::folderMenuItem_Click );
      this->closeMenuItem->Text = "Close";
      this->closeMenuItem->Click += gcnew System::EventHandler( this, &FolderBrowserDialogExampleForm::closeMenuItem_Click );
      this->closeMenuItem->Enabled = false;
      this->openFileDialog1->DefaultExt = "rtf";
      this->openFileDialog1->Filter = "rtf files (*.rtf)|*.rtf";
      
      // Set the help text description for the FolderBrowserDialog.
      this->folderBrowserDialog1->Description = "Select the directory that you want to use as the default.";
      
      // Do not allow the user to create new files via the FolderBrowserDialog.
      this->folderBrowserDialog1->ShowNewFolderButton = false;
      
      // Default to the My Documents folder.
      this->folderBrowserDialog1->RootFolder = Environment::SpecialFolder::Personal;
      this->richTextBox1->AcceptsTab = true;
      this->richTextBox1->Location = System::Drawing::Point( 8, 8 );
      this->richTextBox1->Size = System::Drawing::Size( 280, 344 );
      this->richTextBox1->Anchor = static_cast<AnchorStyles>(AnchorStyles::Top | AnchorStyles::Left | AnchorStyles::Bottom | AnchorStyles::Right);
      this->ClientSize = System::Drawing::Size( 296, 360 );
      this->Controls->Add( this->richTextBox1 );
      this->Menu = this->mainMenu1;
      this->Text = "RTF Document Browser";
   }


private:

   // Bring up a dialog to open a file.
   void openMenuItem_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // If a file is not opened then set the initial directory to the
      // FolderBrowserDialog::SelectedPath value.
      if (  !fileOpened )
      {
         openFileDialog1->InitialDirectory = folderBrowserDialog1->SelectedPath;
         openFileDialog1->FileName = nullptr;
      }

      
      // Display the openFile Dialog.
      System::Windows::Forms::DialogResult result = openFileDialog1->ShowDialog();
      
      // OK button was pressed.
      if ( result == ::DialogResult::OK )
      {
         openFileName = openFileDialog1->FileName;
         try
         {
            
            // Output the requested file in richTextBox1.
            Stream^ s = openFileDialog1->OpenFile();
            richTextBox1->LoadFile( s, RichTextBoxStreamType::RichText );
            s->Close();
            fileOpened = true;
         }
         catch ( Exception^ exp ) 
         {
            MessageBox::Show( String::Concat( "An error occurred while attempting to load the file. The error is: ", System::Environment::NewLine, exp, System::Environment::NewLine ) );
            fileOpened = false;
         }

         Invalidate();
         closeMenuItem->Enabled = fileOpened;
      }
      // Cancel button was pressed.
      else
      
      // Cancel button was pressed.
      if ( result == ::DialogResult::Cancel )
      {
         return;
      }
   }


   // Close the current file.
   void closeMenuItem_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      richTextBox1->Text = "";
      fileOpened = false;
      closeMenuItem->Enabled = false;
   }


   // Bring up a dialog to chose a folder path in which to open/save a file.
   void folderMenuItem_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Show the FolderBrowserDialog.
      System::Windows::Forms::DialogResult result = folderBrowserDialog1->ShowDialog();
      if ( result == ::DialogResult::OK )
      {
         folderName = folderBrowserDialog1->SelectedPath;
         if (  !fileOpened )
         {
            
            // No file is opened, bring up openFileDialog in selected path.
            openFileDialog1->InitialDirectory = folderName;
            openFileDialog1->FileName = nullptr;
            openMenuItem->PerformClick();
         }
      }
   }

};


// The main entry point for the application.
int main()
{
   Application::Run( gcnew FolderBrowserDialogExampleForm );
}

//</Snippet1>
