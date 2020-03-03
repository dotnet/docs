//<snippet1>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Security::Permissions;

// This example shows how to create your own column style that
// hosts a control, in this case, a DateTimePicker.

public ref class CustomDateTimePicker : public DateTimePicker
{
protected:
    [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
    virtual bool ProcessKeyMessage( Message% m ) override
    {
        // Keep all the keys for the DateTimePicker.
        return ProcessKeyEventArgs( m );
    }
};

public ref class DataGridTimePickerColumn : public DataGridColumnStyle
{
private:
   CustomDateTimePicker^ customDateTimePicker1;

   // The isEditing field tracks whether or not the user is
   // editing data with the hosted control.
   bool isEditing;

public:
   DataGridTimePickerColumn()
   {
      customDateTimePicker1 = gcnew CustomDateTimePicker;
      customDateTimePicker1->Visible = false;
   }

protected:
   virtual void Abort( int /*rowNum*/ ) override
   {
      isEditing = false;
      customDateTimePicker1->ValueChanged -=
         gcnew EventHandler( this, &DataGridTimePickerColumn::TimePickerValueChanged );
      Invalidate();
   }

   virtual bool Commit( CurrencyManager^ dataSource, int rowNum ) override
   {
      customDateTimePicker1->Bounds = Rectangle::Empty;

      customDateTimePicker1->ValueChanged -=
         gcnew EventHandler( this, &DataGridTimePickerColumn::TimePickerValueChanged );
      
      if (  !isEditing )
         return true;

      isEditing = false;

      try
      {
         DateTime value = customDateTimePicker1->Value;
         SetColumnValueAtRow( dataSource, rowNum, value );
      }
      catch ( Exception^ ) 
      {
         Abort( rowNum );
         return false;
      }

      Invalidate();
      return true;
   }

   virtual void Edit(
      CurrencyManager^ source,
      int rowNum,
      Rectangle bounds,
      bool /*readOnly*/,
      String^ /*displayText*/,
      bool cellIsVisible ) override
   {
      DateTime value =  (DateTime)
         GetColumnValueAtRow( source, rowNum );
      if ( cellIsVisible )
      {
         customDateTimePicker1->Bounds = Rectangle(
            bounds.X + 2, bounds.Y + 2,
            bounds.Width - 4, bounds.Height - 4 );
         customDateTimePicker1->Value = value;
         customDateTimePicker1->Visible = true;
         customDateTimePicker1->ValueChanged +=
            gcnew EventHandler( this, &DataGridTimePickerColumn::TimePickerValueChanged );
      }
      else
      {
         customDateTimePicker1->Value = value;
         customDateTimePicker1->Visible = false;
      }

      if ( customDateTimePicker1->Visible )
         DataGridTableStyle->DataGrid->Invalidate( bounds );

      customDateTimePicker1->Focus();
   }

   virtual System::Drawing::Size GetPreferredSize(
      Graphics^ /*g*/,
      Object^ /*value*/ ) override
   {
      return Size( 100, customDateTimePicker1->PreferredHeight + 4);
   }

   virtual int GetMinimumHeight() override
   {
      return customDateTimePicker1->PreferredHeight + 4;
   }

   virtual int GetPreferredHeight( Graphics^ /*g*/,
      Object^ /*value*/ ) override
   {
      return customDateTimePicker1->PreferredHeight + 4;
   }

   virtual void Paint( Graphics^ g,
      Rectangle bounds,
      CurrencyManager^ source,
      int rowNum ) override
   {
      Paint( g, bounds, source, rowNum, false );
   }

   virtual void Paint(
      Graphics^ g,
      Rectangle bounds,
      CurrencyManager^ source,
      int rowNum,
      bool alignToRight ) override
   {
      Paint(
         g, bounds,
         source,
         rowNum,
         Brushes::Red,
         Brushes::Blue,
         alignToRight );
   }

   virtual void Paint(
      Graphics^ g,
      Rectangle bounds,
      CurrencyManager^ source,
      int rowNum,
      Brush^ backBrush,
      Brush^ foreBrush,
      bool /*alignToRight*/ ) override
   {
      DateTime date =  (DateTime)
         GetColumnValueAtRow( source, rowNum );
      Rectangle rect = bounds;
      g->FillRectangle( backBrush, rect );
      rect.Offset( 0, 2 );
      rect.Height -= 2;
      g->DrawString( date.ToString( "d" ),
         this->DataGridTableStyle->DataGrid->Font,
         foreBrush, rect );
   }

   virtual void SetDataGridInColumn( DataGrid^ value ) override
   {
      DataGridColumnStyle::SetDataGridInColumn( value );
      if ( customDateTimePicker1->Parent != nullptr )
      {
         customDateTimePicker1->Parent->Controls->Remove
            ( customDateTimePicker1 );
      }
      if ( value != nullptr )
      {
         value->Controls->Add( customDateTimePicker1 );
      }
   }

private:
   void TimePickerValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Remove the handler to prevent it from being called twice in a row.
      customDateTimePicker1->ValueChanged -=
         gcnew EventHandler( this, &DataGridTimePickerColumn::TimePickerValueChanged );
      this->isEditing = true;
      DataGridColumnStyle::ColumnStartedEditing( customDateTimePicker1 );
   }
};

