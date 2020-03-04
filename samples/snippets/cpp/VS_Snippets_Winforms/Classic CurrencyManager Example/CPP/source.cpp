

#using <system.dll>
#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   CurrencyManager^ myCurrencyManager;
   void BindControl( DataTable^ myTable )
   {
      
      // Bind a TextBox control to a DataTable column in a DataSet.
      textBox1->DataBindings->Add( "Text", myTable, "CompanyName" );
      
      // Specify the CurrencyManager for the DataTable.
      this->myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ myTable ]);
      
      // Set the initial Position of the control.
      this->myCurrencyManager->Position = 0;
   }

   void MoveNext( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Position == myCurrencyManager->Count - 1 )
      {
         MessageBox::Show( "You're at end of the records" );
      }
      else
      {
         myCurrencyManager->Position += 1;
      }
   }

   void MoveFirst( CurrencyManager^ myCurrencyManager )
   {
      myCurrencyManager->Position = 0;
   }

   void MovePrevious( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Position == 0 )
      {
         MessageBox::Show( "You're at the beginning of the records." );
      }
      else
      {
         myCurrencyManager->Position -= 1;
      }
   }

   void MoveLast( CurrencyManager^ myCurrencyManager )
   {
      myCurrencyManager->Position = myCurrencyManager->Count - 1;
   }

   // </Snippet1>
};

int main()
{
   return 0;
}
