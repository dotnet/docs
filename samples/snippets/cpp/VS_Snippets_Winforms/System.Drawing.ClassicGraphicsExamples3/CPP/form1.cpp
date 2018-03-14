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
using namespace System::Drawing::Drawing2D;

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

   // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.Rectangle)
   // <snippet111>
public:
   void FillRectangleRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle.
      Rectangle rect = Rectangle(0,0,200,200);

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, rect );
   }
   // </snippet111>

   // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.RectangleF)
   // <snippet112>
public:
   void FillRectangleRectangleF( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle.
      RectangleF rect = RectangleF(0.0F,0.0F,200.0F,200.0F);

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, rect );
   }
   // </snippet112>

   // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet113>
public:
   void FillRectangleInt( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create location and size of rectangle.
      int x = 0;
      int y = 0;
      int width = 200;
      int height = 200;

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, x, y, width, height );
   }
   // </snippet113>

   // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single)
   // <snippet114>
public:
   void FillRectangleFloat( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create location and size of rectangle.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 200.0F;

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, x, y, width, height );
   }
   // </snippet114>

   // Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.Rectangle[])
   // <snippet115>
public:
   void FillRectanglesRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create array of rectangles.
      array<Rectangle>^ rects = {Rectangle(0,0,100,200),Rectangle(100,200,250,50),Rectangle(300,0,50,100)};

      // Fill rectangles to screen.
      e->Graphics->FillRectangles( blueBrush, rects );
   }
   // </snippet115>

   // Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.RectangleF[])
   // <snippet116>
public:
   void FillRectanglesRectangleF( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create array of rectangles.
      array<RectangleF>^ rects = {RectangleF(0.0F,0.0F,100.0F,200.0F),RectangleF(100.0F,200.0F,250.0F,50.0F),RectangleF(300.0F,0.0F,50.0F,100.0F)};

      // Fill rectangles to screen.
      e->Graphics->FillRectangles( blueBrush, rects );
   }
   // </snippet116>

   // Snippet for: M:System.Drawing.Graphics.FillRegion(System.Drawing.Brush,System.Drawing.Region)
   // <snippet117>
public:
   void FillRegionRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle for region.
      Rectangle fillRect = Rectangle(100,100,200,200);

      // Create region for fill.
      System::Drawing::Region^ fillRegion = gcnew System::Drawing::Region( fillRect );

      // Fill region to screen.
      e->Graphics->FillRegion( blueBrush, fillRegion );
   }
   // </snippet117>

   // Snippet for: M:System.Drawing.Graphics.FromHdc(System.IntPtr)
   // <snippet118>
public:
   void FromHdcHdc( PaintEventArgs^ e )
   {
      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Create new graphics object using handle to device context.
      Graphics^ newGraphics = Graphics::FromHdc( hdc );

      // Draw rectangle to screen.
      newGraphics->DrawRectangle( gcnew Pen( Color::Red,3.0f ), 0, 0, 200, 100 );

      // Release handle to device context and dispose of the      // Graphics object
      e->Graphics->ReleaseHdc( hdc );
      delete newGraphics;
   }
   // </snippet118>

   // Snippet for: M:System.Drawing.Graphics.FromHwnd(System.IntPtr)
   // <snippet119>
public:
   void FromHwndHwnd( PaintEventArgs^ /*e*/ )
   {
      // Get handle to form.
      IntPtr hwnd = this->Handle;

      // Create new graphics object using handle to window.
      Graphics^ newGraphics = Graphics::FromHwnd( hwnd );

      // Draw rectangle to screen.
      newGraphics->DrawRectangle( gcnew Pen( Color::Red,3.0f ), 0, 0, 200, 100 );

      // Dispose of new graphics.
      delete newGraphics;
   }
   // </snippet119>

   // Snippet for: M:System.Drawing.Graphics.FromImage(System.Drawing.Image)
   // <snippet120>
public:
   void FromImageImage( PaintEventArgs^ e )
   {
      // Create image.
      Image^ imageFile = Image::FromFile( "SampImag.jpg" );

      // Create graphics object for alteration.
      Graphics^ newGraphics = Graphics::FromImage( imageFile );

      // Alter image.
      newGraphics->FillRectangle( gcnew SolidBrush( Color::Black ), 100, 50, 100, 100 );

      // Draw image to screen.
      e->Graphics->DrawImage( imageFile, PointF(0.0F,0.0F) );

      // Dispose of graphics object.
      delete newGraphics;
   }
   // </snippet120>

   // Snippet for: M:System.Drawing.Graphics.GetHalftonePalette
   // <snippet121>
