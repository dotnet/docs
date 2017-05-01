#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   BindingManagerBase^ myBindingManagerBase;

   // <Snippet1>
private:
   void BindingManagerBase_CurrentChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      // Print the new value of the current object.
      Console::Write( "Current Changed: " );
      Console::WriteLine( ( (BindingManagerBase^)(sender) )->Current );
   }

   void MoveNext()
   {
      // Increment the Position property value by one.
      myBindingManagerBase->Position = myBindingManagerBase->Position + 1;
   }

   void MovePrevious()
   {
      // Decrement the Position property value by one.
      myBindingManagerBase->Position = myBindingManagerBase->Position - 1;
   }

   void MoveFirst()
   {
      // Go to the first item in the list.
      myBindingManagerBase->Position = 0;
   }

   void MoveLast()
   {
      // Go to the last row in the list.
      myBindingManagerBase->Position = myBindingManagerBase->Count - 1;
   }
   // </Snippet1>
};
