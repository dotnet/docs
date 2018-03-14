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

   // Snippet for: M:System.Drawing.RectangleF.Inflate(System.Drawing.SizeF)
   // <snippet1>
public:
   void RectangleFInflateExample( PaintEventArgs^ e )
   {
      // Create a RectangleF structure.
      RectangleF myRectF = RectangleF(100,20,100,100);

      // Draw myRect to the screen.
      Rectangle myRect = Rectangle::Truncate( myRectF );
      e->Graphics->DrawRectangle( Pens::Black, myRect );

      // Create a Size structure.
      SizeF inflateSize = SizeF(100,0);

      // Inflate myRect.
      myRectF.Inflate( inflateSize );

      // Draw the inflated rectangle to the screen.
      myRect = Rectangle::Truncate( myRectF );
      e->Graphics->DrawRectangle( Pens::Red, myRect );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.RectangleF.Intersect(System.Drawing.RectangleF,System.Drawing.RectangleF)
   // <snippet2>
public:
   void RectangleFIntersectExample( PaintEventArgs^ e )
   {
      // Create two rectangles.
      RectangleF firstRectangleF = RectangleF(0,0,75,50);
      RectangleF secondRectangleF = RectangleF(50,20,50,50);

      // Convert the RectangleF structures to Rectangle structures and draw them to the
      // screen.
      Rectangle firstRect = Rectangle::Truncate( firstRectangleF );
      Rectangle secondRect = Rectangle::Truncate( secondRectangleF );
      e->Graphics->DrawRectangle( Pens::Black, firstRect );
      e->Graphics->DrawRectangle( Pens::Red, secondRect );

      // Get the intersection.
      RectangleF intersectRectangleF = RectangleF::Intersect( firstRectangleF, secondRectangleF );

      // Draw the intersectRectangleF to the screen.
      Rectangle intersectRect = Rectangle::Truncate( intersectRectangleF );
      e->Graphics->DrawRectangle( Pens::Blue, intersectRect );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.RectangleF.Union(System.Drawing.RectangleF,System.Drawing.RectangleF)
   // <snippet3>
public:
   void RectangleFUnionExample( PaintEventArgs^ e )
   {
      // Create two rectangles and draw them to the screen.
      RectangleF firstRectangleF = RectangleF(0,0,75,50);
      RectangleF secondRectangleF = RectangleF(100,100,20,20);

      // Convert the RectangleF structures to Rectangle structures and draw them to the
      // screen.
      Rectangle firstRect = Rectangle::Truncate( firstRectangleF );
      Rectangle secondRect = Rectangle::Truncate( secondRectangleF );
      e->Graphics->DrawRectangle( Pens::Black, firstRect );
      e->Graphics->DrawRectangle( Pens::Red, secondRect );

      // Get the union rectangle.
      RectangleF unionRectangleF = RectangleF::Union( firstRectangleF, secondRectangleF );

      // Draw the unionRectangleF to the screen.
      Rectangle unionRect = Rectangle::Truncate( unionRectangleF );
      e->Graphics->DrawRectangle( Pens::Blue, unionRect );
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
