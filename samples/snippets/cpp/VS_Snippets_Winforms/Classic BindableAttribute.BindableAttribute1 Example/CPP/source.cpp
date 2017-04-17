

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

public:

   property int MyProperty 
   {

      // <Snippet1>

      [Bindable(BindableSupport::Yes)]
      int get()
      {
         
         // Insert code here.
         return 0;
      }

      void set( int theValue )
      {
         
         // Insert code here.
      }

   }
   // </Snippet1>
};
