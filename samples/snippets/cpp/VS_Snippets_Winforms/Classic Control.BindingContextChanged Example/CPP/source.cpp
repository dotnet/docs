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
   void AddEventHandler()
   {
      textBox1->BindingContextChanged += gcnew EventHandler(
         this, &Form1::BindingContext_Changed );
   }

   void BindingContext_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Console::WriteLine( "BindingContext changed" );
   }
   // </Snippet1>
};
