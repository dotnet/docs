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
using namespace System::Drawing::Imaging;
using namespace System::Drawing::Drawing2D;
using namespace System::Drawing::Text;
using namespace System::Security::Permissions;

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

   // Snippet for: M:System.Drawing.Graphics.AddMetafileComment(System.Byte[])
   // <snippet1>
private:
   [SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::UnmanagedCode)]            
   void AddMetafileCommentBytes( PaintEventArgs^ e )
   {
      // Create temporary Graphics object for metafile
      //  creation and get handle to its device context.
      Graphics^ newGraphics = this->CreateGraphics();
      IntPtr hdc = newGraphics->GetHdc();

      // Create metafile object to record.
      Metafile^ metaFile1 = gcnew Metafile( "SampMeta.emf",hdc );

      // Create graphics object to record metaFile.
      Graphics^ metaGraphics = Graphics::FromImage( metaFile1 );

      // Draw rectangle in metaFile.
      metaGraphics->DrawRectangle( gcnew Pen( Color::Black,5.0f ), 0, 0, 100, 100 );

      // Create comment and add to metaFile.
      array<Byte>^metaComment = {(Byte)'T',(Byte)'e',(Byte)'s',(Byte)'t'};
      metaGraphics->AddMetafileComment( metaComment );

      // Dispose of graphics object.
      delete metaGraphics;

      // Dispose of metafile.
      delete metaFile1;

      // Release handle to temporary device context.
      newGraphics->ReleaseHdc( hdc );

      // Dispose of scratch graphics object.
      delete newGraphics;

      // Create existing metafile object to draw.
      Metafile^ metaFile2 = gcnew Metafile( "SampMeta.emf" );

      // Draw metaFile to screen.
      e->Graphics->DrawImage( metaFile2, Point(0,0) );

      // Dispose of metafile.
      delete metaFile2;
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Graphics.BeginContainer
   // <snippet2>
private:
   void BeginContainerVoid( PaintEventArgs^ e )
   {
      // Begin graphics container.
      GraphicsContainer^ containerState = e->Graphics->BeginContainer();

      // Translate world transformation.
      e->Graphics->TranslateTransform( 100.0F, 100.0F );

      // Fill translated rectangle in container with red.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 200, 200 );

      // End graphics container.
      e->Graphics->EndContainer( containerState );

      // Fill untransformed rectangle with green.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Green ), 0, 0, 200, 200 );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
   // <snippet3>
private:
   void BeginContainerRectangle( PaintEventArgs^ e )
   {
      // Define transformation for container.
      Rectangle srcRect = Rectangle(0,0,200,200);
      Rectangle destRect = Rectangle(100,100,150,150);

      // Begin graphics container.
      GraphicsContainer^ containerState = e->Graphics->BeginContainer( destRect, srcRect, GraphicsUnit::Pixel );

      // Fill red rectangle in container.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 200, 200 );

      // End graphics container.
      e->Graphics->EndContainer( containerState );

      // Fill untransformed rectangle with green.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Green ), 0, 0, 200, 200 );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.RectangleF,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
   // <snippet4>
private:
   void BeginContainerRectangleF( PaintEventArgs^ e )
   {
      // Define transformation for container.
      RectangleF srcRect = RectangleF(0.0F,0.0F,200.0F,200.0F);
      RectangleF destRect = RectangleF(100.0F,100.0F,150.0F,150.0F);

      // Begin graphics container.
      GraphicsContainer^ containerState = e->Graphics->BeginContainer( destRect, srcRect, GraphicsUnit::Pixel );

      // Fill red rectangle in container.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0.0F, 0.0F, 200.0F, 200.0F );

      // End graphics container.
      e->Graphics->EndContainer( containerState );

      // Fill untransformed rectangle with green.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Green ), 0.0F, 0.0F, 200.0F, 200.0F );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Graphics.Clear(System.Drawing.Color)
   // <snippet5>
private:
   void ClearColor( PaintEventArgs^ e )
   {
      // Clear screen with teal background.
      e->Graphics->Clear( Color::Teal );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Graphics.Dispose
   // <snippet6>
private:
   void FromImageImage1( PaintEventArgs^ e )
   {
      // Create image.
      Image^ imageFile = Image::FromFile( "SampImag.jpg" );

      // Create graphics object for alteration.
      Graphics^ newGraphics = Graphics::FromImage( imageFile );

      // Alter image.
      newGraphics->FillRectangle( gcnew SolidBrush( Color::Black ), 100, 50, 100, 100 );

      // Draw image to screen.
      e->Graphics->DrawImage( imageFile, PointF(0.0F,0.0F) );

      // Release graphics object.
      delete newGraphics;
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.Rectangle,System.Single,System.Single)
   // <snippet7>
private:
   void DrawArcRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle to bound ellipse.
      Rectangle rect = Rectangle(0,0,100,200);

      // Create start and sweep angles on ellipse.
      float startAngle = 45.0F;
      float sweepAngle = 270.0F;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, rect, startAngle, sweepAngle );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.RectangleF,System.Single,System.Single)
   // <snippet8>
private:
   void DrawArcRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle to bound ellipse.
      RectangleF rect = RectangleF(0.0F,0.0F,100.0F,200.0F);

      // Create start and sweep angles on ellipse.
      float startAngle = 45.0F;
      float sweepAngle = 270.0F;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, rect, startAngle, sweepAngle );
   }
   // </snippet8>

   // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet9>
private:
   void DrawArcInt( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );
      // Create coordinates of rectangle to bound ellipse.
      int x = 0;
      int y = 0;
      int width = 100;
      int height = 200;

      // Create start and sweep angles on ellipse.
      int startAngle = 45;
      int sweepAngle = 270;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, x, y, width, height, startAngle, sweepAngle );
   }
   // </snippet9>

   // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
   // <snippet10>
