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
   void TryContainsDataMember( DataSet^ myDataSet )
   {
      bool trueorfalse;
      trueorfalse = this->BindingContext->Contains( myDataSet, "Suppliers" );
      Console::WriteLine( trueorfalse );
   }
   // </Snippet1>
};
