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
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }

   // Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single)
   // <snippet1>
public:
   void ConstructAdjArrowCap1( PaintEventArgs^ e )
   {
      AdjustableArrowCap^ myArrow = gcnew AdjustableArrowCap( 6,6 );
      Pen^ capPen = gcnew Pen( Color::Black );
      capPen->CustomStartCap = myArrow;
      capPen->CustomEndCap = myArrow;
      e->Graphics->DrawLine( capPen, 50, 50, 200, 50 );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single,System.Boolean)
   // <snippet2>
public:
   void ConstructAdjArrowCap2( PaintEventArgs^ e )
   {
      AdjustableArrowCap^ myArrow = gcnew AdjustableArrowCap( 6,6,false );
      Pen^ capPen = gcnew Pen( Color::Black );
      capPen->CustomStartCap = myArrow;
      capPen->CustomEndCap = myArrow;
      e->Graphics->DrawLine( capPen, 50, 50, 200, 50 );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Drawing2D.Blend.#ctor
   // <snippet3>
public:
   void BlendConstExample( PaintEventArgs^ e )
   {
      //Draw ellipse using Blend.
      Point startPoint2 = Point(20,110);
      Point endPoint2 = Point(140,110);
      array<Single>^myFactors = {.2f,.4f,.8f,.8f,.4f,.2f};
      array<Single>^myPositions = {0.0f,.2f,.4f,.6f,.8f,1.0f};
      Blend^ myBlend = gcnew Blend;
      myBlend->Factors = myFactors;
      myBlend->Positions = myPositions;
      LinearGradientBrush^ lgBrush2 =
            gcnew LinearGradientBrush( startPoint2,endPoint2,Color::Blue,Color::Red );
      lgBrush2->Blend = myBlend;
      Rectangle ellipseRect2 = Rectangle(20,110,120,80);
      e->Graphics->FillEllipse( lgBrush2, ellipseRect2 );

      // End example.
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Drawing2D.ColorBlend.#ctor
   // <snippet4>
protected:
   virtual void OnPaint( PaintEventArgs^ e ) override
   {
      //Draw ellipse using ColorBlend.
      Point startPoint2 = Point(20,110);
      Point endPoint2 = Point(140,110);
      array<Color>^ myColors =
            {Color::Green,Color::Yellow,Color::Yellow,Color::Blue,Color::Red,Color::Red};
      array<Single>^myPositions = {0.0f,.20f,.40f,.60f,.80f,1.0f};
      ColorBlend^ myBlend = gcnew ColorBlend;
      myBlend->Colors = myColors;
      myBlend->Positions = myPositions;
      LinearGradientBrush^ lgBrush2 =
            gcnew LinearGradientBrush( startPoint2,endPoint2,Color::Green,Color::Red );
      lgBrush2->InterpolationColors = myBlend;
      Rectangle ellipseRect2 = Rectangle(20,110,120,80);
      e->Graphics->FillEllipse( lgBrush2, ellipseRect2 );
   }
   // </snippet4>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