private:
   void DrawArcFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create coordinates of rectangle to bound ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 100.0F;
      float height = 200.0F;

      // Create start and sweep angles on ellipse.
      float startAngle = 45.0F;
      float sweepAngle = 270.0F;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, x, y, width, height, startAngle, sweepAngle );
   }
   // </snippet10>

   // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point)
   // <snippet11>
private:
   void DrawBezierPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      Point start = Point(100,100);
      Point control1 = Point(200,10);
      Point control2 = Point(350,50);
      Point end = Point(500,100);

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, start, control1, control2, end );
   }
   // </snippet11>

   // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF)
   // <snippet12>
private:
   void DrawBezierPointF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      PointF start = PointF(100.0F,100.0F);
      PointF control1 = PointF(200.0F,10.0F);
      PointF control2 = PointF(350.0F,50.0F);
      PointF end = PointF(500.0F,100.0F);

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, start, control1, control2, end );
   }
   // </snippet12>

   // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
   // <snippet13>
private:
   void DrawBezierFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create coordinates of points for curve.
      float startX = 100.0F;
      float startY = 100.0F;
      float controlX1 = 200.0F;
      float controlY1 = 10.0F;
      float controlX2 = 350.0F;
      float controlY2 = 50.0F;
      float endX = 500.0F;
      float endY = 100.0F;

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, startX, startY, controlX1, controlY1, controlX2, controlY2, endX, endY );
   }
   // </snippet13>

   // Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.Point[])
   // <snippet14>
private:
   void DrawBeziersPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      Point start = Point(100,100);
      Point control1 = Point(200,10);
      Point control2 = Point(350,50);
      Point end1 = Point(500,100);
      Point control3 = Point(600,150);
      Point control4 = Point(650,250);
      Point end2 = Point(500,300);
      array<Point>^ bezierPoints = {start,control1,control2,end1,control3,control4,end2};

      // Draw arc to screen.
      e->Graphics->DrawBeziers( blackPen, bezierPoints );
   }
   // </snippet14>

   // Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.PointF[])
   // <snippet15>