public ref class MyForm: public Form
{
private:
   DataTable^ namesDataTable;
   DataGrid^ grid;
public:
   MyForm()
   {
      grid = gcnew DataGrid;

      InitForm();

      namesDataTable = gcnew DataTable( "NamesTable" );
      namesDataTable->Columns->Add( gcnew DataColumn( "Name" ) );
      DataColumn^ dateColumn = gcnew DataColumn
         ( "Date",DateTime::typeid );
      dateColumn->DefaultValue = DateTime::Today;
      namesDataTable->Columns->Add( dateColumn );
      DataSet^ namesDataSet = gcnew DataSet;
      namesDataSet->Tables->Add( namesDataTable );
      grid->DataSource = namesDataSet;
      grid->DataMember = "NamesTable";
      AddGridStyle();
      AddData();
   }

private:
   void AddGridStyle()
   {
      DataGridTableStyle^ myGridStyle = gcnew DataGridTableStyle;
      myGridStyle->MappingName = "NamesTable";
      DataGridTextBoxColumn^ nameColumnStyle =
         gcnew DataGridTextBoxColumn;
      nameColumnStyle->MappingName = "Name";
      nameColumnStyle->HeaderText = "Name";
      myGridStyle->GridColumnStyles->Add( nameColumnStyle );

      DataGridTimePickerColumn^ timePickerColumnStyle =
         gcnew DataGridTimePickerColumn;
      timePickerColumnStyle->MappingName = "Date";
      timePickerColumnStyle->HeaderText = "Date";
      timePickerColumnStyle->Width = 100;
      myGridStyle->GridColumnStyles->Add( timePickerColumnStyle );

      grid->TableStyles->Add( myGridStyle );
   }

   void AddData()
   {
      DataRow^ dRow = namesDataTable->NewRow();
      dRow->default[ "Name" ] = "Name 1";
      dRow->default[ "Date" ] = DateTime(2001,12,01);
      namesDataTable->Rows->Add( dRow );

      dRow = namesDataTable->NewRow();
      dRow->default[ "Name" ] = "Name 2";
      dRow->default[ "Date" ] = DateTime(2001,12,04);
      namesDataTable->Rows->Add( dRow );

      dRow = namesDataTable->NewRow();
      dRow->default[ "Name" ] = "Name 3";
      dRow->default[ "Date" ] = DateTime(2001,12,29);
      namesDataTable->Rows->Add( dRow );

      dRow = namesDataTable->NewRow();
      dRow->default[ "Name" ] = "Name 4";
      dRow->default[ "Date" ] = DateTime(2001,12,13);
      namesDataTable->Rows->Add( dRow );

      dRow = namesDataTable->NewRow();
      dRow->default[ "Name" ] = "Name 5";
      dRow->default[ "Date" ] = DateTime(2001,12,21);
      namesDataTable->Rows->Add( dRow );

      namesDataTable->AcceptChanges();
   }

   void InitForm()
   {
      this->Size = System::Drawing::Size( 500, 500 );
      grid->Size = System::Drawing::Size( 350, 250 );
      grid->TabStop = true;
      grid->TabIndex = 1;
      this->StartPosition = FormStartPosition::CenterScreen;
      this->Controls->Add( grid );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
//</snippet1>
