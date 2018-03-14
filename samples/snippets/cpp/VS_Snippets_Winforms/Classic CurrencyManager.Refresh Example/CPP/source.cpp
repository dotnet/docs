

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   void DemonstrateRefresh()
   {
      
      // Create an array with ten elements and bind to a TextBox.
      array<String^>^myArray = gcnew array<String^>(10);
      for ( int i = 0; i < 10; i++ )
      {
         myArray[ i ] = String::Format( "item {0}", i );

      }
      textBox1->DataBindings->Add( "Text", myArray, "" );
      
      // Change one value.
      myArray[ 0 ] = "New value";
      
      // Uncomment the next line to refresh the CurrencyManager.
      // RefreshGrid(myArray);
   }

   void RefreshGrid( Object^ dataSource )
   {
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ dataSource ]);
      myCurrencyManager->Refresh();
   }

   // </Snippet1>
};
