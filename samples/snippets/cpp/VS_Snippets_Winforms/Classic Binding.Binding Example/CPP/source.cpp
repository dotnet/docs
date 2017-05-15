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
   DataSet^ myDataSet;

   // <Snippet1>
private:
   void CreateDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      /* Populates the DataSet with tables, relations, and 
         constraints. */
   }

   void BindTextBoxToDataSet()
   {
      /* Binds a TextBox control to a DataColumn named
      CompanyName in the DataTable named Suppliers. */
      textBox1->DataBindings->Add(
         "Text", myDataSet, "Suppliers.CompanyName" );
   }
   // </Snippet1>
};
