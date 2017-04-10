#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void PrintCount()
   {
      Console::WriteLine( "BindingContext->Count {0}",
      ( (ICollection^)(this->BindingContext) )->Count );
   }
   // </Snippet1>
};
