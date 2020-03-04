

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
private:
   TabControl^ tabControl1;
   Rectangle myTabRect;

public:
   Form1()
   {
      tabControl1 = gcnew TabControl;
      TabPage^ tabPage1 = gcnew TabPage;
      tabControl1->Controls->Add( tabPage1 );
      tabControl1->DrawMode = TabDrawMode::OwnerDrawFixed;
      tabControl1->Location = Point(25,25);
      tabControl1->Size = System::Drawing::Size( 250, 250 );
      tabPage1->TabIndex = 0;
      
      // Gets the tabPage1 tab area defined by its TabIndex.
      // Returns a Rectangle to myTabRect.
      myTabRect = tabControl1->GetTabRect( 0 );
      ClientSize = System::Drawing::Size( 300, 300 );
      Controls->Add( tabControl1 );
      tabControl1->DrawItem += gcnew DrawItemEventHandler( this, &Form1::OnDrawItem );
   }


private:
   void OnDrawItem( Object^ /*sender*/, DrawItemEventArgs^ e )
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
