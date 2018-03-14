#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void TryContains( DataSet^ myDataSet )
   {
      // Test each DataTable in a DataSet to see if it is bound to a BindingManagerBase.
      for each ( DataTable^ thisTable in myDataSet->Tables )
      {
         Console::WriteLine( "{0}: {1}", thisTable->TableName, this->BindingContext->Contains( thisTable ) );
      }
   }
   // </Snippet1>
};
