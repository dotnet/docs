#using <System.Data.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Drawing2D;
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
      
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::Form1_Paint );
   }

   // Snippet for: M:System.Drawing.Pen.Clone
   // <snippet1>
public:
   void Clone_Example( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,5.0f );
      
      // Clone myPen.
      Pen^ clonePen = dynamic_cast<Pen^>(myPen->Clone());
      
      // Draw a line with clonePen.
      e->Graphics->DrawLine( clonePen, 0, 0, 100, 100 );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Pen.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
   // <snippet2>
public:
   void MultiplyTransform_Example1( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,5.0f );
      
      // Create a translation matrix.
      Matrix^ penMatrix = gcnew Matrix;
      penMatrix->Scale( 3, 1 );
      
      // Multiply the transformation matrix of myPen by transMatrix.
      myPen->MultiplyTransform( penMatrix );
      
      // Draw a line to the screen.
      e->Graphics->DrawLine( myPen, 0, 0, 100, 100 );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Pen.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet3>
public:
   void MultiplyTransform_Example2( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,5.0f );
      
      // Create a translation matrix.
      Matrix^ penMatrix = gcnew Matrix;
      penMatrix->Scale( 3, 1 );
      
      // Multiply the transformation matrix of myPen by transMatrix.
      myPen->MultiplyTransform( penMatrix, MatrixOrder::Prepend );
      
      // Draw a line to the screen.
      e->Graphics->DrawLine( myPen, 0, 0, 100, 100 );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Pen.ResetTransform
   // <snippet4>
public:
   void ResetTransform_Example( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ myPen = gcnew Pen( Color::Black,3.0f );
      
      // Scale the transformation matrix of myPen.
      myPen->ScaleTransform( 2, 1 );
      
      // Draw a line with myPen.
      e->Graphics->DrawLine( myPen, 10, 0, 10, 200 );
      
      // Reset the transformation matrix of myPen to identity.
      myPen->ResetTransform();
      
      // Draw a second line with myPen.
      e->Graphics->DrawLine( myPen, 100, 0, 100, 200 );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Pen.RotateTransform(System.Single)
   // <snippet5>
public:
   void RotateTransform_Example1( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ rotatePen = gcnew Pen( Color::Black,5.0f );
      
      // Draw a rectangle with rotatePen.
      e->Graphics->DrawRectangle( rotatePen, 10, 10, 100, 100 );
      
      // Scale rotatePen by 2X in the x-direction.
      rotatePen->ScaleTransform( 2, 1 );
      
      // Rotate rotatePen 90 degrees clockwise.
      rotatePen->RotateTransform( 90 );
      
      // Draw a second rectangle with rotatePen.
      e->Graphics->DrawRectangle( rotatePen, 140, 10, 100, 100 );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Pen.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet6>
public:
   void RotateTransform_Example2( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ rotatePen = gcnew Pen( Color::Black,5.0f );
      
      // Scale rotatePen by 2X in the x-direction.
      rotatePen->ScaleTransform( 2, 1 );
      
      // Draw a rectangle with rotatePen.
      e->Graphics->DrawRectangle( rotatePen, 10, 10, 100, 100 );
      
      // Rotate rotatePen 90 degrees clockwise.
      rotatePen->RotateTransform( 90, MatrixOrder::Append );
      
      // Draw a second rectangle with rotatePen.
      e->Graphics->DrawRectangle( rotatePen, 120, 10, 100, 100 );
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Pen.ScaleTransform(System.Single,System.Single)
   // <snippet7>
public:
   void ScaleTransform_Example1( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ scalePen = gcnew Pen( Color::Black,5.0f );
      
      // Draw a rectangle with scalePen.
      e->Graphics->DrawRectangle( scalePen, 10, 10, 100, 100 );
      
      // Scale scalePen by 2X in the x-direction.
      scalePen->ScaleTransform( 2, 1 );
      
      // Draw a second rectangle with rotatePen.
      e->Graphics->DrawRectangle( scalePen, 120, 10, 100, 100 );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Pen.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet8>
public:
   void ScaleTransform_Example2( PaintEventArgs^ e )
   {
      
      // Create a Pen object.
      Pen^ scalePen = gcnew Pen( Color::Black,5.0f );
      
      // Draw a rectangle with scalePen.
      e->Graphics->DrawRectangle( scalePen, 10, 10, 100, 100 );
      
      // Scale scalePen by 2X in the x-direction.
      scalePen->ScaleTransform( 2, 1, MatrixOrder::Prepend );
      
      // Draw a second rectangle with rotatePen.
      e->Graphics->DrawRectangle( scalePen, 120, 10, 100, 100 );
   }
   // </snippet8>

   // Snippet for: M:System.Drawing.Pen.SetLineCap(System.Drawing.Drawing2D.LineCap,System.Drawing.Drawing2D.LineCap,System.Drawing.Drawing2D.DashCap)
   // <snippet9>
public:
   void SetLineCap_Example( PaintEventArgs^ e )
   {
      
      // Create a Pen object with a dash pattern.
      Pen^ capPen = gcnew Pen( Color::Black,5.0f );
      capPen->DashStyle = DashStyle::Dash;
      
      // Set the start and end caps for capPen.
      capPen->SetLineCap( LineCap::ArrowAnchor, LineCap::Flat, DashCap::Flat );
      
      // Draw a line with capPen.
      e->Graphics->DrawLine( capPen, 10, 10, 200, 10 );
   }
   // </snippet9>

private:
   void Form1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ e )
   {
      SetLineCap_Example( e );
   }
};


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
