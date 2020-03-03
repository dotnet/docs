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
protected:
   CheckBox^ checkBox1;
   Label^ label1;

   // <Snippet1>
private:
   void AdjustMyCheckBoxProperties()
   {
      // Concatenate the property values together on three lines.
      label1->Text = String::Format( "ThreeState: {0}\nChecked: {1}\nCheckState: {2}",
         checkBox1->ThreeState, checkBox1->Checked, checkBox1->CheckState );
      
      // Change the ThreeState and CheckAlign properties on every other click.
      if ( !checkBox1->ThreeState )
      {
         checkBox1->ThreeState = true;
         checkBox1->CheckAlign = ContentAlignment::MiddleRight;
      }
      else
      {
         checkBox1->ThreeState = false;
         checkBox1->CheckAlign = ContentAlignment::MiddleLeft;
      }
   }
   // </Snippet1>
};