private:
   void DrawBeziersPointF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      PointF start = PointF(100.0F,100.0F);
      PointF control1 = PointF(200.0F,10.0F);
      PointF control2 = PointF(350.0F,50.0F);
      PointF end1 = PointF(500.0F,100.0F);
      PointF control3 = PointF(600.0F,150.0F);
      PointF control4 = PointF(650.0F,250.0F);
      PointF end2 = PointF(500.0F,300.0F);
      array<PointF>^ bezierPoints = {start,control1,control2,end1,control3,control4,end2};

      // Draw arc to screen.
      e->Graphics->DrawBeziers( blackPen, bezierPoints );
   }
   // </snippet15>

   // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[])
   // <snippet16>
private:
   void DrawClosedCurvePoint( PaintEventArgs^ e )
   {

      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Draw closed curve to screen.
      e->Graphics->DrawClosedCurve( greenPen, curvePoints );
   }
   // </snippet16>

   // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single,System.Drawing.Drawing2D.FillMode)
   // <snippet17>
private:
   void DrawClosedCurvePointTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create tension and fill mode.
      float tension = 1.0F;
      FillMode aFillMode = FillMode::Alternate;

      // Draw closed curve to screen.
      e->Graphics->DrawClosedCurve( greenPen, curvePoints, tension, aFillMode );
   }
   // </snippet17>

   // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[])
   // <snippet18>
private:
   void DrawClosedCurvePointF( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Draw closed curve to screen.
      e->Graphics->DrawClosedCurve( greenPen, curvePoints );
   }
   // </snippet18>

   // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single,System.Drawing.Drawing2D.FillMode)
   // <snippet19>
private:
   void DrawClosedCurvePointFTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create tension and fill mode.
      float tension = 1.0F;
      FillMode aFillMode = FillMode::Alternate;

      // Draw closed curve to screen.
      e->Graphics->DrawClosedCurve( greenPen, curvePoints, tension, aFillMode );
   }
   // </snippet19>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[])
   // <snippet20>
private:
   void DrawCurvePoint( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints );
   }
   // </snippet20>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Int32,System.Int32,System.Single)
   // <snippet21>
private:
   void DrawCurvePointSegmentTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create offset, number of segments, and tension.
      int offset = 2;
      int numSegments = 4;
      float tension = 1.0F;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, offset, numSegments, tension );
   }
   // </snippet21>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single)
   // <snippet22>
private:
   void DrawCurvePointTension( PaintEventArgs^ e )
   {

      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create tension.
      float tension = 1.0F;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, tension );
   }
   // </snippet22>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[])
   // <snippet23>
private:
   void DrawCurvePointF( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints );
   }
   // </snippet23>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32)
   // <snippet24>
private:
   void DrawCurvePointFSegments( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create offset and number of segments.
      int offset = 2;
      int numSegments = 4;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, offset, numSegments );
   }
   // </snippet24>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32,System.Single)
   // <snippet25>
private:
   void DrawCurvePointFSegmentTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create offset, number of segments, and tension.
      int offset = 2;
      int numSegments = 4;
      float tension = 1.0F;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, offset, numSegments, tension );
   }
   // </snippet25>

   // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single)
   // <snippet26>
private:
   void DrawCurvePointFTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create tension.
      float tension = 1.0F;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, tension );
   }
   // </snippet26>

   // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.Rectangle)
   // <snippet27>
private:
   void DrawEllipseRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      Rectangle rect = Rectangle(0,0,200,100);

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, rect );
   }
   // </snippet27>

   // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.RectangleF)
   // <snippet28>
private:
   void DrawEllipseRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      RectangleF rect = RectangleF(0.0F,0.0F,200.0F,100.0F);

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, rect );
   }
   // </snippet28>

   // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet29>
private:
   void DrawEllipseInt( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create location and size of ellipse.
      int x = 0;
      int y = 0;
      int width = 200;
      int height = 100;

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, x, y, width, height );
   }
   // </snippet29>

   // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
   // <snippet30>
