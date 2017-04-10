#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void HorizontallyTileMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Tile all child forms horizontally.
      this->LayoutMdi( MdiLayout::TileHorizontal );
   }

   void VerticallyTileMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Tile all child forms vertically.
      this->LayoutMdi( MdiLayout::TileVertical );
   }

   void CascadeMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Cascade all MDI child windows.
      this->LayoutMdi( MdiLayout::Cascade );
   }
   // </Snippet1>
};
