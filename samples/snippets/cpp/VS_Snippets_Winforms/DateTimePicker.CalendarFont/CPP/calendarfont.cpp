#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyClass: public Form
{
   // <snippet1>
public:
   MyClass()
   {
      // Create a new DateTimePicker.
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      array<Control^>^ myClassControls = {dateTimePicker1};
      Controls->AddRange( myClassControls );
      dateTimePicker1->CalendarFont = gcnew System::Drawing::Font(
         "Courier New", 8.25F, FontStyle::Italic, GraphicsUnit::Point, ((Byte)(0)) );
   }
   // </snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew MyClass );
}