private:
   void DrawEllipseFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create location and size of ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 100.0F;

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, x, y, width, height );
   }
   // </snippet30>

   // Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Drawing.Rectangle)
   // <snippet31>
private:
   void DrawIconRectangle( PaintEventArgs^ e )
   {
      // Create icon.
      System::Drawing::Icon^ newIcon = gcnew System::Drawing::Icon( "SampIcon.ico" );

      // Create rectangle for icon.
      Rectangle rect = Rectangle(100,100,200,200);

      // Draw icon to screen.
      e->Graphics->DrawIcon( newIcon, rect );
   }
   // </snippet31>

   // Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Int32,System.Int32)
   // <snippet32>
private:
   void DrawIconInt( PaintEventArgs^ e )
   {

      // Create icon.
      System::Drawing::Icon^ newIcon = gcnew System::Drawing::Icon( "SampIcon.ico" );

      // Create coordinates for upper-left corner of icon.
      int x = 100;
      int y = 100;

      // Draw icon to screen.
      e->Graphics->DrawIcon( newIcon, x, y );
   }
   // </snippet32>

   // Snippet for: M:System.Drawing.Graphics.DrawIconUnstretched(System.Drawing.Icon,System.Drawing.Rectangle)
   // <snippet33>
private:
   void DrawIconUnstretchedRectangle( PaintEventArgs^ e )
   {

      // Create icon.
      System::Drawing::Icon^ newIcon = gcnew System::Drawing::Icon( "SampIcon.ico" );

      // Create rectangle for icon.
      Rectangle rect = Rectangle(100,100,200,200);

      // Draw icon to screen.
      e->Graphics->DrawIconUnstretched( newIcon, rect );
   }
   // </snippet33>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point)
   // <snippet34>
private:
   void DrawImagePoint( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create Point for upper-left corner of image.
      Point ulCorner = Point(100,100);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, ulCorner );
   }
   // </snippet34>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[])
   // <snippet35>
private:
   void DrawImagePara( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(550,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara = {ulCorner,urCorner,llCorner};

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara );
   }
   // </snippet35>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
   // <snippet36>
private:
   void DrawImageParaRect( PaintEventArgs^ e )
   {

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(325,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara = {ulCorner,urCorner,llCorner};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara, srcRect, units );
   }
   // </snippet36>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
   // <snippet37>
private:
   void DrawImageParaRectAttrib( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      Point ulCorner1 = Point(100,100);
      Point urCorner1 = Point(325,100);
      Point llCorner1 = Point(150,250);
      array<Point>^ destPara1 = {ulCorner1,urCorner1,llCorner1};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create parallelogram for drawing adjusted image.
      Point ulCorner2 = Point(325,100);
      Point urCorner2 = Point(550,100);
      Point llCorner2 = Point(375,250);
      array<Point>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );

      // Draw adjusted image to screen.
      e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr );
   }
   // </snippet37>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
   // <snippet38>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback1( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageParaRectAttribAbort( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback1 );

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(550,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara1 = {ulCorner,urCorner,llCorner};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create parallelogram for drawing adjusted image.
      Point ulCorner2 = Point(325,100);
      Point urCorner2 = Point(550,100);
      Point llCorner2 = Point(375,250);
      array<Point>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw image to screen.
         e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr, imageCallback );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet38>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
   // <snippet39>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback2( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageParaRectAttribAbortData( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback2 );
      int imageCallbackData = 1;

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      Point ulCorner = Point(100,100);
      Point urCorner = Point(550,100);
      Point llCorner = Point(150,250);
      array<Point>^ destPara1 = {ulCorner,urCorner,llCorner};

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create parallelogram for drawing adjusted image.
      Point ulCorner2 = Point(325,100);
      Point urCorner2 = Point(550,100);
      Point llCorner2 = Point(375,250);
      array<Point>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw image to screen.
         e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr, imageCallback, imageCallbackData );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet39>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF)
   // <snippet40>
