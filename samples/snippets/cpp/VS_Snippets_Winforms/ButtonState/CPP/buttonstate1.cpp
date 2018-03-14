

// <snippet2>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   Button^ button1;
   Button^ button2;

public:
   Form1()
   {
      button1 = gcnew Button;
      button2 = gcnew Button;
      this->button2->Location = Point(0,button1->Height + 10);
      this->Click += gcnew EventHandler( this, &Form1::button2_Click );
      this->Controls->Add( this->button1 );
      this->Controls->Add( this->button2 );
   }


private:

   // <snippet1>
   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Draws a flat button on button1.
      ControlPaint::DrawButton( System::Drawing::Graphics::FromHwnd( button1->Handle ), 0, 0, button1->Width, button1->Height, ButtonState::Flat );
   }

   // </snippet1>
};


[STAThread]
void main()
{
   Application::Run( gcnew Form1 );
}

// </snippet2>
