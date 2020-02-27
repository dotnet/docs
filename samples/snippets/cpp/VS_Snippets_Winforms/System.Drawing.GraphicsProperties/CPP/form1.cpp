#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Drawing::Drawing2D;
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
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
   }


   // The following code example demonstrates how to construct and
   // use a region. 
   // This example is designed to be used with Windows Forms.  
   // Paste the code to a form and call the FillRegionExcludingPath
   // method when handling the form's Paint event, passing e as 
   // PaintEventArgs.
   //<snippet1>
private:
   void FillRegionExcludingPath( PaintEventArgs^ e )
   {
      // Create the region using a rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( Rectangle(20,20,100,100) );

      // Create the GraphicsPath.
      System::Drawing::Drawing2D::GraphicsPath^ path = gcnew System::Drawing::Drawing2D::GraphicsPath;

      // Add a circle to the graphics path.
      path->AddEllipse( 50, 50, 25, 25 );

      // Exclude the circle from the region.
      myRegion->Exclude( path );

      // Retrieve a Graphics object from the form.
      Graphics^ formGraphics = e->Graphics;

      // Fill the region in blue.
      formGraphics->FillRegion( Brushes::Blue, myRegion );

      // Dispose of the path and region objects.
      delete path;
      delete myRegion;
   }
   //</snippet1>

   // The following code example demonstrates how to use the 
   // PageScale and TranslateTransform members to change the
   // scale and origin when you draw a rectangle.
   // This example is designed to be used with Windows Forms.  
   // Paste the code intto a form and call the 
   // ChangePageScaleAndTranslateTransform method when 
   // handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet2>
private:
   void ChangePageScaleAndTranslateTransform( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rectangle1 = Rectangle(20,20,50,100);

      // Draw its outline.
      e->Graphics->DrawRectangle( Pens::SlateBlue, rectangle1 );

      // Change the page scale.  
      e->Graphics->PageScale = 2.0F;

      // Call TranslateTransform to change the origin of the
      //  Graphics object.
      e->Graphics->TranslateTransform( 10.0F, 10.0F );

      // Draw the rectangle again.
      e->Graphics->DrawRectangle( Pens::Tomato, rectangle1 );

      // Set the page scale and origin back to their original values.
      e->Graphics->PageScale = 1.0F;
      e->Graphics->ResetTransform();
      SolidBrush^ transparentBrush = gcnew SolidBrush( Color::FromArgb( 50, Color::Yellow ) );

      // Create a new rectangle with the coordinates you expect
      // after setting PageScale and calling TranslateTransform:
      // x = (10 + 20) * 2
      // y = (10 + 20) * 2
      // Width = 50 * 2
      // Length = 100 * 2
      Rectangle newRectangle = Rectangle(60,60,100,200);

      // Fill in the rectangle with a semi-transparent color.
      e->Graphics->FillRectangle( transparentBrush, newRectangle );
   }
   //</snippet2>

   // The following code example demonstrates the effect of changing
   // the PageUnit property.
   // This example is designed to be used with Windows Forms.  
   // Paste the code into a form and call the ChangePageUnit
   // method when handling the form's Paint event, passing e 
   // as PaintEventArgs.
   //<snippet3>
private:
   void ChangePageUnit( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rectangle1 = Rectangle(20,20,50,100);

      // Draw its outline.
      e->Graphics->DrawRectangle( Pens::SlateBlue, rectangle1 );

      // Change the page scale.  
      e->Graphics->PageUnit = GraphicsUnit::Point;

      // Draw the rectangle again.
      e->Graphics->DrawRectangle( Pens::Tomato, rectangle1 );
   }
   //</snippet3>

   // The following method demonstrates the use of the Clip
   // property. 
   // This example is designed to be used with Windows Forms.  
   // Paste the code int a form and call the SetAndFillClip method
   // when handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet4>
private:
   void SetAndFillClip( PaintEventArgs^ e )
   {
      // Set the Clip property to a new region.
      e->Graphics->Clip = gcnew System::Drawing::Region( Rectangle(10,10,100,200) );

      // Fill the region.
      e->Graphics->FillRegion( Brushes::LightSalmon, e->Graphics->Clip );

      // Demonstrate the clip region by drawing a string
      // at the outer edge of the region.
      e->Graphics->DrawString( "Outside of Clip", gcnew System::Drawing::Font( "Arial",12.0F,FontStyle::Regular ), Brushes::Black, 0.0F, 0.0F );
   }
   //</snippet4>

   // The following code example demonstrates the use of the
   // TextRenderingHint and TextContrast properties.
   // This example is designed to be used with Windows Forms.  
   // Paste the code into a form and call the 
   // ChangeTextRenderingHintAndTextContrast method when 
   // handling the form's Paint event, passing e as PaintEventArgs.
   //<snippet5>
private:
   void ChangeTextRenderingHintAndTextContrast( PaintEventArgs^ e )
   {
      // Retrieve the graphics object.
      Graphics^ formGraphics = e->Graphics;

      // Declare a new font.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( FontFamily::GenericSansSerif,20,FontStyle::Regular );

      // Set the TextRenderingHint property.
      formGraphics->TextRenderingHint = System::Drawing::Text::TextRenderingHint::SingleBitPerPixel;

      // Draw the string.
      formGraphics->DrawString( "Hello World", myFont, Brushes::Firebrick, 20.0F, 20.0F );

      // Change the TextRenderingHint property.
      formGraphics->TextRenderingHint = System::Drawing::Text::TextRenderingHint::AntiAliasGridFit;

      // Draw the string again.
      formGraphics->DrawString( "Hello World", myFont, Brushes::Firebrick, 20.0F, 60.0F );

      // Set the text contrast to a high-contrast setting.
      formGraphics->TextContrast = 0;

      // Draw the string.
      formGraphics->DrawString( "Hello World", myFont, Brushes::DodgerBlue, 20.0F, 100.0F );

      // Set the text contrast to a low-contrast setting.
      formGraphics->TextContrast = 12;

      // Draw the string again.
      formGraphics->DrawString( "Hello World", myFont, Brushes::DodgerBlue, 20.0F, 140.0F );

      // Dispose of the font object.
      delete myFont;
   }
   //</snippet5>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      ChangeTextRenderingHintAndTextContrast( e );

      //ChangePageScaleAndTranslateTransform(e);
      //ChangePageUnit(e);
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
