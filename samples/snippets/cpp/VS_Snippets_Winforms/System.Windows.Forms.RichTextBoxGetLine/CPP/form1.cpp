

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following example demonstrates using the 
// RichTextBox.GetLineFromCharIndex method.
using namespace System::Windows::Forms;
using namespace System;
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
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::RichTextBox^ RichTextBox1;
   System::Windows::Forms::TextBox^ TextBox1;
   System::Windows::Forms::TextBox^ TextBox2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->RichTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->TextBox2 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 40, 32 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 80, 40 );
      this->Button1->TabIndex = 1;
      this->Button1->Text = "Find line numbers.";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //RichTextBox1
      //
      this->RichTextBox1->Location = System::Drawing::Point( 40, 88 );
      this->RichTextBox1->Name = "RichTextBox1";
      this->RichTextBox1->TabIndex = 2;
      this->RichTextBox1->Text = "This text will contain name several times."
      "Here is name again, and again: name";
      
      //
      //TextBox1
      //
      this->TextBox1->Location = System::Drawing::Point( 168, 104 );
      this->TextBox1->Multiline = true;
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 88, 64 );
      this->TextBox1->TabIndex = 3;
      this->TextBox1->Text = "";
      
      //
      //TextBox2
      //
      this->TextBox2->Location = System::Drawing::Point( 152, 48 );
      this->TextBox2->Name = "TextBox2";
      this->TextBox2->TabIndex = 4;
      this->TextBox2->Text = "name";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->TextBox2 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->RichTextBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // This method demonstrates retrieving line numbers that 
   // indicate the location of a particular word
   // contained in a RichTextBox. The line numbers are zero-based.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Reset the results box.
      TextBox1->Text = "";
      
      // Get the word to search from from TextBox2.
      String^ searchWord = TextBox2->Text;
      int index = 0;
      
      //Declare an ArrayList to store line numbers.
      System::Collections::ArrayList^ lineList = gcnew System::Collections::ArrayList;
      do
      {
         // Find occurrences of the search word, incrementing  
         // the start index. 
         index = RichTextBox1->Find( searchWord, index + 1, RichTextBoxFinds::MatchCase );
         if ( index != -1 )
         {
            lineList->Add( RichTextBox1->GetLineFromCharIndex( index ) );
         }
      }
      while ( (index != -1) );

      // Iterate through the list and display the line numbers in TextBox1.
      System::Collections::IEnumerator^ myEnumerator = lineList->GetEnumerator();
      if ( lineList->Count <= 0 )
      {
         TextBox1->Text = searchWord + " was not found";
      }
      else
      {
         TextBox1->SelectedText = searchWord + " was found on line(s):";
         while ( myEnumerator->MoveNext() )
         {
            TextBox1->SelectedText = myEnumerator->Current + " ";
         }
      }
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
