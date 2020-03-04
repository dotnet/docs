#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void PrintPropertyNameAndIsBinding()
   {
      for each ( Control^ thisControl in this->Controls)
      {
         for each ( Binding^ thisBinding in thisControl->DataBindings )
         {
            Console::WriteLine( "\n {0}", thisControl );
            // Print the PropertyName value for each binding.
            Console::WriteLine( thisBinding->PropertyName );
         }
      }
   }
   // </Snippet1>
};
