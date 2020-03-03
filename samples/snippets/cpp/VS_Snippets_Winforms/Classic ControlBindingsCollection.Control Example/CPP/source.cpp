#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
private:
   void GetControl( ControlBindingsCollection^ myBindings )
   {
      Control^ c = myBindings->Control;
      Console::WriteLine( c );
   }
   // </Snippet1>
};
