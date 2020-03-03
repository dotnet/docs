#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
public:
   void CreateMyRichTextBox()
   {
      RichTextBox^ richTextBox1 = gcnew RichTextBox;
      richTextBox1->Dock = DockStyle::Fill;

      richTextBox1->LoadFile( "C:\\MyDocument.rtf" );
      richTextBox1->Find( "Text", RichTextBoxFinds::MatchCase );

      richTextBox1->SelectionFont = gcnew System::Drawing::Font(
         "Verdana", 12, FontStyle::Bold );
      richTextBox1->SelectionColor = Color::Red;

      richTextBox1->SaveFile( "C:\\MyDocument.rtf",
         RichTextBoxStreamType::RichText );

      this->Controls->Add( richTextBox1 );
   }
   // </Snippet1>
};
