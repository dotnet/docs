

#using <system.dll>
#using <system.data.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   void GetDataGridTextBox()
   {
      
      // Get the DataGridTextBoxColumn from the DataGrid control.
      DataGridTextBoxColumn^ myTextBoxColumn;
      
      // Assuming the CompanyName column is a DataGridTextBoxColumn.
      myTextBoxColumn = dynamic_cast<DataGridTextBoxColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ "CompanyName" ]);
      
      // Get the DataGridTextBox for the column.
      DataGridTextBox^ myGridTextBox;
      myGridTextBox = dynamic_cast<DataGridTextBox^>(myTextBoxColumn->TextBox);
   }

   // </Snippet1>
};

int main()
{
   return 0;
}
