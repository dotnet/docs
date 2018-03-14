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
      // Create a new DateTimePicker
      DateTimePicker^ dateTimePicker1 = gcnew DateTimePicker;
      array<Control^>^ myClassControls = {dateTimePicker1};
      Controls->AddRange( myClassControls );
      MessageBox::Show( dateTimePicker1->Value.ToString() );

      dateTimePicker1->Value = DateTime::Now.AddDays( 1 );
      MessageBox::Show( dateTimePicker1->Value.ToString() );
   }
   // </snippet1>
};

[STAThread]
void main()
{
   Application::Run( gcnew MyClass );
}
