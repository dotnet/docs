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
   DateTimePicker^ dateTimePicker1;

   // <Snippet1>
public:
   void SetMyCustomFormat()
   {
      // Set the Format type and the CustomFormat string.
      dateTimePicker1->Format = DateTimePickerFormat::Custom;
      dateTimePicker1->CustomFormat = "MMMM dd, yyyy - dddd";
   }
   // </Snippet1>
};
