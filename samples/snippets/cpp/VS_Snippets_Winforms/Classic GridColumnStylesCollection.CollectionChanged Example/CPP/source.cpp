

#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;
   DataSet^ dataSet1;

   // <Snippet1>
private:
   void AddHandler()
   {
      GridColumnStylesCollection^ myGridColumns;
      myGridColumns = dataGrid1->TableStyles[ 0 ]->GridColumnStyles;
      
      // Add the handler.
      myGridColumns->CollectionChanged += gcnew CollectionChangeEventHandler( this, &Form1::GridCollection_Changed );
   }

   void GridCollection_Changed( Object^ sender, CollectionChangeEventArgs^ /*e*/ )
   {
      GridColumnStylesCollection^ myGridColumns;
      myGridColumns = dynamic_cast<GridColumnStylesCollection^>(sender);
      Console::WriteLine( myGridColumns->Count );
   }
   // </Snippet1>
};