private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static IntPtr SelectPalette( IntPtr hdc, IntPtr htPalette, bool bForceBackground );

   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static int RealizePalette( IntPtr hdc );

public:
   void GetHalftonePaletteVoid( PaintEventArgs^ e )
   {
      // Create and draw image.
      Image^ imageFile = Image::FromFile( "SampImag.jpg" );
      e->Graphics->DrawImage( imageFile, Point(0,0) );

      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Get handle to halftone palette.
      IntPtr htPalette = Graphics::GetHalftonePalette();

      // Select and realize new palette.
      SelectPalette( hdc, htPalette, true );
      RealizePalette( hdc );

      // Create new graphics object.
      Graphics^ newGraphics = Graphics::FromHdc( hdc );

      // Draw image with new palette.
      newGraphics->DrawImage( imageFile, 300, 0 );

      // Release handle to device context.
      e->Graphics->ReleaseHdc( hdc );
   }
   // </snippet121>

   // Snippet for: M:System.Drawing.Graphics.GetHdc
   // <snippet122>
private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static bool Rectangle( IntPtr hdc, int ulCornerX, int ulCornerY, int lrCornerX, int lrCornerY );

public:
   void GetHdcForGDI1( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ redPen = gcnew Pen( Color::Red,1.0f );

      // Draw rectangle with GDI+.
      e->Graphics->DrawRectangle( redPen, 10, 10, 100, 50 );

      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Draw rectangle with GDI using default pen.
      Rectangle( hdc, 10, 70, 110, 120 );

      // Release handle to device context.
      e->Graphics->ReleaseHdc( hdc );
   }
   // </snippet122>

   // Snippet for: M:System.Drawing.Graphics.GetNearestColor(System.Drawing.Color)
   // <snippet123>
public:
   void GetNearestColorColor( PaintEventArgs^ e )
   {
      // Create solid brush with arbitrary color.
      Color arbColor = Color::FromArgb( 255, 165, 63, 136 );
      SolidBrush^ arbBrush = gcnew SolidBrush( arbColor );

      // Fill ellipse on screen.
      e->Graphics->FillEllipse( arbBrush, 0, 0, 200, 100 );

      // Get nearest color.
      Color realColor = e->Graphics->GetNearestColor( arbColor );
      SolidBrush^ realBrush = gcnew SolidBrush( realColor );

      // Fill ellipse on screen.
      e->Graphics->FillEllipse( realBrush, 0, 100, 200, 100 );
   }
   // </snippet123>

   // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Rectangle)
   // <snippet124>
public:
   void IntersectClipRectangle( PaintEventArgs^ e )
   {
      // Set clipping region.
      Rectangle clipRect = Rectangle(0,0,200,200);
      e->Graphics->SetClip( clipRect );

      // Update clipping region to intersection of
      // existing region with specified rectangle.
      Rectangle intersectRect = Rectangle(100,100,200,200);
      e->Graphics->IntersectClip( intersectRect );

      // Fill rectangle to demonstrate effective clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 500, 500 );

      // Reset clipping region to infinite.
      e->Graphics->ResetClip();

      // Draw clipRect and intersectRect to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Black ), clipRect );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), intersectRect );
   }
   // </snippet124>

   // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.RectangleF)
   // <snippet125>
public:
   void IntersectClipRectangleF1( PaintEventArgs^ e )
   {
      // Set clipping region.
      Rectangle clipRect = Rectangle(0,0,200,200);
      e->Graphics->SetClip( clipRect );

      // Update clipping region to intersection of
      // existing region with specified rectangle.
      RectangleF intersectRectF = RectangleF(100.0F,100.0F,200.0F,200.0F);
      e->Graphics->IntersectClip( intersectRectF );

      // Fill rectangle to demonstrate effective clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 500, 500 );

      // Reset clipping region to infinite.
      e->Graphics->ResetClip();

      // Draw clipRect and intersectRect to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Black ), clipRect );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), Rectangle::Round( intersectRectF ) );
   }
   // </snippet125>

   // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Region)
   // <snippet126>
