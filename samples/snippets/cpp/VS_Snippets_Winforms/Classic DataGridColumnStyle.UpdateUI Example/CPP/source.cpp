

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace MyNameSpace
{
   ref class MyDataGridColumnStyle: public DataGridTextBoxColumn
   {
   private:
      CurrencyManager^ myCurrencyManager;
      DataGrid^ dataGrid1;

      // <Snippet1>
      void UpdateGridUI()
      {
         
         // Get the MyDataGridColumnStyle to update.
         // MyDataGridColumnStyle is a class derived from DataGridColumnStyle.
         MyDataGridColumnStyle^ myGridColumn = dynamic_cast<MyDataGridColumnStyle^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ "CompanyName" ]);
         
         // Call UpdateUI.
         myGridColumn->UpdateUI( myCurrencyManager, 10, "my new value" );
      }
      // </Snippet1>


   protected:

      void SetDataGrid( DataGrid^ dataGrid2, CurrencyManager^ curMan2 )
      {
         myCurrencyManager = curMan2;
         dataGrid1 = dataGrid2;
      }

      virtual void Edit( System::Windows::Forms::CurrencyManager^ /*source*/, int /*rowNum*/, System::Drawing::Rectangle /*bounds*/, bool /*readOnly1*/, String^ /*displayText*/, bool /*cellIsVisiblen*/ ) override {}

      virtual bool Commit( System::Windows::Forms::CurrencyManager^ /*dataSource*/, int /*rowNum*/ ) override
      {
         return true;
      }

      virtual System::Drawing::Size GetPreferredSize( System::Drawing::Graphics^ /*g*/, Object^ /*value*/ ) override
      {
         return Size(Point(1,2));
      }

      virtual int GetPreferredHeight( System::Drawing::Graphics^ /*g*/, Object^ /*value*/ ) override
      {
         return 1;
      }

      virtual int GetMinimumHeight() override
      {
         return 1;
      }

      virtual void Abort( int /*rowNum*/ ) override {}

      virtual void Paint( System::Drawing::Graphics^ /*g*/, System::Drawing::Rectangle /*bounds*/, System::Windows::Forms::CurrencyManager^ /*source*/, int /*rowNum*/, bool /*b*/ ) override {}

      virtual void Paint( System::Drawing::Graphics^ /*g*/, System::Drawing::Rectangle /*bounds*/, System::Windows::Forms::CurrencyManager^ /*source*/, int /*rowNum*/ ) override{}

   };

}
