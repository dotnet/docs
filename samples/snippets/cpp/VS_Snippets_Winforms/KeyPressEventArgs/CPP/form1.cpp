// <snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   Form1()
   {
      // Create a TextBox control.
      TextBox^ tb = gcnew TextBox;
      this->Controls->Add( tb );
      tb->KeyPress += gcnew KeyPressEventHandler( this, &Form1::keypressed );
   }

private:
   void keypressed( Object^ /*o*/, KeyPressEventArgs^ e )
   {
      // The keypressed method uses the KeyChar property to check 
      // whether the ENTER key is pressed. 
      // If the ENTER key is pressed, the Handled property is set to true, 
      // to indicate the event is handled.
      if ( e->KeyChar == (char)13 )
            e->Handled = true;
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}
// </snippet1>
