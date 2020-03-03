#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::IO;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void GetMyFormatInfomation()
   {
      // Creates a DataFormats.Format for the Unicode data format.
      DataFormats::Format^ myFormat = DataFormats::GetFormat(
         DataFormats::UnicodeText );
      
      // Displays the contents of myFormat.
      textBox1->Text = String::Format( "ID value: {0}\nFormat name: {1}",
         myFormat->Id, myFormat->Name );
   }
   // </Snippet1>
};
