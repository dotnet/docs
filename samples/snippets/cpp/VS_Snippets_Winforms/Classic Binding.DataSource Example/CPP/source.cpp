

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
   TextBox^ text1;

   // <Snippet1>
private:
   void GetDataSource()
   {
      DataSet^ ds = dynamic_cast<DataSet^>(text1->DataBindings[nullptr]->DataSource);
      Console::WriteLine( ds->Tables[ 0 ]->TableName );
   }

   // </Snippet1>
};