private:
   void DrawImagePointF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create point for upper-left corner of image.
      PointF ulCorner = PointF(100.0F,100.0F);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, ulCorner );
   }
   // </snippet40>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[])
   // <snippet41>
private:
   void DrawImageParaF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      PointF ulCorner = PointF(100.0F,100.0F);
      PointF urCorner = PointF(550.0F,100.0F);
      PointF llCorner = PointF(150.0F,250.0F);
      array<PointF>^ destPara = {ulCorner,urCorner,llCorner};

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara );
   }
   // </snippet41>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
   // <snippet42>
private:
   void DrawImageParaFRectF( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing image.
      PointF ulCorner = PointF(100.0F,100.0F);
      PointF urCorner = PointF(550.0F,100.0F);
      PointF llCorner = PointF(150.0F,250.0F);
      array<PointF>^ destPara = {ulCorner,urCorner,llCorner};

      // Create rectangle for source image.
      RectangleF srcRect = RectangleF(50.0F,50.0F,150.0F,150.0F);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destPara, srcRect, units );
   }
   // </snippet42>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
   // <snippet43>
   void DrawImageParaFRectFAttrib( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      PointF ulCorner1 = PointF(100.0F,100.0F);
      PointF urCorner1 = PointF(325.0F,100.0F);
      PointF llCorner1 = PointF(150.0F,250.0F);
      array<PointF>^ destPara1 = {ulCorner1,urCorner1,llCorner1};

      // Create rectangle for source image.
      RectangleF srcRect = RectangleF(50.0F,50.0F,150.0F,150.0F);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Create parallelogram for drawing adjusted image.
      PointF ulCorner2 = PointF(325.0F,100.0F);
      PointF urCorner2 = PointF(550.0F,100.0F);
      PointF llCorner2 = PointF(375.0F,250.0F);
      array<PointF>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );

      // Draw adjusted image to screen.
      e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr );
   }
   // </snippet43>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
   // <snippet44>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback3( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageParaFRectAttribAbort( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback3 );

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      PointF ulCorner1 = PointF(100.0F,100.0F);
      PointF urCorner1 = PointF(325.0F,100.0F);
      PointF llCorner1 = PointF(150.0F,250.0F);
      array<PointF>^ destPara1 = {ulCorner1,urCorner1,llCorner1};

      // Create rectangle for source image.
      RectangleF srcRect = RectangleF(50.0F,50.0F,150.0F,150.0F);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Create parallelogram for drawing adjusted image.
      PointF ulCorner2 = PointF(325.0F,100.0F);
      PointF urCorner2 = PointF(550.0F,100.0F);
      PointF llCorner2 = PointF(375.0F,250.0F);
      array<PointF>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr, imageCallback );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet44>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
   // <snippet45>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback4( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageParaFRectAttribAbortData( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback4 );
      int imageCallbackData = 1;

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create parallelogram for drawing original image.
      PointF ulCorner1 = PointF(100.0F,100.0F);
      PointF urCorner1 = PointF(325.0F,100.0F);
      PointF llCorner1 = PointF(150.0F,250.0F);
      array<PointF>^ destPara1 = {ulCorner1,urCorner1,llCorner1};

      // Create rectangle for source image.
      RectangleF srcRect = RectangleF(50.0F,50.0F,150.0F,150.0F);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Create parallelogram for drawing adjusted image.
      PointF ulCorner2 = PointF(325.0F,100.0F);
      PointF urCorner2 = PointF(550.0F,100.0F);
      PointF llCorner2 = PointF(375.0F,250.0F);
      array<PointF>^ destPara2 = {ulCorner2,urCorner2,llCorner2};

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destPara1, srcRect, units );

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destPara2, srcRect, units, imageAttr, imageCallback, imageCallbackData );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet45>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle)
   // <snippet46>
private:
   void DrawImageRect( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect );
   }
   // </snippet46>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
   // <snippet47>
