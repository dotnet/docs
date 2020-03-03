#using <System.dll>
#using <System.Drawing.dll>
#using <System.IO.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates using the 
// RichTextBox1.SaveFile and RichTextBox.LoadFile methods with streams.
// It also demonstrates using the FileDialog.FileName, 
// SaveFileDialog.CreatePrompt, SaveFileDialog.OverwritePrompt, and 
// TextBox.Click members.
//<snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public private:
   RichTextBox^ RichTextBox1;
   Button^ Button1;
   RichTextBox^ RichTextBox2;
   Button^ Button2;
   SaveFileDialog^ SaveFileDialog1;

public:
   Form1()
      : Form()
   {
      userInput = gcnew MemoryStream;
      this->RichTextBox1 = gcnew RichTextBox;
      this->Button1 = gcnew Button;
      this->RichTextBox2 = gcnew RichTextBox;
      this->Button2 = gcnew Button;
      this->SaveFileDialog1 = gcnew SaveFileDialog;
      this->SuspendLayout();
      this->RichTextBox1->Location = Point( 24, 64 );
      this->RichTextBox1->Name = "RichTextBox1";
      this->RichTextBox1->TabIndex = 0;
      this->RichTextBox1->Text = "Type something here.";
      this->Button1->Location = Point( 96, 16 );
      this->Button1->Name = "Button1";
      this->Button1->Size = Size( 96, 24 );
      this->Button1->TabIndex = 1;
      this->Button1->Text = "Save To Stream";
      this->Button1->Click += 
		  gcnew EventHandler( this, &Form1::Button1_Click );
      this->RichTextBox2->Location = Point( 152, 64 );
      this->RichTextBox2->Name = "RichTextBox2";
      this->RichTextBox2->TabIndex = 3;
      this->RichTextBox2->Text = "It will be added to the stream "
      "and appear here.";
      this->Button2->Location = Point( 104, 200 );
      this->Button2->Name = "Button2";
      this->Button2->Size = Size( 88, 32 );
      this->Button2->TabIndex = 4;
      this->Button2->Text = "Save Stream To File";
      this->Button2->Click += 
		  gcnew EventHandler( this, &Form1::Button2_Click );
      this->ClientSize = Size( 292, 266 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->RichTextBox2 );
      this->Controls->Add( this->Button1 );
      this->Controls->Add( this->RichTextBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   // Declare a new memory stream.
   MemoryStream^ userInput;

private:

   // Save the content of RichTextBox1 to the memory stream, 
   // appending a LineFeed character.  
   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      RichTextBox1->SaveFile( userInput, RichTextBoxStreamType::PlainText );
      userInput->WriteByte( 13 );
      
      // Display the entire contents of the stream,
      // by setting its position to 0, to RichTextBox2.
      userInput->Position = 0;
      RichTextBox2->LoadFile( userInput, RichTextBoxStreamType::PlainText );
   }


   // Shows the use of a SaveFileDialog to save a MemoryStream to a file.
   void Button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Set the properties on SaveFileDialog1 so the user is 
      // prompted to create the file if it doesn't exist 
      // or overwrite the file if it does exist.
      SaveFileDialog1->CreatePrompt = true;
      SaveFileDialog1->OverwritePrompt = true;
      
      // Set the file name to myText.txt, set the type filter
      // to text files, and set the initial directory to the
	  // MyDocuments folder.
      SaveFileDialog1->FileName = "myText";
	  // DefaultExt is only used when "All files" is selected from 
      // the filter box and no extension is specified by the user.
      SaveFileDialog1->DefaultExt = "txt";
      SaveFileDialog1->Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
      SaveFileDialog1->InitialDirectory = 
		  Environment->GetFolderPath(Environment::SpecialFolder::MyDocuments);
      
      // Call ShowDialog and check for a return value of DialogResult.OK,
      // which indicates that the file was saved. 
      DialogResult result = SaveFileDialog1->ShowDialog();
      Stream^ fileStream;
      if ( result == DialogResult::OK )
      {
         fileStream = SaveFileDialog1->OpenFile();
         userInput->Position = 0;
         userInput->WriteTo( fileStream );
         fileStream->Close();
      }
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}

//</snippet1>
