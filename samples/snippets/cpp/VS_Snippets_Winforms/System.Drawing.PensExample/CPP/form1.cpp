

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      this->Paint += gcnew PaintEventHandler( this, &Form1::Form1_Paint );
      
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
      components = gcnew System::ComponentModel::Container;
      this->Text = "Form1";
   }

   // The following method demonstrates the effects of setting
   // the LineJoin property on a Pen object.
   // This example is designed to be used with Windows Forms.
   // Paste the code into a form and call the ShowLineJoin method when
   // handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet1>
private:
   void ShowLineJoin( PaintEventArgs^ e )
   {
      // Create a new pen.
      Pen^ skyBluePen = gcnew Pen( Brushes::DeepSkyBlue );

      // Set the pen's width.
      skyBluePen->Width = 8.0F;

      // Set the LineJoin property.
      skyBluePen->LineJoin = System::Drawing::Drawing2D::LineJoin::Bevel;

      // Draw a rectangle.
      e->Graphics->DrawRectangle( skyBluePen, Rectangle(40,40,150,200) );

      //Dispose of the pen.
      delete skyBluePen;
   }
   //</snippet1>

   // The following method demonstrates the effects of setting
   // the StartCap and EndCap properties on a Pen object.
   // This example is designed to be used with Windows Forms.
   // Paste the code into a form and call the ShowStartAndEndCaps
   // method when handling the form's Paint event, passing e 
   // as PaintEventArgs.
   //<snippet2>
private:
   void ShowStartAndEndCaps( PaintEventArgs^ e )
   {
      // Create a new custom pen.
      Pen^ redPen = gcnew Pen( Brushes::Red,6.0F );

      // Set the StartCap property.
      redPen->StartCap = System::Drawing::Drawing2D::LineCap::RoundAnchor;

      // Set the EndCap property.
      redPen->EndCap = System::Drawing::Drawing2D::LineCap::ArrowAnchor;

      // Draw a line.
      e->Graphics->DrawLine( redPen, 40.0F, 40.0F, 145.0F, 185.0F );

      // Dispose of the custom pen.
      delete redPen;
   }
   //</snippet2>

   // The following method demonstrates the effects of setting
   // the DashCap, DashPattern and SmoothingMode properties 
   // of a Pen object.
   // This example is designed to be used with Windows Forms. 
   // Paste the code into a form and call the ShowPensAndSmoothingMode
   // method when handling the form's Paint event, passing e as
   // PaintEventArgs.
   //<snippet3>
private:
   void ShowPensAndSmoothingMode( PaintEventArgs^ e )
   {
      // Set the SmoothingMode property to smooth the line.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::AntiAlias;

      // Create a new Pen object.
      Pen^ greenPen = gcnew Pen( Color::Green );

      // Set the width to 6.
      greenPen->Width = 6.0F;

      // Set the DashCap to round.
      greenPen->DashCap = System::Drawing::Drawing2D::DashCap::Round;

      // Create a custom dash pattern.
      array<Single>^temp0 = {4.0F,2.0F,1.0F,3.0F};
      greenPen->DashPattern = temp0;

      // Draw a line.
      e->Graphics->DrawLine( greenPen, 20.0F, 20.0F, 100.0F, 240.0F );

      // Change the SmoothingMode to none.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::None;

      // Draw another line.
      e->Graphics->DrawLine( greenPen, 100.0F, 240.0F, 160.0F, 20.0F );

      // Dispose of the custom pen.
      delete greenPen;
   }
   //</snippet3>

   // The following method demonstrates how to use the Pens class.
   // This example is designed to be used with Windows Forms.
   // Paste the code into a form and call the UsePensClass method
   // when handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet4>
private:
   void UsePensClass( PaintEventArgs^ e )
   {
      e->Graphics->DrawEllipse( Pens::SlateBlue, Rectangle(40,40,140,140) );
   }
   //</snippet4>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      UsePensClass( e );
      ShowPensAndSmoothingMode( e );
      ShowStartAndEndCaps( e );
      ShowLineJoin( e );
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
