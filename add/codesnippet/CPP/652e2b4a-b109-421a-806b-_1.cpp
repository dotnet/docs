public ref class MyGridColumn: public DataGridTextBoxColumn
{
public:
   int GetPrefHeight( Graphics^ g, String^ thisString )
   {
      return this->GetPreferredHeight( g, thisString );
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:
   void GetHeight()
   {
      MyGridColumn^ myGridColumn;
      
      // Get a DataGridColumnStyle of a DataGrid control.
      myGridColumn = dynamic_cast<MyGridColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ "CompanyName" ]);
      
      // Create a Graphics object.
      Graphics^ g = this->CreateGraphics();
      Console::WriteLine( myGridColumn->GetPrefHeight( g, "A string" ) );
   }

};
