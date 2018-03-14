

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   Rectangle myTabRect;

public:
   Form1()
   {
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      tabControl1->DrawMode = TabDrawMode::OwnerDrawFixed;
      tabControl1->Appearance = TabAppearance::Buttons;
      tabControl1->Location = Point(25,25);
      tabControl1->Controls->Add( tabPage1 );
      Controls->Add( tabControl1 );
      
      // Gets a Rectangle that represents the tab page display area of tabControl1.
      myTabRect = tabControl1->DisplayRectangle;
      myTabRect.Inflate( 1, 1 );
      tabControl1->DrawItem += gcnew DrawItemEventHandler( this, &Form1::DrawOnTabPage );
   }


private:
   void DrawOnTabPage( Object^ /*sender*/, DrawItemEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      Pen^ p = gcnew Pen( Color::Blue );
      g->DrawRectangle( p, myTabRect );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
