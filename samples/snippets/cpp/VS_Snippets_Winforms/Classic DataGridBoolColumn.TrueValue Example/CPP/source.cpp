

#using <System.Xml.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ myDataGrid;
   DataSet^ DataSet1;

   // <Snippet1>
private:

   void SetBoolColumnValues()
   {
      DataGridBoolColumn^ myGridColumn;
      
      // Get the DataGridBoolColumn you are setting.
      myGridColumn = dynamic_cast<DataGridBoolColumn^>(myDataGrid->TableStyles[ "Customers" ]->GridColumnStyles[ "Current" ]);
      
      // Set TrueValue, FalseValue, and NullValue.
      myGridColumn->TrueValue = true;
      myGridColumn->FalseValue = false;
      myGridColumn->NullValue = Convert::DBNull;
   }

   // </Snippet1>
};

int main(){}
