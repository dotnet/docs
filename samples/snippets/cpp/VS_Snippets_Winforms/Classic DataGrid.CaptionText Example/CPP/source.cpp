#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;
   void Method()
   {
      
      // <Snippet1>
      if ( dataGrid1->CaptionText == "" )
      {
         dataGrid1->CaptionText = "Microsoft DataGrid";
      }      
      // </Snippet1>
   }
};