public:
   void IntersectClipRegion( PaintEventArgs^ e )
   {
      // Set clipping region.
      Rectangle clipRect = Rectangle(0,0,200,200);
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( clipRect );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Update clipping region to intersection of
      // existing region with specified rectangle.
      Rectangle intersectRect = Rectangle(100,100,200,200);
      System::Drawing::Region^ intersectRegion = gcnew System::Drawing::Region( intersectRect );
      e->Graphics->IntersectClip( intersectRegion );

      // Fill rectangle to demonstrate effective clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 500, 500 );

      // Reset clipping region to infinite.
      e->Graphics->ResetClip();

      // Draw clipRect and intersectRect to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Black ), clipRect );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), intersectRect );
   }
   // </snippet126>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Point)
   // <snippet127>
public:
   void IsVisiblePoint( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of points.
      int x1 = 100;
      int y1 = 100;
      int x2 = 200;
      int y2 = 200;
      Point point1 = Point(x1,y1);
      Point point2 = Point(x2,y2);

      // If point is visible, fill ellipse that represents it.
      if ( e->Graphics->IsVisible( point1 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Red ), x1, y1, 10, 10 );
      }

      if ( e->Graphics->IsVisible( point2 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Blue ), x2, y2, 10, 10 );
      }
   }
   // </snippet127>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.PointF)
   // <snippet128>
public:
   void IsVisiblePointF( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of points.
      float x1 = 100.0F;
      float y1 = 100.0F;
      float x2 = 200.0F;
      float y2 = 200.0F;
      PointF point1 = PointF(x1,y1);
      PointF point2 = PointF(x2,y2);

      // If point is visible, fill ellipse that represents it.
      if ( e->Graphics->IsVisible( point1 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Red ), x1, y1, 10.0F, 10.0F );
      }

      if ( e->Graphics->IsVisible( point2 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Blue ), x2, y2, 10.0F, 10.0F );
      }
   }
   // </snippet128>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Rectangle)
   // <snippet129>
public:
   void IsVisibleRectangle( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      Rectangle rect1 = Rectangle(100,100,20,20);
      Rectangle rect2 = Rectangle(200,200,20,20);

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( rect1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), rect1 );
      }

      if ( e->Graphics->IsVisible( rect2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), rect2 );
      }
   }
   // </snippet129>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.RectangleF)
   // <snippet130>
public:
   void IsVisibleRectangleF( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      RectangleF rect1 = RectangleF(100.0F,100.0F,20.0F,20.0F);
      RectangleF rect2 = RectangleF(200.0F,200.0F,20.0F,20.0F);

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( rect1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), rect1 );
      }

      if ( e->Graphics->IsVisible( rect2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), rect2 );
      }
   }
   // </snippet130>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32)
   // <snippet131>
public:
   void IsVisibleInt( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of points.
      int x1 = 100;
      int y1 = 100;
      int x2 = 200;
      int y2 = 200;

      // If point is visible, fill ellipse that represents it.
      if ( e->Graphics->IsVisible( x1, y1 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Red ), x1, y1, 10, 10 );
      }

      if ( e->Graphics->IsVisible( x2, y2 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Blue ), x2, y2, 10, 10 );
      }
   }
   // </snippet131>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet132>
public:
   void IsVisible4Int( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      int x1 = 100;
      int y1 = 100;
      int width1 = 20;
      int height1 = 20;
      int x2 = 200;
      int y2 = 200;
      int width2 = 20;
      int height2 = 20;

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( x1, y1, width1, height1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), x1, y1, width1, height1 );
      }

      if ( e->Graphics->IsVisible( x2, y2, width2, height2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), x2, y2, width2, height2 );
      }
   }
   // </snippet132>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single)
   // <snippet133>
public:
   void IsVisibleFloat( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of points.
      float x1 = 100.0F;
      float y1 = 100.0F;
      float x2 = 200.0F;
      float y2 = 200.0F;

      // If point is visible, fill ellipse that represents it.
      if ( e->Graphics->IsVisible( x1, y1 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Red ), x1, y1, 10.0F, 10.0F );
      }

      if ( e->Graphics->IsVisible( x2, y2 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Blue ), x2, y2, 10.0F, 10.0F );
      }
   }
   // </snippet133>

   // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single,System.Single,System.Single)
   // <snippet134>
