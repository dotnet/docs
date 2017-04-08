// The following code example demonstrates using 
// the following members: LostFocus, OpenFileDialog.Multiselect, 
// FileNames, Title, ErrorProvider.GetError, PictureBox.Image,
// Application.DoEvents, and System.Drawing.Image.FromStream.

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1() : Form()
   {
      InitializePictureBox();
      InitializeOpenFileDialog();
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->ErrorProvider1 = gcnew System::Windows::Forms::ErrorProvider;
      this->Label2 = gcnew System::Windows::Forms::Label;
      this->fileButton = gcnew Button;

      this->SuspendLayout();
      this->OpenFileDialog1->Filter = "Images " +
         "(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
      this->OpenFileDialog1->Multiselect = true;
      this->OpenFileDialog1->Title = "My Image Browser";
      this->TextBox1->Location = System::Drawing::Point( 16, 56 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 150, 20 );
      this->TextBox1->TabIndex = 2;
      this->TextBox1->Text = "";
      this->Button1->Location = System::Drawing::Point( 184, 48 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 88, 32 );
      this->Button1->TabIndex = 1;
      this->Button1->Text = "Find pictures";
      this->fileButton->Location = System::Drawing::Point( 80, 40 );
      this->fileButton->Name = "fileButton";
      this->fileButton->TabIndex = 0;
      this->fileButton->Text = "Button2";
      this->ErrorProvider1->ContainerControl = this;
      this->Label2->Location = System::Drawing::Point( 24, 34 );
      this->Label2->Name = "Label2";
      this->Label2->Size = System::Drawing::Size( 150, 23 );
      this->Label2->TabIndex = 5;
      this->Label2->Text = "Enter image file directory:";
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->PictureBox1 );
      this->Controls->Add( this->Label2 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );

      this->Button1->Click += gcnew System::EventHandler(
         this, &Form1::Button1_Click );
      this->fileButton->Click += gcnew System::EventHandler(
         this, &Form1::fileButton_Click );
      this->TextBox1->LostFocus += gcnew System::EventHandler(
         this, &Form1::TextBox1_LostFocus );
      this->TextBox1->Validating += gcnew System::ComponentModel::CancelEventHandler(
         this, &Form1::TextBox1_Validating );
      
      // Associate the event-handling method with the FileOk
      // event.
      this->OpenFileDialog1->FileOk +=
         gcnew System::ComponentModel::CancelEventHandler(
            this, &Form1::OpenFileDialog1_FileOk );
   }

internal:
   System::Windows::Forms::OpenFileDialog^ OpenFileDialog1;
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::ErrorProvider^ ErrorProvider1;
   System::Windows::Forms::Label ^ Label2;
   System::Windows::Forms::Button^ fileButton;
   System::Windows::Forms::PictureBox^ PictureBox1;

   //<snippet2>
   //<snippet3>
private:
   void TextBox1_Validating( Object^ sender,
      System::ComponentModel::CancelEventArgs^ e )
   {
      // If nothing is entered,
      // an ArgumentException is caught; if an invalid directory is entered, 
      // a DirectoryNotFoundException is caught. An appropriate error message 
      // is displayed in either case.
      try
      {
         System::IO::DirectoryInfo^ directory = gcnew System::IO::DirectoryInfo( TextBox1->Text );
         directory->GetFiles();
         ErrorProvider1->SetError( TextBox1, "" );
      }
      catch ( System::ArgumentException^ ) 
      {
         ErrorProvider1->SetError( TextBox1, "Please enter a directory" );
      }
      catch ( System::IO::DirectoryNotFoundException^ ) 
      {
         ErrorProvider1->SetError( TextBox1, "The directory does not exist."
         "Try again with a different directory." );
      }
   }
   //</snippet3>

   // This method handles the LostFocus event for TextBox1 by setting the 
   // dialog's InitialDirectory property to the text in TextBox1.
   void TextBox1_LostFocus( Object^ sender, System::EventArgs^ e )
   {
      OpenFileDialog1->InitialDirectory = TextBox1->Text;
   }

   // This method demonstrates using the ErrorProvider.GetError method 
   // to check for an error before opening the dialog box.
   void Button1_Click( System::Object^ sender, System::EventArgs^ e )
   {
      //If there is no error, then open the dialog box.
      if ( ErrorProvider1->GetError( TextBox1 )->Equals( "" ) )
      {
         ::DialogResult dialogResult = OpenFileDialog1->ShowDialog();
      }
   }
   //</snippet2>

   // These methods demonstrate  the handling of the FileOk event and the 
   // use of the Application.DoEvents method.  
   // A user selects graphics files from an OpenFileDialog object.  
   // The files are displayed in the form.  The Application.DoEvents
   // method forces a repaint of the form for each graphics file opened.
   //<snippet1>
   void InitializePictureBox()
   {
      this->PictureBox1 = gcnew System::Windows::Forms::PictureBox;
      this->PictureBox1->BorderStyle =
         System::Windows::Forms::BorderStyle::FixedSingle;
      this->PictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      this->PictureBox1->Location = System::Drawing::Point( 72, 112 );
      this->PictureBox1->Name = "PictureBox1";
      this->PictureBox1->Size = System::Drawing::Size( 160, 136 );
      this->PictureBox1->TabIndex = 6;
      this->PictureBox1->TabStop = false;
   }

   //<snippet6>
   void InitializeOpenFileDialog()
   {
      this->OpenFileDialog1 = gcnew System::Windows::Forms::OpenFileDialog;
      
      // Set the file dialog to filter for graphics files.
      this->OpenFileDialog1->Filter =
         "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
         "All files (*.*)|*.*";
      
      // Allow the user to select multiple images.
      this->OpenFileDialog1->Multiselect = true;
      this->OpenFileDialog1->Title = "My Image Browser";
   }

   void fileButton_Click( System::Object^ sender, System::EventArgs^ e )
   {
      OpenFileDialog1->ShowDialog();
   }
   //</snippet6>

   // This method handles the FileOK event.  It opens each file 
   // selected and loads the image from a stream into PictureBox1.
   void OpenFileDialog1_FileOk( Object^ sender,
      System::ComponentModel::CancelEventArgs^ e )
   {
      this->Activate();
      array<String^>^ files = OpenFileDialog1->FileNames;
      
      // Open each file and display the image in PictureBox1.
      // Call Application.DoEvents to force a repaint after each
      // file is read.        
      for each ( String^ file in files )
      {
         System::IO::FileInfo^ fileInfo = gcnew System::IO::FileInfo( file );
         System::IO::FileStream^ fileStream = fileInfo->OpenRead();
         PictureBox1->Image = System::Drawing::Image::FromStream( fileStream );
         Application::DoEvents();
         fileStream->Close();
         
         // Call Sleep so the picture is briefly displayed, 
         //which will create a slide-show effect.
         System::Threading::Thread::Sleep( 2000 );
      }
      PictureBox1->Image = nullptr;
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
