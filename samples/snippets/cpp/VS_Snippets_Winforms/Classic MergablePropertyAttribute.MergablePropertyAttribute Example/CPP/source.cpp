#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
public:
   [MergableProperty(true)]
   property int MyProperty 
   {
      int get()
      {
         // Insert code here.
         return 0;
      }
      void set( int value )
      {
         // Insert code here.
      }
   }
   // </Snippet1>
};