public:
   void IsVisible4Float( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      float x1 = 100.0F;
      float y1 = 100.0F;
      float width1 = 20.0F;
      float height1 = 20.0F;
      float x2 = 200.0F;
      float y2 = 200.0F;
      float width2 = 20.0F;
      float height2 = 20.0F;

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( x1, y1, width1, height1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), x1, y1, width1, height1 );
      }

      if ( e->Graphics->IsVisible( x2, y2, width2, height2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), x2, y2, width2, height2 );
      }
   }
   // </snippet134>

   // Snippet for: M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)
   // <snippet135>
public:
   void MeasureCharacterRangesRegions( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "First and Second ranges";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Times New Roman",16.0F );

      // Set character ranges to "First" and "Second".
      array<CharacterRange>^ characterRanges = {CharacterRange(0,5),CharacterRange(10,6)};

      // Create rectangle for layout.
      float x = 50.0F;
      float y = 50.0F;
      float width = 35.0F;
      float height = 200.0F;
      RectangleF layoutRect = RectangleF(x,y,width,height);

      // Set string format.
      StringFormat^ stringFormat = gcnew StringFormat;
      stringFormat->FormatFlags = StringFormatFlags::DirectionVertical;
      stringFormat->SetMeasurableCharacterRanges( characterRanges );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, x, y, stringFormat );

      // Measure two ranges in string.
      array<System::Drawing::Region^>^stringRegions = e->Graphics->MeasureCharacterRanges( measureString, 
	stringFont, layoutRect, stringFormat );

      // Draw rectangle for first measured range.
      RectangleF measureRect1 = stringRegions[ 0 ]->GetBounds( e->Graphics );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), Rectangle::Round( measureRect1 ) );

      // Draw rectangle for second measured range.
      RectangleF measureRect2 = stringRegions[ 1 ]->GetBounds( e->Graphics );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,1.0f ), Rectangle::Round( measureRect2 ) );
   }
   // </snippet135>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font)
   // <snippet136>
public:
   void MeasureStringMin( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0) );
   }
   // </snippet136>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.PointF,System.Drawing.StringFormat)
   // <snippet137>
public:
   void MeasureStringPointFFormat( PaintEventArgs^ e )
   {

      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set point for upper-left corner of string.
      float x = 50.0F;
      float y = 50.0F;
      PointF ulCorner = PointF(x,y);

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, ulCorner, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), x, y, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, ulCorner, newStringFormat );
   }
   // </snippet137>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF)
   // <snippet138>
public:
   void MeasureStringSizeF( PaintEventArgs^ e )
   {

      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum layout size.
      SizeF layoutSize = SizeF(200.0F,50.0F);

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, layoutSize );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0) );
   }
   // </snippet138>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat)
   // <snippet139>
public:
   void MeasureStringSizeFFormat( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum layout size.
      SizeF layoutSize = SizeF(100.0F,200.0F);

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, layoutSize, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0), newStringFormat );
   }
   // </snippet139>
   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat,System.Int32@,System.Int32@)

   // <snippet140>
public:
   void MeasureStringSizeFFormatInts( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum layout size.
      SizeF layoutSize = SizeF(100.0F,200.0F);

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      int charactersFitted;
      int linesFilled;
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, layoutSize, newStringFormat, charactersFitted, linesFilled );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0), newStringFormat );

      // Draw output parameters to screen.
      String^ outString = String::Format( "chars {0}, lines {1}", charactersFitted, linesFilled );
      e->Graphics->DrawString( outString, stringFont, Brushes::Black, PointF(100,0) );
   }
   // </snippet140>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32)
   // <snippet141>
public:
   void MeasureStringWidth( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum width of string.
      int stringWidth = 200;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, stringWidth );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0) );
   }
   // </snippet141>

   // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32,System.Drawing.StringFormat)
   // <snippet142>
public:
   void MeasureStringWidthFormat( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum width of string.
      int stringWidth = 100;

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, stringWidth, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0), newStringFormat );
   }
   // </snippet142>

   // Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
   // <snippet143>
