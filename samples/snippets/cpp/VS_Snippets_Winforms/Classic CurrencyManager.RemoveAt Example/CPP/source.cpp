

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Data;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   void RemoveFromList()
   {
      
      // Get the CurrencyManager of a TextBox control.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // If the count is 0, exit the function.
      if ( myCurrencyManager->Count > 1 )
            myCurrencyManager->RemoveAt( 0 );
   }

   // </Snippet1>
};
