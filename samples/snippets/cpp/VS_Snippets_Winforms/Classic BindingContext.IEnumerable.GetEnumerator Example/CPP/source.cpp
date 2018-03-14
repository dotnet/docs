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
   void GetManagerEnumerator()
   {
      IEnumerator^ myEnumerator;
      myEnumerator = ( (IEnumerable^)(this->BindingContext) )->GetEnumerator();
      ForEachEnumerator();
   }

   void ForEachEnumerator()
   {
      for each ( IEnumerator^ myEnumerator in ( (IEnumerable^)(this->BindingContext) ) )
      {
         Console::WriteLine( myEnumerator );
      }
   }
   // </Snippet1>
};