public:
   void MultiplyTransformMatrix( PaintEventArgs^ e )
   {
      // Create transform matrix.
      Matrix^ transformMatrix = gcnew Matrix;

      // Translate matrix, prepending translation vector.
      transformMatrix->Translate( 200.0F, 100.0F );

      // Rotate transformation matrix of graphics object,
      // prepending rotation matrix.
      e->Graphics->RotateTransform( 30.0F );

      // Multiply (prepend to) transformation matrix of
      // graphics object to translate graphics transformation.
      e->Graphics->MultiplyTransform( transformMatrix );

      // Draw rotated, translated ellipse.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), -80, -40, 160, 80 );
   }
   // </snippet143>

   // Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet144>
public:
   void MultiplyTransformMatrixOrder( PaintEventArgs^ e )
   {
      // Create transform matrix.
      Matrix^ transformMatrix = gcnew Matrix;

      // Translate matrix, prepending translation vector.
      transformMatrix->Translate( 200.0F, 100.0F );

      // Rotate transformation matrix of graphics object,
      // prepending rotation matrix.
      e->Graphics->RotateTransform( 30.0F );

      // Multiply (append to) transformation matrix of
      // graphics object to translate graphics transformation.
      e->Graphics->MultiplyTransform( transformMatrix, MatrixOrder::Append );

      // Draw rotated, translated ellipse.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), -80, -40, 160, 80 );
   }
   // </snippet144>

   // Snippet for: M:System.Drawing.Graphics.ReleaseHdc(System.IntPtr)
   // <snippet145>
private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static bool Rectangle2( IntPtr hdc, int ulCornerX, int ulCornerY, int lrCornerX, int lrCornerY );

public:
   void GetHdcForGDI2( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ redPen = gcnew Pen( Color::Red,1.0f );

      // Draw rectangle with GDI+.
      e->Graphics->DrawRectangle( redPen, 10, 10, 100, 50 );

      // Get handle to device context.
      IntPtr hdc = e->Graphics->GetHdc();

      // Draw rectangle with GDI using default pen.
      Rectangle2( hdc, 10, 70, 110, 120 );

      // Release handle to device context.
      e->Graphics->ReleaseHdc( hdc );
   }
   // </snippet145>
   // Snippet for: M:System.Drawing.Graphics.ResetClip

   // <snippet146>
public:
   void IntersectClipRectangleF2( PaintEventArgs^ e )
   {
      // Set clipping region.
      Rectangle clipRect = Rectangle(0,0,200,200);
      e->Graphics->SetClip( clipRect );

      // Update clipping region to intersection of
      // existing region with specified rectangle.
      RectangleF intersectRectF = RectangleF(100.0F,100.0F,200.0F,200.0F);
      e->Graphics->IntersectClip( intersectRectF );

      // Fill rectangle to demonstrate effective clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 500, 500 );

      // Reset clipping region to infinite.
      e->Graphics->ResetClip();

      // Draw clipRect and intersectRect to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Black ), clipRect );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), Rectangle::Round( intersectRectF ) );
   }
   // </snippet146>

   // Snippet for: M:System.Drawing.Graphics.ResetTransform
   // <snippet147>
public:
   void SaveRestore1( PaintEventArgs^ e )
   {
      // Translate transformation matrix.
      e->Graphics->TranslateTransform( 100, 0 );

      // Save translated graphics state.
      GraphicsState^ transState = e->Graphics->Save();

      // Reset transformation matrix to identity and fill rectangle.
      e->Graphics->ResetTransform();
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 100, 100 );

      // Restore graphics state to translated state and fill second
      // rectangle.
      e->Graphics->Restore( transState );
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 100, 100 );
   }
   // </snippet147>

   // Snippet for: M:System.Drawing.Graphics.Restore(System.Drawing.Drawing2D.GraphicsState)
   // <snippet148>
public:
   void SaveRestore2( PaintEventArgs^ e )
   {
      // Translate transformation matrix.
      e->Graphics->TranslateTransform( 100, 0 );

      // Save translated graphics state.
      GraphicsState^ transState = e->Graphics->Save();

      // Reset transformation matrix to identity and fill rectangle.
      e->Graphics->ResetTransform();
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 100, 100 );

      // Restore graphics state to translated state and fill second
      // rectangle.
      e->Graphics->Restore( transState );
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 100, 100 );
   }
   // </snippet148>

   // Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single)
   // <snippet149>
