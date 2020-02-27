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
   void CreateMyFormat2()
   {
      DataFormats::Format^ myFormat = gcnew DataFormats::Format(
         "AnotherNewFormat", 20916 );
      
      // Displays the contents of myFormat.
      textBox1->Text = String::Format( "ID value: {0}\nFormat name: {1}",
         myFormat->Id, myFormat->Name );
   }
   // </Snippet1>
};
