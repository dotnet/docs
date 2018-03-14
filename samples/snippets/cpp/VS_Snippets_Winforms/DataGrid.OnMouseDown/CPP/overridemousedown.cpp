#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::ComponentModel;

namespace DataGridSample
{
   //<snippet1>
   public ref class MyDataGrid: public DataGrid
   {
   protected:

      // Override the OnMouseDown event to select the whole row
      // when the user clicks anywhere on a row.
      virtual void OnMouseDown( MouseEventArgs^ e ) override
      {
         
         // Get the HitTestInfo to return the row and pass
         // that value to the IsSelected property of the DataGrid.
         DataGrid::HitTestInfo ^ hit = this->HitTest( e->X, e->Y );
         if ( hit->Row < 0 )
                  return;

         if ( this->IsSelected( hit->Row ) )
                  UnSelect( hit->Row );
         else
                  Select(hit->Row);
      }
   };
   //</snippet1>

   public ref class MyDataGridForm: public Form
   {
   private:
      DataTable^ dataTable;
      DataGridSample::MyDataGrid^ grid;
      Button^ button1;
      Label^ label1;

   public:
      MyDataGridForm()
      {
         grid = gcnew DataGridSample::MyDataGrid;
         button1 = gcnew Button;
         label1 = gcnew Label;
         InitForm();
         dataTable = gcnew DataTable( "name" );
         dataTable->Columns->Add( gcnew DataColumn( "First" ) );
         DataColumn^ column = gcnew DataColumn( "name" );
         dataTable->Columns->Add( column );
         dataTable->Columns->Add( gcnew DataColumn( "Second",bool::typeid ) );
         
         //dataTable.Columns->Item[S"First"].ReadOnly = true;
         DataSet^ First = gcnew DataSet;
         First->Tables->Add( dataTable );
         grid->DataSource = First;
         grid->DataMember = "name";
         AddSomeData();
         
         // grid.SetDataBinding(First, S"name");
         // grid.ReadOnly = true;
         // grid.DataMember = S"First";
         button1->Click += gcnew EventHandler( this, &MyDataGridForm::OnButtonClick );
      }

   private:
      void OnButtonClick( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         
         //combo.Sorted = true;
         // grid->Item[0, 0] = S"nou";
         // grid.SetDataBinding(0, S"");
         //DataGridSample::SortDataGrid.Sort(grid, S"First", true);
      }

      void grid_Enter( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         grid->CurrentCell = DataGridCell(2,2);
      }

      void AddSomeData()
      {
         DataRow^ dRow;
         for ( int i = 0; i < 5; i++ )
         {
            dRow = dataTable->NewRow();
            dRow[ "First" ] = String::Format( "FirstName {0}", i );
            dRow[ "name" ] = String::Format( "LastName {0}", i );
            dataTable->Rows->Add( dRow );
         }
      }

      void foo( Object^ /*sender*/, KeyEventArgs^ /*e*/ )
      {
         Console::WriteLine( "on key down handler called" );
      }

      void InitForm()
      {
         this->Size = System::Drawing::Size( 700, 500 );
         button1->Location = Point(300,300);
         button1->Text = "Sort the grid programatically";
         button1->Width = 200;
         grid->Size = System::Drawing::Size( 350, 250 );
         grid->TabStop = true;
         grid->TabIndex = 1;
         button1->TabStop = true;
         button1->TabIndex = 1;
         label1->Width = 300;
         label1->Height = 100;
         label1->Top = grid->Top;
         label1->Left = grid->Right + 10;
         label1->Text = "The grid on this app overrides the OnMouseDown event, so that when the user clicks anywhere on the grid, the user will select the row beneath the mouse cursor";
         this->Controls->Add( label1 );
         this->StartPosition = FormStartPosition::CenterScreen;
         this->Controls->Add( grid );
         this->Controls->Add( button1 );
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew DataGridSample::MyDataGridForm );
}
