#using <System.Data.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }

   // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Rectangle,System.Int32,System.Int32)
   // <snippet1>
public:
   void RectangleInflateTest( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rect = Rectangle(100,100,50,50);

      // Draw the uninflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Black, rect );

      // Call Inflate.
      Rectangle rect2 = Rectangle::Inflate( rect, 50, 50 );

      // Draw the inflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Red, rect2 );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Size)
   // <snippet2>
public:
   void RectangleInflateTest2( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rect = Rectangle(100,100,50,50);

      // Draw the uninflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Black, rect );

      // Set up the inflate size.
      System::Drawing::Size inflateSize = System::Drawing::Size( 50, 50 );

      // Call Inflate.
      rect.Inflate( inflateSize );

      // Draw the inflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Red, rect );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Int32,System.Int32)
   // <snippet3>
public:
   void RectangleInflateTest3( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rect = Rectangle(100,100,50,50);

      // Draw the uninflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Black, rect );

      // Call Inflate.
      rect.Inflate( 50, 50 );

      // Draw the inflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Red, rect );
   }
   // </snippet3>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
