public ref class MyGridColumn: public DataGridBoolColumn
{
public:
   int GetMinHeight()
   {
      return this->GetMinimumHeight();
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:
   void GetHeight()
   {
      MyGridColumn^ myGridColumn = dynamic_cast<MyGridColumn^>(dataGrid1->TableStyles[ 1 ]->GridColumnStyles[ 0 ]);
      Console::WriteLine( myGridColumn->GetMinHeight() );
   }

};
