#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      this->Button1->Click += gcnew EventHandler( this, &Form1::Button1_Click );
      this->Button2->Click += gcnew EventHandler( this, &Form1::Button2_Click );
      this->Paint += gcnew PaintEventHandler( this, &Form1::Form1_Paint );

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
   System::Windows::Forms::Button^ Button2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 40, 208 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Button1";
      
      //
      //Button2
      //
      this->Button2->Location = System::Drawing::Point( 152, 208 );
      this->Button2->Name = "Button2";
      this->Button2->TabIndex = 1;
      this->Button2->Text = "Button2";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   // The following code example demonstrates how to create a CharacterRange 
   // and use it to highlight part of a string. This sample is designed to be
   // used with Windows Forms.  Paste the example into a form and
   // call the HighlightACharacterRange method when handling the 
   // form's Paint event, passing e as PaintEventArgs.
   // 
   //<snippet1>
   void HighlightACharacterRange( PaintEventArgs^ e )
   {
      // Declare the string to draw.
      String^ message = "This is the string to highlight a word in.";

      // Declare the word to highlight.
      String^ searchWord = "string";

      // Create a CharacterRange array with the searchWord 
      // location and length.
      array<CharacterRange>^ temp = {CharacterRange( message->IndexOf( searchWord ), searchWord->Length )};
      array<CharacterRange>^ranges = temp;

      // Construct a StringFormat object.
      StringFormat^ stringFormat1 = gcnew StringFormat;

      // Set the ranges on the StringFormat object.
      stringFormat1->SetMeasurableCharacterRanges( ranges );

      // Declare the font to write the message in.
      System::Drawing::Font^ largeFont = gcnew System::Drawing::Font( FontFamily::GenericSansSerif,16.0F,GraphicsUnit::Pixel );

      // Construct a new Rectangle.
      Rectangle displayRectangle = Rectangle(20,20,200,100);

      // Convert the Rectangle to a RectangleF.
      RectangleF displayRectangleF = displayRectangle;

      // Get the Region to highlight by calling the 
      // MeasureCharacterRanges method.
      array<System::Drawing::Region^>^charRegion = e->Graphics->MeasureCharacterRanges( message, largeFont, displayRectangleF, stringFormat1 );

      // Draw the message string on the form.
      e->Graphics->DrawString( message, largeFont, Brushes::Blue, displayRectangleF );

      // Fill in the region using a semi-transparent color.
      e->Graphics->FillRegion( gcnew SolidBrush( Color::FromArgb( 50, Color::Fuchsia ) ), charRegion[ 0 ] );
      delete largeFont;
   }
   //</snippet1>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      HighlightACharacterRange( e );
   }

   // The following code example demonstrates the Color.op_Equality operator. 
   // This example is designed to be used with a Windows Form that  
   // contains a button named Button1.  Paste the following code into  
   // your form and associate the Button1_Click method with the button's
   // Click event.
   //<snippet2>    
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( this->BackColor == SystemColors::ControlDark )
      {
         this->BackColor = SystemColors::Control;
      }
   }
   //</snippet2>

   // The following code example demonstrates the Color.op_Inequality 
   // operator. This example is designed to be used with a Windows Form 
   // that contains a button named Button2.  Paste the following code 
   // into your form and associate the Button2_Click method with the
   //  button's Click event.
   //<snippet3>
   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( this->BackColor != SystemColors::ControlDark )
      {
         this->BackColor = SystemColors::ControlDark;
      }

      if (  !(this->Font->Bold) )
      {
         this->Font = gcnew System::Drawing::Font( this->Font,FontStyle::Bold );
      }
   }
   //</snippet3>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

/*
This example of the
  Decimal::ToInt64( Decimal ) and
  Decimal::ToUInt64( Decimal )
methods generates the following output. It
displays several converted Decimal values.

         Decimal argument     __int64/exception      unsigned __int64
         ----------------     -----------------      ----------------
                      123                   123                   123
                  123.000                   123                   123
                  123.999                   123                   123
 18446744073709551615.999     OverflowException  18446744073709551615
     18446744073709551616     OverflowException     OverflowException
  9223372036854775807.999   9223372036854775807   9223372036854775807
      9223372036854775808     OverflowException   9223372036854775808
                   -0.999                     0                     0
                       -1                    -1     OverflowException
 -9223372036854775808.999  -9223372036854775808     OverflowException
     -9223372036854775809     OverflowException     OverflowException
*/
