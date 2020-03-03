#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

//<snippet1>
using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::ComponentModel;

public ref class DataGridBoolColumnInherit: public DataGridBoolColumn
{
private:
   SolidBrush^ trueBrush;
   SolidBrush^ falseBrush;
   DataColumn^ expressionColumn;
   static int count = 0;

public:
   DataGridBoolColumnInherit()
      : DataGridBoolColumn()
   {
      trueBrush = dynamic_cast<SolidBrush^>(Brushes::Blue);
      falseBrush = dynamic_cast<SolidBrush^>(Brushes::Yellow);
      expressionColumn = nullptr;
      count++;
   }

   property Color FalseColor 
   {
      Color get()
      {
         return falseBrush->Color;
      }

      void set( Color value )
      {
         falseBrush = gcnew System::Drawing::SolidBrush( value );
         Invalidate();
      }
   }

   property Color TrueColor 
   {
      Color get()
      {
         return trueBrush->Color;
      }

      void set( Color value )
      {
         trueBrush = gcnew System::Drawing::SolidBrush( value );
         Invalidate();
      }
   }

   property String^ Expression 
   {
      // This will work only with a DataSet or DataTable.
      // The code is not compatible with IBindingList* implementations.
      String^ get()
      {
         return this->expressionColumn == nullptr ? String::Empty : this->expressionColumn->Expression;
      }

      void set( String^ value )
      {
         if ( expressionColumn == nullptr )
                  AddExpressionColumn( value );
         else
                  expressionColumn->Expression = value;

         if ( expressionColumn != nullptr && expressionColumn->Expression->Equals( value ) )
                  return;

         Invalidate();
      }
   }

private:
   void AddExpressionColumn( String^ value )
   {
      // Get the grid's data source. First check for a 0 
      // table or data grid.
      if ( this->DataGridTableStyle == nullptr || this->DataGridTableStyle->DataGrid == nullptr )
            return;

      DataGrid^ myGrid = this->DataGridTableStyle->DataGrid;
      DataView^ myDataView = dynamic_cast<DataView^>((dynamic_cast<CurrencyManager^>(myGrid->BindingContext[ myGrid->DataSource,myGrid->DataMember ]))->List);

      // This works only with System::Data::DataTable.
      if ( myDataView == nullptr )
            return;

      // If the user already added a column with the name 
      // then exit. Otherwise, add the column and set the 
      // expression to the value passed to this function.
      DataColumn^ col = myDataView->Table->Columns[ "__Computed__Column__" ];
      if ( col != nullptr )
            return;

      col = gcnew DataColumn( String::Concat( "__Computed__Column__", count ) );
      myDataView->Table->Columns->Add( col );
      col->Expression = value;
      expressionColumn = col;
   }

   //  the OnPaint method to paint the cell based on the expression.
protected:
   virtual void Paint( Graphics^ g, Rectangle bounds, CurrencyManager^ source, int rowNum, Brush^ backBrush, Brush^ foreBrush, bool alignToRight ) override
   {
      bool trueExpression = false;
      bool hasExpression = false;
      DataRowView^ drv = dynamic_cast<DataRowView^>(source->List[ rowNum ]);
      hasExpression = this->expressionColumn != nullptr && this->expressionColumn->Expression != nullptr &&  !this->expressionColumn->Expression->Equals( String::Empty );
      Console::WriteLine( String::Format( "hasExpressionValue {0}", hasExpression ) );

      // Get the value from the expression column.
      // For simplicity, we assume a True/False value for the 
      // expression column.
      if ( hasExpression )
      {
         Object^ expr = drv->Row[ expressionColumn->ColumnName ];
         trueExpression = expr->Equals( "True" );
      }

      // Let the DataGridBoolColumn do the painting.
      if (  !hasExpression )
            DataGridBoolColumn::Paint( g, bounds, source, rowNum, backBrush, foreBrush, alignToRight );

      // Paint using the expression color for true or false, as calculated.
      if ( trueExpression )
            DataGridBoolColumn::Paint( g, bounds, source, rowNum, trueBrush, foreBrush, alignToRight );
      else
            DataGridBoolColumn::Paint( g, bounds, source, rowNum, falseBrush, foreBrush, alignToRight );
   }
};

