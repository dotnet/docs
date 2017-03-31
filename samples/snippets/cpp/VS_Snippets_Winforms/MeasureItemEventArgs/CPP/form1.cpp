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

//<Snippet1>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::ListBox^ listBox1;
   System::ComponentModel::Container^ components;

public:
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
      this->SuspendLayout();

      // 
      // listBox1
      // 
      this->listBox1->DrawMode = System::Windows::Forms::DrawMode::OwnerDrawVariable;
      this->listBox1->Location = System::Drawing::Point( 16, 48 );
      this->listBox1->Name = "listBox1";
      this->listBox1->SelectionMode = System::Windows::Forms::SelectionMode::MultiExtended;
      this->listBox1->Size = System::Drawing::Size( 256, 134 );
      this->listBox1->TabIndex = 0;
      this->listBox1->MeasureItem += gcnew System::Windows::Forms::MeasureItemEventHandler( this, &Form1::listBox1_MeasureItem );
      this->listBox1->DrawItem += gcnew System::Windows::Forms::DrawItemEventHandler( this, &Form1::listBox1_DrawItem );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 273 );
      array<System::Windows::Forms::Control^>^temp0 = {this->listBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void listBox1_MeasureItem( Object^ /*sender*/, MeasureItemEventArgs^ e )
   {
      System::Drawing::Font^ font = (dynamic_cast<ListBoxFontItem^>(listBox1->Items[ e->Index ]))->Font;
      SizeF stringSize = e->Graphics->MeasureString( font->Name, font );
      
      // Set the height and width of the item
      e->ItemHeight = (int)stringSize.Height;
      e->ItemWidth = (int)stringSize.Width;
   }

   // For efficiency, cache the brush to use for drawing.
   SolidBrush^ foreColorBrush;
   void listBox1_DrawItem( Object^ /*sender*/, DrawItemEventArgs^ e )
   {
      Brush^ brush;

      // Create the brush using the ForeColor specified by the DrawItemEventArgs
      if ( foreColorBrush == nullptr )
            foreColorBrush = gcnew SolidBrush( e->ForeColor );
      else
      if ( foreColorBrush->Color != e->ForeColor )
      {
         // The control's ForeColor has changed, so dispose of the cached brush and
         // create a new one.
         delete foreColorBrush;
         foreColorBrush = gcnew SolidBrush( e->ForeColor );
      }

      // Select the appropriate brush depending on if the item is selected.
      // Since State can be a combinateion (bit-flag) of enum values, you can't use
      // "==" to compare them.
      if ( (e->State & DrawItemState::Selected) == DrawItemState::Selected )
            brush = SystemBrushes::HighlightText;
      else
            brush = foreColorBrush;

      // Perform the painting.
      System::Drawing::Font^ font = (dynamic_cast<ListBoxFontItem^>(listBox1->Items[ e->Index ]))->Font;
      e->DrawBackground();
      e->Graphics->DrawString( font->Name, font, brush, e->Bounds );
      e->DrawFocusRectangle();
   }

public:

   /// <summary>
   ///  A wrapper class for use with storing Fonts in a ListBox.  Since ListBox uses the
   ///  ToString() of its items for the text it displays, this class is needed to return
   ///  the name of the font, rather than its ToString() value.
   /// </summary>
   ref class ListBoxFontItem
   {
   public:
      System::Drawing::Font^ Font;
      ListBoxFontItem( System::Drawing::Font^ f )
      {
         Font = f;
      }

      virtual String^ ToString() override
      {
         return Font->Name;
      }
   };
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
