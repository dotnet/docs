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
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::Button^ layoutButton;
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      InitializeComponent();
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
   void InitializeComponent()
   {
      this->layoutButton = gcnew System::Windows::Forms::Button;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();

      // 
      // layoutButton
      // 
      this->layoutButton->Anchor = System::Windows::Forms::AnchorStyles::Bottom;
      this->layoutButton->Location = System::Drawing::Point( 72, 88 );
      this->layoutButton->Name = "layoutButton";
      this->layoutButton->Size = System::Drawing::Size( 150, 23 );
      this->layoutButton->TabIndex = 0;
      this->layoutButton->Text = "Hello";

      // 
      // textBox1
      // 
      this->textBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
      this->textBox1->Location = System::Drawing::Point( 24, 40 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 248, 20 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "Hello";
      this->textBox1->TextChanged += gcnew System::EventHandler( this, &Form1::textBox1_TextChanged );

      // 
      // label1
      // 
      this->label1->Location = System::Drawing::Point( 24, 16 );
      this->label1->Name = "label1";
      this->label1->TabIndex = 2;
      this->label1->Text = "Button's Text:";

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 129 );
      array<System::Windows::Forms::Control^>^temp0 = {this->label1,this->textBox1,this->layoutButton};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Layout Sample";
      this->Layout += gcnew System::Windows::Forms::LayoutEventHandler( this, &Form1::Form1_Layout );
      this->ResumeLayout( false );
   }

   // This method ensures that the form's width is the preferred size of 300 pixels
   // or the size of the button plus 50 pixels, whichever amount is less.
   void Form1_Layout( Object^ /*sender*/, System::Windows::Forms::LayoutEventArgs^ e )
   {
      // This event is raised once at startup with the AffectedControl
      // and AffectedProperty properties on the LayoutEventArgs as null. 
      // The event provides size preferences for that case.
      if ( (e->AffectedControl != nullptr) && (e->AffectedProperty != nullptr) )
      {
         // Ensure that the affected property is the Bounds property
         // of the form.
         if ( e->AffectedProperty->ToString()->Equals( "Bounds" ) )
         {
            // If layoutButton's width plus a padding of 50 pixels is greater than the preferred 
            // size of 300 pixels, increase the form's width.
            if ( (this->layoutButton->Width + 50) > 300 )
            {
               this->Width = this->layoutButton->Width + 50;
            }
            // If not, keep the form's width at 300 pixels.
            else
            {
               this->Width = 300;
            }

            // Center layoutButton on the form.
            this->layoutButton->Left = (this->ClientSize.Width - this->layoutButton->Width) / 2;
         }
      }
   }

   // This method sets the Text property of layoutButton to the Text property
   // of textBox1.  If the new text plus a padding of 20 pixels is larger than 
   // the preferred size of 150 pixels, increase layoutButton's Width property.
   void textBox1_TextChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Set the Text property of layoutButton.
      this->layoutButton->Text = this->textBox1->Text;

      // Get the width of the text using the proper font.
      int textWidth = (int)this->CreateGraphics()->MeasureString( layoutButton->Text, layoutButton->Font ).Width;

      // If the width of the text plus a padding of 20 pixels is greater than the preferred size of
      // 150 pixels, increase layoutButton's width.
      if ( (textWidth + 20) > 150 )
      {
         // Setting the size property on any control raises 
         // the Layout event for its container.
         this->layoutButton->Width = textWidth + 20;
      }
      // If not, keep layoutButton's width at 150 pixels.
      else
      {
         this->layoutButton->Width = 150;
      }
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
