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
      String^ newLine = "\n";
      Console::WriteLine( newLine );
      System::Windows::Forms::DataGrid::HitTestInfo^ myHitTest;
      // Use the DataGrid control's HitTest method with the x and y properties.
      myHitTest = dataGrid1->HitTest( e->X, e->Y );
      Console::WriteLine( "Hashcode {0}", myHitTest->GetHashCode() );
   }
   // </Snippet1>
};
