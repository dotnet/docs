

#using <system.dll>
#using <System.Drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>

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
   void comboBox1_SelectedIndexChanged( Object^ sender, EventArgs^ e )
   {
      // Set the BorderStyle property.
      if (  !String::Compare( comboBox1->Text, "Fixed3D" ) )
      {
         numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      }
      else
      if (  !String::Compare( comboBox1->Text, "None" ) )
      {
         numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::None;
      }
      else
      if (  !String::Compare( comboBox1->Text, "FixedSingle" ) )
      {
         numericUpDown1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      }
   }

   void comboBox2_SelectedIndexChanged( Object^ sender, EventArgs^ e )
   {
      // Set the TextAlign property.    
      if (  !String::Compare( comboBox2->Text, "Right" ) )
      {
         numericUpDown1->TextAlign = HorizontalAlignment::Right;
      }
      else
      if (  !String::Compare( comboBox1->Text, "Left" ) )
      {
         numericUpDown1->TextAlign = HorizontalAlignment::Left;
      }
      else
      if (  !String::Compare( comboBox1->Text, "Center" ) )
      {
         numericUpDown1->TextAlign = HorizontalAlignment::Center;
      }
   }

   void checkBox1_Click( Object^ sender, EventArgs^ e )
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

   void checkBox2_Click( Object^ sender, EventArgs^ e )
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

   void checkBox3_Click( Object^ sender, EventArgs^ e )
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

__int32 main()
{
   return 0;
}
