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

   // <Snippet1>
private:
   void dataGrid1_MouseDown( Object^ /*sender*/,
     System::Windows::Forms::MouseEventArgs^ e )
   {
      if ( dataGrid1->HitTest( e->X, e->Y )->Equals(
         DataGrid::HitTestInfo::Nowhere ) )
      {
         Console::WriteLine( "Nowhere" );
      }
   }
   // </Snippet1>
};
