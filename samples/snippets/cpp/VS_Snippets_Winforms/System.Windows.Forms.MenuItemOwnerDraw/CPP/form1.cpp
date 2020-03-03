

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeMenu();
      
      //Add any initialization after the InitializeComponent() call
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
   }

   //<snippet1>
internal:
   // Declare the MainMenu control.
   System::Windows::Forms::MainMenu^ MainMenu1;

   // Declare MenuItem2 as With-Events because it will be user drawn.
   System::Windows::Forms::MenuItem^ MenuItem2;

private:
   void InitializeMenu()
   {
      
      // Create MenuItem1, which will be drawn by the operating system.
      MenuItem^ MenuItem1 = gcnew MenuItem( "Regular Menu Item" );
      
      // Create MenuItem2.
      MenuItem2 = gcnew MenuItem( "Custom Menu Item" );
      
      // Set OwnerDraw property to true. This requires handling the
      // DrawItem event for this menu item.
      MenuItem2->OwnerDraw = true;
      
      //Add the event-handler delegate to handle the DrawItem event.
      MenuItem2->DrawItem += gcnew DrawItemEventHandler( this, &Form1::DrawCustomMenuItem );
      
      // Add the items to the menu.
      array<MenuItem^>^temp0 = {MenuItem1,MenuItem2};
      MainMenu1 = gcnew MainMenu( temp0 );
      
      // Add the menu to the form.
      this->Menu = this->MainMenu1;
   }

   // Draw the custom menu item.
   void DrawCustomMenuItem( Object^ sender, DrawItemEventArgs^ e )
   {
      // Cast the sender to MenuItem so you can access text property.
      MenuItem^ customItem = dynamic_cast<MenuItem^>(sender);
      
      // Create a Brush and a Font to draw the MenuItem.
      System::Drawing::Brush^ aBrush = System::Drawing::Brushes::DarkMagenta;
      System::Drawing::Font^ aFont = gcnew System::Drawing::Font( "Garamond",10,FontStyle::Italic,GraphicsUnit::Point );
      
      // Get the size of the text to use later to draw an ellipse
      // around the item.
      SizeF stringSize = e->Graphics->MeasureString( customItem->Text, aFont );
      
      // Draw the item and then draw the ellipse.
      e->Graphics->DrawString( customItem->Text, aFont, aBrush, (float)e->Bounds.X, (float)e->Bounds.Y );
      e->Graphics->DrawEllipse( gcnew Pen( System::Drawing::Color::Black,2 ), Rectangle(e->Bounds.X,e->Bounds.Y,(System::Int32)stringSize.Width,(System::Int32)stringSize.Height) );
   }
   //</snippet1>
};

[System::STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
