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
   void CopyToArray()
   {
      // Declare the array.
      array<Object^>^ myArray = gcnew array<Object^>(100);
      ( (ICollection^)(this->BindingContext) )->CopyTo( myArray, 0 );
   }
   // </Snippet1>
};