public ref class MyForm: public Form
{
private:
   DataTable^ myTable;
   DataGrid^ myGrid;

public:
   MyForm()
   {
      myGrid = gcnew DataGrid;
      try
      {
         InitializeComponent();
         myTable = gcnew DataTable( "NamesTable" );
         myTable->Columns->Add( gcnew DataColumn( "Name" ) );
         DataColumn^ column = gcnew DataColumn( "id",Int32::typeid );
         myTable->Columns->Add( column );
         myTable->Columns->Add( gcnew DataColumn( "calculatedField",bool::typeid ) );
         DataSet^ namesDataSet = gcnew DataSet;
         namesDataSet->Tables->Add( myTable );
         myGrid->SetDataBinding( namesDataSet, "NamesTable" );
         AddTableStyle();
         AddData();
      }
      catch ( System::Exception^ exc ) 
      {
         Console::WriteLine( exc );
      }
   }

private:
   void grid_Enter( Object^ sender, EventArgs^ e )
   {
      myGrid->CurrentCell = DataGridCell(2,2);
   }

   void AddTableStyle()
   {
      // Map a new  TableStyle to the DataTable. Then 
      // add DataGridColumnStyle objects to the collection
      // of column styles with appropriate mappings.
      DataGridTableStyle^ dgt = gcnew DataGridTableStyle;
      dgt->MappingName = "NamesTable";
      DataGridTextBoxColumn^ dgtbc = gcnew DataGridTextBoxColumn;
      dgtbc->MappingName = "Name";
      dgtbc->HeaderText = "Name";
      dgt->GridColumnStyles->Add( dgtbc );
      dgtbc = gcnew DataGridTextBoxColumn;
      dgtbc->MappingName = "id";
      dgtbc->HeaderText = "id";
      dgt->GridColumnStyles->Add( dgtbc );
      DataGridBoolColumnInherit^ db = gcnew DataGridBoolColumnInherit;
      db->HeaderText = "less than 1000 = blue";
      db->Width = 150;
      db->MappingName = "calculatedField";
      dgt->GridColumnStyles->Add( db );
      myGrid->TableStyles->Add( dgt );

      // This expression instructs the grid to change
      // the color of the inherited DataGridBoolColumn
      // according to the value of the id field. If it's
      // less than 1000, the row is blue. Otherwise,
      // the color is yellow.
      db->Expression = "id < 1000";
   }

   void AddData()
   {
      // Add data with varying numbers for the id field.
      // If the number is over 1000, the cell will paint
      // yellow. Otherwise, it will be blue.
      DataRow^ dRow = myTable->NewRow();
      dRow[ "Name" ] = "name 1 ";
      dRow[ "id" ] = 999;
      myTable->Rows->Add( dRow );
      dRow = myTable->NewRow();
      dRow[ "Name" ] = "name 2";
      dRow[ "id" ] = 2300;
      myTable->Rows->Add( dRow );
      dRow = myTable->NewRow();
      dRow[ "Name" ] = "name 3";
      dRow[ "id" ] = 120;
      myTable->Rows->Add( dRow );
      dRow = myTable->NewRow();
      dRow[ "Name" ] = "name 4";
      dRow[ "id" ] = 4023;
      myTable->Rows->Add( dRow );
      dRow = myTable->NewRow();
      dRow[ "Name" ] = "name 5";
      dRow[ "id" ] = 2345;
      myTable->Rows->Add( dRow );
      myTable->AcceptChanges();
   }

   void InitializeComponent()
   {
      this->Size = System::Drawing::Size( 500, 500 );
      myGrid->Size = System::Drawing::Size( 350, 250 );
      myGrid->TabStop = true;
      myGrid->TabIndex = 1;
      this->StartPosition = FormStartPosition::CenterScreen;
      this->Controls->Add( myGrid );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
//</snippet1>
