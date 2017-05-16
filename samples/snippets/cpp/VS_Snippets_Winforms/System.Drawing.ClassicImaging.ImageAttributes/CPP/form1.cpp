#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
using namespace System::Drawing::Drawing2D;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

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

public:

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetBrushRemapTable(System.Drawing.Imaging.ColorMap[])
   // <snippet1>
   void SetBrushRemapTableExample( PaintEventArgs^ /*e*/ )
   {
      // Create a color map.
      array<ColorMap^>^myColorMap = gcnew array<ColorMap^>(1);
      myColorMap[ 0 ] = gcnew ColorMap;
      myColorMap[ 0 ]->OldColor = Color::Red;
      myColorMap[ 0 ]->NewColor = Color::Green;

      // Create an ImageAttributes object, passing it to the myColorMap
      // array.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetBrushRemapTable( myColorMap );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorKey(System.Drawing.Color,System.Drawing.Color,System.Drawing.Imaging.ColorAdjustType)
   // <snippet2>
private:
   void SetColorKeyExample( PaintEventArgs^ e )
   {
      // Open an Image file and draw it to the screen.
      Image^ myImage = Image::FromFile( "Circle.bmp" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Create an ImageAttributes object and set the color key.
      Color lowerColor = Color::FromArgb( 245, 0, 0 );
      Color upperColor = Color::FromArgb( 255, 0, 0 );
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetColorKey( lowerColor, upperColor, ColorAdjustType::Default );

      // Draw the image with the color key set.
      Rectangle rect = Rectangle(150,20,100,100);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 100, 100, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorMatrix(System.Drawing.Imaging.ColorMatrix)
   // <snippet3>
private:
   void SetColorMatrixExample( PaintEventArgs^ e )
   {
      // Create a rectangle image with all colors set to 128 (medium
      // gray).
      Bitmap^ myBitmap = gcnew Bitmap( 50,50,PixelFormat::Format32bppArgb );
      Graphics^ g = Graphics::FromImage( myBitmap );
      g->FillRectangle( gcnew SolidBrush( Color::FromArgb( 255, 128, 128, 128 ) ), Rectangle(0,0,50,50) );
      myBitmap->Save( "Rectangle1.jpg" );

      // Open an Image file and draw it to the screen.
      Image^ myImage = Image::FromFile( "Rectangle1.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Initialize the color matrix.
      ColorMatrix^ myColorMatrix = gcnew ColorMatrix;

      // Red
      myColorMatrix->Matrix00 = 1.75f;

      // Green
      myColorMatrix->Matrix11 = 1.00f;

      // Blue
      myColorMatrix->Matrix22 = 1.00f;

      // alpha
      myColorMatrix->Matrix33 = 1.00f;

      // w
      myColorMatrix->Matrix44 = 1.00f;

      // Create an ImageAttributes object and set the color matrix.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetColorMatrix( myColorMatrix );

      // Draw the image using the color matrix.
      Rectangle rect = Rectangle(100,20,200,200);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 200, 200, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetGamma(System.Single)
   // <snippet4>
private:
   void SetGammaExample( PaintEventArgs^ e )
   {
      // Create an Image object from the file Camera.jpg, and draw it to
      // the screen.
      Image^ myImage = Image::FromFile( "Camera.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Create an ImageAttributes object and set the gamma to 2.2.
	  System::Drawing::Imaging::ImageAttributes^ imageAttr = 
		  gcnew System::Drawing::Imaging::ImageAttributes;
      imageAttr->SetGamma( 2.2f );

      // Draw the image with gamma set to 2.2.
      Rectangle rect = Rectangle(250,20,200,200);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 200, 200, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetNoOp
   // <snippet5>
private:
   void SetNoOpExample( PaintEventArgs^ e )
   {
      // Create an Image object from the file Camera.jpg.
      Image^ myImage = Image::FromFile( "Camera.jpg" );

      // Create an ImageAttributes object, and set the gamma to 0.25.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 0.25f );

      // Draw the image with gamma set to 0.25.
      Rectangle rect1 = Rectangle(20,20,200,200);
      e->Graphics->DrawImage( myImage, rect1, 0, 0, 200, 200, GraphicsUnit::Pixel, imageAttr );

      // Call the ImageAttributes NoOp method.
      imageAttr->SetNoOp();

      // Draw the image after NoOp is set, so the default gamma value
      // of 1.0 will be used.
      Rectangle rect2 = Rectangle(250,20,200,200);
      e->Graphics->DrawImage( myImage, rect2, 0, 0, 200, 200, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetRemapTable(System.Drawing.Imaging.ColorMap[])
   // <snippet6>
private:
   void SetRemapTableExample( PaintEventArgs^ e )
   {
      // Create a filled, red image, and save it to Circle2.jpg.
      Bitmap^ myBitmap = gcnew Bitmap( 50,50 );
      Graphics^ g = Graphics::FromImage( myBitmap );
      g->Clear( Color::White );
      g->FillEllipse( gcnew SolidBrush( Color::Red ), Rectangle(0,0,50,50) );
      myBitmap->Save( "Circle2.jpg" );

      // Create an Image object from the Circle2.jpg file, and draw it to
      // the screen.
      Image^ myImage = Image::FromFile( "Circle2.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Create a color map.
      array<ColorMap^>^myColorMap = gcnew array<ColorMap^>(1);
      myColorMap[ 0 ] = gcnew ColorMap;
      myColorMap[ 0 ]->OldColor = Color::Red;
      myColorMap[ 0 ]->NewColor = Color::Green;

      // Create an ImageAttributes object, and then pass the
      // myColorMap object to the SetRemapTable method.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetRemapTable( myColorMap );

      // Draw the image with the remap table set.
      Rectangle rect = Rectangle(150,20,50,50);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 50, 50, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetThreshold(System.Single)
   // <snippet7>
   void SetThresholdExample( PaintEventArgs^ e )
   {
      // Open an Image file, and draw it to the screen.
      Image^ myImage = Image::FromFile( "Camera.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Create an ImageAttributes object, and set its color threshold.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetThreshold( 0.7f );

      // Draw the image with the colors bifurcated.
      Rectangle rect = Rectangle(300,20,200,200);
      e->Graphics->DrawImage( myImage, rect, 0, 0, 200, 200, GraphicsUnit::Pixel, imageAttr );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode)
   // <snippet8>
   void SetWrapModeExample( PaintEventArgs^ e )
   {
      // Create a filled, red circle, and save it to Circle3.jpg.
      Bitmap^ myBitmap = gcnew Bitmap( 50,50 );
      Graphics^ g = Graphics::FromImage( myBitmap );
      g->Clear( Color::White );
      g->FillEllipse( gcnew SolidBrush( Color::Red ), Rectangle(0,0,25,25) );
      myBitmap->Save( "Circle3.jpg" );

      // Create an Image object from the Circle3.jpg file, and draw it
      // to the screen.
      Image^ myImage = Image::FromFile( "Circle3.jpg" );
      e->Graphics->DrawImage( myImage, 20, 20 );

      // Set the wrap mode.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetWrapMode( WrapMode::Tile );

      // Create a TextureBrush.
      Rectangle brushRect = Rectangle(0,0,25,25);
      TextureBrush^ myTBrush = gcnew TextureBrush( myImage,brushRect,imageAttr );

      // Draw to the screen a rectangle filled with red circles.
      e->Graphics->FillRectangle( myTBrush, 100, 20, 200, 200 );
   }
   // </snippet8>

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
};

int main()
{
   Application::Run( gcnew Form1 );
}

/*
This example of the
  Decimal::ToInt64( Decimal ) and
  Decimal::ToUInt64( Decimal )
methods generates the following output. It
displays several converted Decimal values.

         Decimal argument     __int64/exception      unsigned __int64
         ----------------     -----------------      ----------------
                      123                   123                   123
                  123.000                   123                   123
                  123.999                   123                   123
 18446744073709551615.999     OverflowException  18446744073709551615
     18446744073709551616     OverflowException     OverflowException
  9223372036854775807.999   9223372036854775807   9223372036854775807
      9223372036854775808     OverflowException   9223372036854775808
                   -0.999                     0                     0
                       -1                    -1     OverflowException
 -9223372036854775808.999  -9223372036854775808     OverflowException
     -9223372036854775809     OverflowException     OverflowException
*/
