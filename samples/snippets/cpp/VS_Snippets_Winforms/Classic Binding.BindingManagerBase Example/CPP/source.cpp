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
   void PrintPositions()
   {
      for each ( Control^ c in this->Controls )
      {
         for each ( Binding^ xBinding in c->DataBindings )
         {
            Console::WriteLine(
               "{0}\t Position: {1}",
               c, xBinding->BindingManagerBase->Position );
         }
      }
   }
   // </Snippet1>
};
