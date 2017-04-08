

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Class1
{
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:

   void EnterNull()
   {
      
      // Creates an instance of a class derived from DataGridBoolColumn.
      MyDataGridBoolColumn^ colBool;
      colBool = dynamic_cast<MyDataGridBoolColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 2 ]);
      colBool->CallEnterNullValue();
   }


internal:

   // Class derived from DataGridBoolColumn.
   ref class MyDataGridBoolColumn: public DataGridBoolColumn
   {
   public:
      void CallEnterNullValue()
      {
         this->EnterNullValue();
      }

   };

   // </Snippet1>
};
