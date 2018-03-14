

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   void GetCurrentItem()
   {
      CurrencyManager^ myCurrencyManager;
      
      // Get the CurrencyManager of a TextBox control.
      myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // Get the current item cast as a DataRowView.
      DataRowView^ myDataRowView;
      myDataRowView = dynamic_cast<DataRowView^>(myCurrencyManager->Current);
      
      // Print the column named ContactName.
      Console::WriteLine( myDataRowView[ "ContactName" ] );
   }

   // </Snippet1>
};
