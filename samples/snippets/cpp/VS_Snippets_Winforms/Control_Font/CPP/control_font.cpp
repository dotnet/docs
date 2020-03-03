// System::Windows::Forms::Control::Font
// System::Windows::Forms::Control::FontChanged
// System::Windows::Forms::Control::Focused
// System::Windows::Forms::Control::Focus

/*
The following example demonstrates 'Font' & 'Focused' properties, 'Focus' 
method and 'FontChanged' event of 'Control' class.
A 'DateTimePicker' control and a 'Button' control are added to a form. The font 
property of 'DateTimePicker' control is changed to the font selected by user 
from 'FontDialog' control. An event handler function is attached
with 'FontChanged' event of 'DateTimePicker' control which sets the focus
on 'DateTimePicker' control.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyFormControl: public Form
{
private:
   FontDialog^ myFontDialog;
   DateTimePicker^ myDateTimePicker;
   Button^ myButton;

public:
   MyFormControl()
   {
      myDateTimePicker = gcnew DateTimePicker;
      myFontDialog = gcnew FontDialog;
      myButton = gcnew Button;
      myDateTimePicker->Location = Point( 48, 24 );
      myDateTimePicker->Name = "myDateTimePicker";
      myButton->Location = Point( 50, 150 );
      myButton->Name = "myButton";
      myButton->Size = System::Drawing::Size( 200, 40 );
      myButton->Text = "Change Font of Date Time Picker";
      myButton->Click += gcnew EventHandler( this, &MyFormControl::myButton_Click );
      ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^ formControls = {myDateTimePicker,myButton};
      Controls->AddRange( formControls );
      Text = "Control Example";
      AddEventHandler();
   }

   // <Snippet1>
private:
   void myButton_Click( Object^ sender, EventArgs^ e )
   {
      FontDialog^ myFontDialog = gcnew FontDialog;
      if ( myFontDialog->ShowDialog() == ::DialogResult::OK )
      {
         // Set the control's font.
         myDateTimePicker->Font = myFontDialog->Font;
      }
   }
   // </Snippet1>

   // <Snippet2>
private:
   void AddEventHandler()
   {
      // Add the event handler for 'FontChanged' event.
      myDateTimePicker->FontChanged += gcnew EventHandler(
         this, &MyFormControl::DateTimePicker_FontChanged );
   }

   void DateTimePicker_FontChanged( Object^ sender, EventArgs^ e )
   {
      // <Snippet3>
      // <Snippet4>
      if (  !myDateTimePicker->Focused )
      {
         // Set focus on 'DateTimePicker' control.
         myDateTimePicker->Focus();
      }
      // </Snippet4>
      // </Snippet3>
   }
   // </Snippet2>
};

int main()
{
   MyFormControl^ myForm = gcnew MyFormControl;
   myForm->ShowDialog();
}
