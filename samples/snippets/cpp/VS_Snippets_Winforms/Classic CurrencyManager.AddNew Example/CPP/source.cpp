

#using <System.dll>
#using <System.Xml.dll>
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
   DataTable^ DataTable1;

private:

   // <Snippet1>
   void AddListItem()
   {
      
      // Get the CurrencyManager for a DataTable.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ DataTable1 ]);
      myCurrencyManager->AddNew();
   }

   // </Snippet1>
};
