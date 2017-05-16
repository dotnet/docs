#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   void AddHandler()
   {
      dataGrid1->TableStyles->CollectionChanged +=
         gcnew CollectionChangeEventHandler( this, &Form1::Collection_Changed );
   }

   void Collection_Changed( Object^ sender, CollectionChangeEventArgs^ e )
   {
      GridTableStylesCollection^ gts = (GridTableStylesCollection^)(sender);
      Console::WriteLine( gts->Count );
   }

   // </Snippet1>
};