public:
   void RotateTransformAngle( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to translate.
      e->Graphics->TranslateTransform( 100.0F, 0.0F );

      // Then to rotate, prepending rotation matrix.
      e->Graphics->RotateTransform( 30.0F );

      // Draw rotated, translated ellipse to screen.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), 0, 0, 200, 80 );
   }
   // </snippet149>

   // Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet150>
public:
   void RotateTransformAngleMatrixOrder( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to translate.
      e->Graphics->TranslateTransform( 100.0F, 0.0F );

      // Then to rotate, appending rotation matrix.
      e->Graphics->RotateTransform( 30.0F, MatrixOrder::Append );

      // Draw translated, rotated ellipse to screen.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), 0, 0, 200, 80 );
   }
   // </snippet150>

   // Snippet for: M:System.Drawing.Graphics.Save
   // <snippet151>
public:
   void SaveRestore3( PaintEventArgs^ e )
   {
      // Translate transformation matrix.
      e->Graphics->TranslateTransform( 100, 0 );

      // Save translated graphics state.
      GraphicsState^ transState = e->Graphics->Save();

      // Reset transformation matrix to identity and fill rectangle.
      e->Graphics->ResetTransform();
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 100, 100 );
      
      // Restore graphics state to translated state and fill second
      // rectangle.
      e->Graphics->Restore( transState );
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 100, 100 );
   }
   // </snippet151>

   // Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single)
   // <snippet152>
public:
   void ScaleTransformFloat( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to rotate.
      e->Graphics->RotateTransform( 30.0F );

      // Then to scale, prepending to world transform.
      e->Graphics->ScaleTransform( 3.0F, 1.0F );

      // Draw scaled, rotated rectangle to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,3.0f ), 50, 0, 100, 40 );
   }
   // </snippet152>

   // Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet153>
public:
   void ScaleTransformFloatMatrixOrder( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to rotate.
      e->Graphics->RotateTransform( 30.0F );

      // Then to scale, appending to world transform.
      e->Graphics->ScaleTransform( 3.0F, 1.0F, MatrixOrder::Append );

      // Draw rotated, scaled rectangle to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,3.0f ), 50, 0, 100, 40 );
   }
   // </snippet153>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath)
   // <snippet154>
public:
   void SetClipPath( PaintEventArgs^ e )
   {
      // Create graphics path.
      GraphicsPath^ clipPath = gcnew GraphicsPath;
      clipPath->AddEllipse( 0, 0, 200, 100 );

      // Set clipping region to path.
      e->Graphics->SetClip( clipPath );

      // Fill rectangle to demonstrate clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet154>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath,System.Drawing.Drawing2D.CombineMode)
   // <snippet155>
public:
   void SetClipPathCombine( PaintEventArgs^ e )
   {
      // Create graphics path.
      GraphicsPath^ clipPath = gcnew GraphicsPath;
      clipPath->AddEllipse( 0, 0, 200, 100 );

      // Set clipping region to path.
      e->Graphics->SetClip( clipPath, CombineMode::Replace );

      // Fill rectangle to demonstrate clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet155>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics)
   // <snippet156>
public:
   void SetClipGraphics( PaintEventArgs^ e )
   {
      // Create temporary graphics object and set its clipping region.
      Graphics^ newGraphics = this->CreateGraphics();
      newGraphics->SetClip( Rectangle(0,0,100,100) );

      // Update clipping region of graphics to clipping region of new
      // graphics.
      e->Graphics->SetClip( newGraphics );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );

      // Release new graphics.
      delete newGraphics;
   }
   // </snippet156>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics,System.Drawing.Drawing2D.CombineMode)
   // <snippet157>
public:
   void SetClipGraphicsCombine( PaintEventArgs^ e )
   {
      // Create temporary graphics object and set its clipping region.
      Graphics^ newGraphics = this->CreateGraphics();
      newGraphics->SetClip( Rectangle(0,0,100,100) );

      // Update clipping region of graphics to clipping region of new
      // graphics.
      e->Graphics->SetClip( newGraphics, CombineMode::Replace );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );

      // Release new graphics.
      delete newGraphics;
   }
   // </snippet157>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle)
   // <snippet158>
