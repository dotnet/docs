#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   Hashtable^ myHashTable;

public:
   Form1()
   {
      myHashTable = gcnew Hashtable;
   }

private:
   void Grid_MouseUp( Object^ sender, System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      DataGrid^ dg = dynamic_cast<DataGrid^>(sender);
      DataGridCell myCell = dg->CurrentCell;
      String^ tempkey = myCell.ToString();
      Console::WriteLine( "Temp {0}", tempkey );
      if ( myHashTable->Contains( tempkey ) )
      {
         return;
      }
      myHashTable->Add( tempkey, myCell.GetHashCode() );
      Console::WriteLine( "Hashcode: {0}", myCell.GetHashCode() );
   }
   // </Snippet1>
};
