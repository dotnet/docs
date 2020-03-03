

// System::BindingManagerBase::RemoveAt
/* This program demonstrates the 'RemoveAt' method of 'BindingManagerBase' class.
* It creates a 'DataGrid' control and a 'button' control. If Remove button is pressed it deletes
* the selected row from the 'DataGrid' control.
*/
#using <System.Data.dll>
#using <System.Xml.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace WindowsApplication1
{
   public ref class Form1: public Form
   {
   private:
      Button^ button1;
      DataGrid^ dataGrid1;
      DataTable^ myDataTable;

   public:
      Form1()
      {
         InitializeComponent();
         MakeDataTableAndDisplay();
      }

   private:
      void InitializeComponent()
      {
         dataGrid1 = gcnew DataGrid;
         button1 = gcnew Button;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(dataGrid1))->BeginInit();
         SuspendLayout();
         
         // Create the 'DataGrid'.
         dataGrid1->DataMember = "";
         dataGrid1->Location = Point(32,32);
         dataGrid1->Name = "dataGrid1";
         dataGrid1->Size = System::Drawing::Size( 208, 80 );
         dataGrid1->TabIndex = 3;
         button1->Location = Point(280,40);
         button1->Name = "button1";
         button1->Size = System::Drawing::Size( 96, 23 );
         button1->TabIndex = 1;
         button1->Text = "Remove Row";
         button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         ClientSize = System::Drawing::Size( 400, 273 );
         array<Control^>^temp0 = {dataGrid1,button1};
         Controls->AddRange( temp0 );
         Name = "Form1";
         Text = "Form1";
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(dataGrid1))->EndInit();
         ResumeLayout( false );
      }

      // <Snippet1>
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         try
         {
            // Get the 'BindingManagerBase' Object*.
            BindingManagerBase^ myBindingManagerBase = BindingContext[ myDataTable ];

            // Remove the selected row from the grid.
            myBindingManagerBase->RemoveAt( myBindingManagerBase->Position );
         }
         catch ( Exception^ ex ) 
         {
            MessageBox::Show( ex->Source );
            MessageBox::Show( ex->Message );
         }
      }
      // </Snippet1>

      void MakeDataTableAndDisplay()
      {
         // Create new DataTable.
         myDataTable = gcnew DataTable( "MyDataTable" );
         DataColumn^ myDataColumn;
         DataRow^ myDataRow;

         // Create new 'DataColumn'.
         myDataColumn = gcnew DataColumn;

         // Set the 'DataType'.
         myDataColumn->DataType = System::Type::GetType( "System::Int32" );

         // Set the 'ColumnName'.
         myDataColumn->ColumnName = "id";

         // Add the column to the 'DataTable'.
         myDataTable->Columns->Add( myDataColumn );

         // Create second column.
         myDataColumn = gcnew DataColumn;
         myDataColumn->DataType = Type::GetType( "System::String" );
         myDataColumn->ColumnName = "item";
         myDataTable->Columns->Add( myDataColumn );

         // Create new DataRow objects and add to DataTable.
         for ( int i = 0; i < 10; i++ )
         {
            myDataRow = myDataTable->NewRow();
            myDataRow[ "id" ] = i;
            myDataRow[ "item" ] = "item {0}",i;
            myDataTable->Rows->Add( myDataRow );
         }
         dataGrid1->DataSource = myDataTable;
      }
   };
}

int main()
{
   Application::Run( gcnew WindowsApplication1::Form1 );
}
