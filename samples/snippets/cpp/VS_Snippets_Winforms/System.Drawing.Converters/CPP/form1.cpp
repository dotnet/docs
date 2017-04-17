#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Drawing;
using namespace System;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }

protected:

   //Form overrides dispose to clean up the component list.
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
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::Form1_Paint );
   }

   // The following code example demonstrates how to use the 
   // PointConverter.ConvertFromString and the Point.op_Subtraction
   // methods. This example is designed to be used with Windows
   // Forms. Paste this code into a form and call the 
   // ShowPointConverter method when handling the form's Paint 
   // event, passing e as PaintEventArgs.
   //<snippet1>
   void ShowPointConverter( PaintEventArgs^ e )
   {
      // Create the PointConverter.
      System::ComponentModel::TypeConverter^ converter = System::ComponentModel::TypeDescriptor::GetConverter( Point::typeid );
      Point point1 =  *dynamic_cast<Point^>(converter->ConvertFromString( "200, 200" ));

      // Use the subtraction operator to get a second point.
      Point point2 = point1 - System::Drawing::Size( 190, 190 );

      // Draw a line between the two points.
      e->Graphics->DrawLine( Pens::Black, point1, point2 );
   }
   //</snippet1>

   // The following code example demonstrates how to use the 
   // ColorConverter.ConvertToString method. This example
   // is designed to be used with Windows Forms. Paste this code
   // into a form and call the ShowColorConverter method when
   // handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet2>
   void ShowColorConverter( PaintEventArgs^ e )
   {
      Color myColor = Color::PaleVioletRed;
      
      // Create the ColorConverter.
      System::ComponentModel::TypeConverter^ converter = System::ComponentModel::TypeDescriptor::GetConverter( myColor );
      String^ colorAsString = converter->ConvertToString( Color::PaleVioletRed );
      e->Graphics->DrawString( colorAsString, this->Font, Brushes::PaleVioletRed, 50.0F, 50.0F );
   }
   //</snippet2>

   // The following code example demonstrates how to use the 
   // ConvertToInvariantString and ConvertToString methods.  
   // This example is designed to be used with Windows Forms. 
   // Paste this code into a form and call the ShowFontStringConversion
   // method when handling the form's Paint event, passing e
   // as PaintEventArgs.
   //<snippet3>
   void ShowFontStringConversion( PaintEventArgs^ e )
   {
      // Create the FontConverter.
      System::ComponentModel::TypeConverter^ converter =
            System::ComponentModel::TypeDescriptor::GetConverter( System::Drawing::Font::typeid );
      System::Drawing::Font^ font1 = dynamic_cast<System::Drawing::Font^>(converter->ConvertFromString( "Arial, 12pt" ));
      String^ fontName1 = converter->ConvertToInvariantString( font1 );
      String^ fontName2 = converter->ConvertToString( font1 );
      e->Graphics->DrawString( fontName1, font1, Brushes::Red, 10, 10 );
      e->Graphics->DrawString( fontName2, font1, Brushes::Blue, 10, 30 );
   }
   //</snippet3>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      ShowFontStringConversion( e );
      ShowPointConverter( e );
      ShowColorConverter( e );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
