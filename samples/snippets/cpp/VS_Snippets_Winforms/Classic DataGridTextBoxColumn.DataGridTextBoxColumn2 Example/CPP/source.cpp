

#using <System.dll>
#using <System.Xml.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;
using namespace System::Globalization;

ref class Form1: public Form
{
private:
   DataGrid^ dataGrid1; // = new DataGrid();

   // <Snippet1>
private:
   void AddColumn( DataTable^ myTable )
   {
      // Add a new DataColumn to the DataTable.
      DataColumn^ myColumn = gcnew DataColumn( "myTextBoxColumn" );
      myColumn->DataType = String::typeid;
      myColumn->DefaultValue = "default string";
      myTable->Columns->Add( myColumn );

      // Get the ListManager for the DataTable.
      CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(this->BindingContext[ myTable ]);

      // Use the ListManager to get the PropertyDescriptor for the new column.
      PropertyDescriptor^ pd = cm->GetItemProperties()[ "myTextBoxColumn" ];

      // Create a new DataTimeFormat object.
      DateTimeFormatInfo^ fmt = gcnew DateTimeFormatInfo;

      // Insert code to set format.
      DataGridTextBoxColumn^ myColumnTextColumn;

      // Create the DataGridTextBoxColumn with the PropertyDescriptor and Format.
      myColumnTextColumn = gcnew DataGridTextBoxColumn( pd,fmt->SortableDateTimePattern );

      // Add the new DataGridColumnStyle to the GridColumnsCollection.
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->Add( myColumnTextColumn );
   }
   // </Snippet1>
};