private:
   void DrawImageRectRect( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Create rectangle for source image.
      Rectangle srcRect = Rectangle(50,50,150,150);
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect, srcRect, units );
   }
   // </snippet47>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit)
   // <snippet48>
   void DrawImageRect4Int( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Create coordinates of rectangle for source image.
      int x = 50;
      int y = 50;
      int width = 150;
      int height = 150;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect, x, y, width, height, units );
   }
   // </snippet48>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
   // <snippet49>
   void DrawImageRect4IntAtrrib( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      int x = 50;
      int y = 50;
      int width = 150;
      int height = 150;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );

      // Draw adjusted image to screen.
      e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr );
   }
   // </snippet49>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
   // <snippet50>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback5( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageRect4IntAtrribAbort( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback5 );

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      int x = 50;
      int y = 50;
      int width = 150;
      int height = 150;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr, imageCallback );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet50>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
   // <snippet51>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback6( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageRect4IntAtrribAbortData( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback6 );
      IntPtr imageCallbackData = IntPtr(1);

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      int x = 50;
      int y = 50;
      int width = 150;
      int height = 150;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr, imageCallback, imageCallbackData );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet51>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit)
   // <snippet52>
private:
   void DrawImageRect4Float( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying image.
      Rectangle destRect = Rectangle(100,100,450,150);

      // Create coordinates of rectangle for source image.
      float x = 50.0F;
      float y = 50.0F;
      float width = 150.0F;
      float height = 150.0F;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, destRect, x, y, width, height, units );
   }
   // </snippet52>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
   // <snippet53>
private:
   void DrawImageRect4FloatAttrib( PaintEventArgs^ e )
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      float x = 50.0F;
      float y = 50.0F;
      float width = 150.0F;
      float height = 150.0F;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );

      // Draw adjusted image to screen.
      e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr );
   }
   // </snippet53>

   // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
   // <snippet54>
   // Define DrawImageAbort callback method.
private:
   bool DrawImageCallback7( IntPtr callBackData )
   {
      // Test for call that passes callBackData parameter.
      if ( callBackData == IntPtr::Zero )
      {
         // If no callBackData passed, abort DrawImage method.
         return true;
      }
      else
      {
         // If callBackData passed, continue DrawImage method.
         return false;
      }
   }

private:
   void DrawImageRect4FloatAttribAbort( PaintEventArgs^ e )
   {
      // Create callback method.
      Graphics::DrawImageAbort^ imageCallback = gcnew Graphics::DrawImageAbort( this, &Form1::DrawImageCallback7 );

      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create rectangle for displaying original image.
      Rectangle destRect1 = Rectangle(100,25,450,150);

      // Create coordinates of rectangle for source image.
      float x = 50.0F;
      float y = 50.0F;
      float width = 150.0F;
      float height = 150.0F;
      GraphicsUnit units = GraphicsUnit::Pixel;

      // Draw original image to screen.
      e->Graphics->DrawImage( newImage, destRect1, x, y, width, height, units );

      // Create rectangle for adjusted image.
      Rectangle destRect2 = Rectangle(100,175,450,150);

      // Create image attributes and set large gamma.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetGamma( 4.0F );
      try
      {
         // Draw adjusted image to screen.
         e->Graphics->DrawImage( newImage, destRect2, x, y, width, height, units, imageAttr, imageCallback );
      }
      catch ( Exception^ ex ) 
      {
         e->Graphics->DrawString( ex->ToString(), gcnew System::Drawing::Font( "Arial",8 ), Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet54>

   // Snippet for: T:System.Drawing.Image
   // <snippet55>
private:
   void ImageExampleForm_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) 
   {
      // Create image.
      Image^ newImage = Image::FromFile( "SampImag.jpg" );

      // Create Point for upper-left corner of image.
      Point ulCorner = Point(100,100);

      // Draw image to screen.
      e->Graphics->DrawImage( newImage, ulCorner );
   }
   // </snippet55>


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
