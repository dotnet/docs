

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   ComboBox^ comboBox1;
   ComboBox^ comboBox2;
   NumericUpDown^ numericUpDown1;

private:

   // <Snippet1>
   void comboBox1_SelectedIndexChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Set the BorderStyle property.
      if ( comboBox1->Text->Equals( "Fixed3D" ) )
            numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      else
      if ( comboBox1->Text->Equals( "None" ) )
            numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::None;
      else
      if ( comboBox1->Text->Equals( "FixedSingle" ) )
            numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
   }

   void comboBox2_SelectedIndexChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Set the TextAlign property.    
      if ( comboBox2->Text->Equals( "Right" ) )
            numericUpDown1->TextAlign = HorizontalAlignment::Right;

      if ( comboBox2->Text->Equals( "Left" ) )
            numericUpDown1->TextAlign = HorizontalAlignment::Left;

      if ( comboBox2->Text->Equals( "Center" ) )
            numericUpDown1->TextAlign = HorizontalAlignment::Center;
   }

   void checkBox1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Evaluate and toggle the ReadOnly property.
      if ( numericUpDown1->ReadOnly )
      {
         numericUpDown1->ReadOnly = false;
      }
      else
      {
         numericUpDown1->ReadOnly = true;
      }
   }

   void checkBox2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Evaluate and toggle the InterceptArrowKeys property.
      if ( numericUpDown1->InterceptArrowKeys )
      {
         numericUpDown1->InterceptArrowKeys = false;
      }
      else
      {
         numericUpDown1->InterceptArrowKeys = true;
      }
   }

   void checkBox3_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Evaluate and toggle the UpDownAlign property.
      if ( numericUpDown1->UpDownAlign == LeftRightAlignment::Left )
      {
         numericUpDown1->UpDownAlign = LeftRightAlignment::Right;
      }
      else
      {
         numericUpDown1->UpDownAlign = LeftRightAlignment::Left;
      }
   }

   // </Snippet1>
};
