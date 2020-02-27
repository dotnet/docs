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
   void dataGrid1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      Console::WriteLine();
      System::Windows::Forms::DataGrid::HitTestInfo^ myHitTest;
      // Use the DataGrid control's HitTest method with the x and y properties.
      myHitTest = dataGrid1->HitTest( e->X, e->Y );
      Console::WriteLine( myHitTest );
      Console::WriteLine( "Column {0}", myHitTest->Column );
      Console::WriteLine( "Row {0}", myHitTest->Row );
      Console::WriteLine( "Type {0}", myHitTest->Type );
      Console::WriteLine( "ToString {0}", myHitTest );
      Console::WriteLine( "Hit {0}", myHitTest->Type );
   }
   // </Snippet1>
};