public:
   void SetClipRectangle( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      Rectangle clipRect = Rectangle(0,0,100,100);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet158>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle,System.Drawing.Drawing2D.CombineMode)
   // <snippet159>
public:
   void SetClipRectangleCombine( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      Rectangle clipRect = Rectangle(0,0,100,100);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect, CombineMode::Replace );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet159>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF)
   // <snippet160>
public:
   void SetClipRectangleF( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      RectangleF clipRect = RectangleF(0.0F,0.0F,100.0F,100.0F);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet160>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF,System.Drawing.Drawing2D.CombineMode)
   // <snippet161>
public:
   void SetClipRectangleFCombine( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      RectangleF clipRect = RectangleF(0.0F,0.0F,100.0F,100.0F);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect, CombineMode::Replace );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet161>

   // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Region,System.Drawing.Drawing2D.CombineMode)
   // <snippet162>
public:
   void SetClipRegionCombine( PaintEventArgs^ e )
   {
      // Create region for clipping.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(0,0,100,100) );

      // Set clipping region of graphics to region.
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet162>

   // Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Point[])
   // <snippet163>
public:
   void TransformPointsPoint( PaintEventArgs^ e )
   {
      // Create array of two points.
      array<Point>^ points = {Point(0,0),Point(100,50)};

      // Draw line connecting two untransformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Blue,3.0f ), points[ 0 ], points[ 1 ] );

      // Set world transformation of Graphics object to translate.
      e->Graphics->TranslateTransform( 40, 30 );

      // Transform points in array from world to page coordinates.
      e->Graphics->TransformPoints( CoordinateSpace::Page, CoordinateSpace::World, points );

      // Reset world transformation.
      e->Graphics->ResetTransform();

      // Draw line that connects transformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Red,3.0f ), points[ 0 ], points[ 1 ] );
   }
   // </snippet163>

   // Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.PointF[])
   // <snippet164>
public:
   void TransformPointsPointF( PaintEventArgs^ e )
   {
      // Create array of two points.
      array<PointF>^ points = {PointF(0.0F,0.0F),PointF(100.0F,50.0F)};

      // Draw line connecting two untransformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Blue,3.0f ), points[ 0 ], points[ 1 ] );

      // Set world transformation of Graphics object to translate.
      e->Graphics->TranslateTransform( 40.0F, 30.0F );

      // Transform points in array from world to page coordinates.
      e->Graphics->TransformPoints( CoordinateSpace::Page, CoordinateSpace::World, points );

      // Reset world transformation.
      e->Graphics->ResetTransform();

      // Draw line that connects transformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Red,3.0f ), points[ 0 ], points[ 1 ] );
   }
   // </snippet164>
   // Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Int32,System.Int32)

   // <snippet165>
public:
   void TranslateClipInt( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      Rectangle clipRect = Rectangle(0,0,100,100);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Translate clipping region.
      int dx = 50;
      int dy = 50;
      e->Graphics->TranslateClip( dx, dy );

      // Fill rectangle to demonstrate translated clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet165>
   // Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Single,System.Single)

   // <snippet166>
public:
   void TranslateClipFloat( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      RectangleF clipRect = RectangleF(0.0F,0.0F,100.0F,100.0F);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Translate clipping region.
      float dx = 50.0F;
      float dy = 50.0F;
      e->Graphics->TranslateClip( dx, dy );

      // Fill rectangle to demonstrate translated clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }
   // </snippet166>
   // Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single)

   // <snippet167>
public:
   void TranslateTransformAngle( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to rotate.
      e->Graphics->RotateTransform( 30.0F );

      // Then to translate, prepending to world transform.
      e->Graphics->TranslateTransform( 100.0F, 0.0F );

      // Draw translated, rotated ellipse to screen.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), 0, 0, 200, 80 );
   }
   // </snippet167>

   // Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
   // <snippet168>
public:
   void TranslateTransformAngleMatrixOrder( PaintEventArgs^ e )
   {
      // Set world transform of graphics object to rotate.
      e->Graphics->RotateTransform( 30.0F );

      // Then to translate, appending to world transform.
      e->Graphics->TranslateTransform( 100.0F, 0.0F, MatrixOrder::Append );

      // Draw rotated, translated ellipse to screen.
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue,3.0f ), 0, 0, 200, 80 );
   }
   // </snippet168>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
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
