public ref class MyGridColumn: public DataGridTextBoxColumn
{
public:
   Size GetPrefSize( Graphics^ g, String^ val )
   {
      return this->GetPreferredSize( g, val );
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:
   void GetPreferredSize()
   {
      Graphics^ g;
      g = this->CreateGraphics();
      System::Drawing::Size gridPreferredSize;
      MyGridColumn^ myTextColumn;
      
      // Assuming column 1 of a DataGrid control is a 
      // DataGridTextBoxColumn.
      myTextColumn = dynamic_cast<MyGridColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 1 ]);
      String^ myVal;
      myVal = "A long string value";
      gridPreferredSize = myTextColumn->GetPrefSize( g, myVal );
      Console::WriteLine( gridPreferredSize );
   }

};