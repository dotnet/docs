

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
   void PrintListItems()
   {
      
      // Get the CurrencyManager of a TextBox control.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // Presuming the list is a DataView, create a DataRowView variable.
      DataRowView^ drv;
      for ( int i = 0; i < myCurrencyManager->Count; i++ )
      {
         myCurrencyManager->Position = i;
         drv = dynamic_cast<DataRowView^>(myCurrencyManager->Current);
         
         // Presuming a column named CompanyName exists.
         Console::WriteLine( drv[ "CompanyName" ] );

      }
   }

   // </Snippet1>
};
