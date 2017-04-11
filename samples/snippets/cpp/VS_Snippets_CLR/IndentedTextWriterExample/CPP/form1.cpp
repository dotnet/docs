

//<Snippet1>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::ComponentModel;
using namespace System::IO;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TextBox^ textBox1;

   //<Snippet2>
   String^ CreateMultilevelIndentString()
   {
      
      //<Snippet3>
      // Creates a TextWriter to use as the base output writer.
      System::IO::StringWriter^ baseTextWriter = gcnew System::IO::StringWriter;
      
      // Create an IndentedTextWriter and set the tab string to use 
      // as the indentation string for each indentation level.
      System::CodeDom::Compiler::IndentedTextWriter^ indentWriter = gcnew IndentedTextWriter( baseTextWriter,"    " );
      
      //</Snippet3>
      //<Snippet4>
      // Sets the indentation level.
      indentWriter->Indent = 0;
      
      //</Snippet4>
      // Output test strings at stepped indentations through a recursive loop method.
      WriteLevel( indentWriter, 0, 5 );
      
      // Return the resulting string from the base StringWriter.
      return baseTextWriter->ToString();
   }


   //<Snippet5>
   void WriteLevel( IndentedTextWriter^ indentWriter, int level, int totalLevels )
   {
      
      // Output a test string with a new-line character at the end.
      indentWriter->WriteLine( "This is a test phrase. Current indentation level: {0}", level );
      
      // If not yet at the highest recursion level, call this output method for the next level of indentation.
      if ( level < totalLevels )
      {
         
         // Increase the indentation count for the next level of indented output.
         indentWriter->Indent++;
         
         // Call the WriteLevel method to write test output for the next level of indentation.
         WriteLevel( indentWriter, level + 1, totalLevels );
         
         // Restores the indentation count for this level after the recursive branch method has returned.
         indentWriter->Indent--;
      }
      else
      //<Snippet6>
      // Outputs a string using the WriteLineNoTabs method.
            indentWriter->WriteLineNoTabs( "This is a test phrase written with the IndentTextWriter.WriteLineNoTabs method." );
      //</Snippet6>
      // Outputs a test string with a new-line character at the end.
      indentWriter->WriteLine( "This is a test phrase. Current indentation level: {0}", level );
   }


   //</Snippet5>
   //</Snippet2>
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      textBox1->Text = CreateMultilevelIndentString();
   }


public:
   Form1()
   {
      System::Windows::Forms::Button^ button1 = gcnew System::Windows::Forms::Button;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      this->textBox1->Anchor = (System::Windows::Forms::AnchorStyles)(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->textBox1->Location = System::Drawing::Point( 8, 40 );
      this->textBox1->Multiline = true;
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 391, 242 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "";
      button1->Location = System::Drawing::Point( 11, 8 );
      button1->Name = "button1";
      button1->Size = System::Drawing::Size( 229, 23 );
      button1->TabIndex = 1;
      button1->Text = "Generate string using IndentedTextWriter";
      button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      this->AutoScaleBaseSize = System::Drawing::Size( 5, 13 );
      this->ClientSize = System::Drawing::Size( 407, 287 );
      this->Controls->Add( button1 );
      this->Controls->Add( this->textBox1 );
      this->Name = "Form1";
      this->Text = "IndentedTextWriter example";
      this->ResumeLayout( false );
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
