

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   Rectangle tabArea;
   RectangleF tabTextArea;

public:
   Form1()
   {
      TabControl^ tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      
      // Allows access to the DrawItem event.
      tabControl1->DrawMode = TabDrawMode::OwnerDrawFixed;
      tabControl1->SizeMode = TabSizeMode::Fixed;
      tabControl1->Controls->Add( tabPage1 );
      tabControl1->ItemSize = System::Drawing::Size( 80, 30 );
      tabControl1->Location = Point(25,25);
      tabControl1->Size = System::Drawing::Size( 250, 250 );
      tabPage1->TabIndex = 0;
      ClientSize = System::Drawing::Size( 300, 300 );
      Controls->Add( tabControl1 );
      tabArea = tabControl1->GetTabRect( 0 );
      tabTextArea = tabControl1->GetTabRect( 0 );
      
      // Binds the event handler DrawOnTab to the DrawItem event
      // through the DrawItemEventHandler delegate.
      tabControl1->DrawItem += gcnew DrawItemEventHandler( this, &Form1::DrawOnTab );
   }


private:

   // Declares the event handler DrawOnTab which is a method that
   // draws a String* and Rectangle on the tabPage1 tab.
   void DrawOnTab( Object^ /*sender*/, DrawItemEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      Pen^ p = gcnew Pen( Color::Blue );
      System::Drawing::Font^ font = gcnew System::Drawing::Font( "Arial",10.0f );
      SolidBrush^ brush = gcnew SolidBrush( Color::Red );
      g->DrawRectangle( p, tabArea );
      g->DrawString( "tabPage1", font, brush, tabTextArea );
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

// </snippet1>
