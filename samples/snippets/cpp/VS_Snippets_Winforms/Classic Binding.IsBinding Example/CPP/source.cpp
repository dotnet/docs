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
   void PrintBindingIsBinding()
   {
      for each ( Control^ c in this->Controls )
      {
         for each ( Binding^ b in c->DataBindings )
         {
            Console::WriteLine( "\n {0}", c );
            Console::WriteLine( "{0} IsBinding: {1}",
               b->PropertyName, b->IsBinding );
         }
      }
   }
   // </Snippet1>
};
