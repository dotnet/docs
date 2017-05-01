Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class LinesCurvesAndShapes
    Inherits Form
    Dim myPen As Pen = Pens.Black
    Dim mySolidBrush As SolidBrush = CType(Brushes.Red,SolidBrush)
    Dim myGraphicsPath As New GraphicsPath()

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New LinesCurvesAndShapes())
    End Sub

    ' 0195df81-66be-452d-bb53-5a582ebfdc09
    ' Vector Graphics Overview
    Public Sub Method11(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet11>
        myGraphics.DrawRectangle(myPen, 20, 10, 100, 50)

        ' </snippet11>
    End Sub
    ' 08d2cc9a-dc9d-4eed-bcbb-2c8e2ca5d3ae
    ' Open and Closed Curves in GDI+
    Public Sub Method21(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet21>
        myGraphics.FillPie(mySolidBrush, 0, 0, 140, 70, 0, 120)
        myGraphics.DrawArc(myPen, 0, 0, 140, 70, 0, 120)

        ' </snippet21>
    End Sub
    Public Sub Method22(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet22>
        Dim myPointArray As Point() = _
           {New Point(0, 0), New Point(60, 20), New Point(40, 50)}
        myGraphics.DrawClosedCurve(myPen, myPointArray)
        myGraphics.FillClosedCurve(mySolidBrush, myPointArray)

        ' </snippet22>
    End Sub
    Public Sub Method23(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet23>
        Dim mySolidBrush As New SolidBrush(Color.Aqua)
        Dim myGraphicsPath As New GraphicsPath()

        Dim myPointArray As Point() = { _
           New Point(15, 20), _
           New Point(20, 40), _
           New Point(50, 30)}

        Dim myFontFamily As New FontFamily("Times New Roman")
        Dim myPointF As New PointF(50, 20)
        Dim myStringFormat As New StringFormat()

        myGraphicsPath.AddArc(0, 0, 30, 20, -90, 180)
        myGraphicsPath.AddCurve(myPointArray)
        myGraphicsPath.AddString("a string in a path", myFontFamily, _
           0, 24, myPointF, myStringFormat)
        myGraphicsPath.AddPie(230, 10, 40, 40, 40, 110)

        myGraphics.FillPath(mySolidBrush, myGraphicsPath)
        myGraphics.DrawPath(myPen, myGraphicsPath)

        ' </snippet23>
    End Sub
    ' 09b3797a-6294-422d-9adf-a5a0a7695c0c
    ' Cardinal Splines in GDI+
    Public Sub Method31(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim myPointArray() As Point = New Point() {New Point(10, 10), _
           New Point(50, 40), New Point(123, 200)}
        ' <snippet31>
        myGraphics.DrawCurve(myPen, myPointArray, 1.5F)

        ' </snippet31>
    End Sub
    ' 30b25aae-e3eb-4479-bdb8-187cf651fc84
    ' Pens, Lines, and Rectangles in GDI+
    Public Sub Method41(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet41>
        myGraphics.DrawLine(myPen, 4, 2, 12, 6)

        ' </snippet41>
    End Sub
    Public Sub Method42(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet42>
        Dim myStartPoint As New Point(4, 2)
        Dim myEndPoint As New Point(12, 6)
        myGraphics.DrawLine(myPen, myStartPoint, myEndPoint)

        ' </snippet42>
    End Sub
    Public Sub Method43(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet43>
        Dim myPen As New Pen(Color.Blue, 2)
        myGraphics.DrawLine(myPen, 0, 0, 60, 30)

        ' </snippet43>
    End Sub
    Public Sub Method44(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet44>
        myPen.DashStyle = DashStyle.Dash
        myGraphics.DrawLine(myPen, 100, 50, 300, 80)

        ' </snippet44>
    End Sub
    Public Sub Method45(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet45>
        myGraphics.DrawRectangle(myPen, 100, 50, 80, 40)

        ' </snippet45>
    End Sub
    Public Sub Method46(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet46>
        Dim myRectangle As New Rectangle(100, 50, 80, 40)
        myGraphics.DrawRectangle(myPen, myRectangle)

        ' </snippet46>
    End Sub
    ' 34f35133-a835-4ca4-81f6-0dfedee8b683
    ' Ellipses and Arcs in GDI+
    Public Sub Method51(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet51>
        myGraphics.DrawEllipse(myPen, 100, 50, 80, 40)

        ' </snippet51>
    End Sub
    Public Sub Method52(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet52>
        Dim myRectangle As New Rectangle(100, 50, 80, 40)
        myGraphics.DrawEllipse(myPen, myRectangle)

        ' </snippet52>
    End Sub
    Public Sub Method53(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet53>
        myGraphics.DrawArc(myPen, 100, 50, 140, 70, 30, 180)

        ' </snippet53>
    End Sub
    ' 52184f9b-16dd-4bbd-85be-029112644ceb
    ' Regions in GDI+
    Public Sub Method61(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim myRegion As New Region(Me.ClientRectangle)
        ' <snippet61>
        myGraphics.FillRegion(mySolidBrush, myRegion)

        ' </snippet61>
    End Sub
    ' 5774ce1e-87d4-4bc7-88c4-4862052781b8
    ' Bézier Splines in GDI+
    Public Sub Method71(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet71>
        myGraphics.DrawBezier(myPen, 0, 0, 40, 20, 80, 150, 100, 10)

        ' </snippet71>
    End Sub
    ' 810da1a4-c136-4abf-88df-68e49efdd8d4
    ' Antialiasing with Lines and Curves
    Public Sub Method81(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet81>
        myGraphics.SmoothingMode = SmoothingMode.AntiAlias
        myGraphics.DrawLine(myPen, 0, 0, 12, 8)

        ' </snippet81>
    End Sub
    ' 8b5f71d9-d2f0-4540-9c41-740f90fd4c26
    ' Restricting the Drawing Surface in GDI+
    Public Sub Method91(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim myRegion As New Region(Me.ClientRectangle)
        ' <snippet91>
        myGraphics.Clip = myRegion
        myGraphics.DrawLine(myPen, 0, 0, 200, 200)

        ' </snippet91>
    End Sub
    ' a5500dec-666c-41fd-9da3-2169dd89c5eb
    ' Graphics Paths in GDI+
    Public Sub Method101(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet101>
        myGraphicsPath.AddLine(0, 0, 30, 20)
        myGraphicsPath.AddEllipse(20, 20, 20, 40)
        myGraphicsPath.AddBezier(30, 60, 70, 60, 50, 30, 100, 10)
        myGraphics.DrawPath(myPen, myGraphicsPath)

        ' </snippet101>
    End Sub
    Public Sub Method102(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim graphicsPath1 As New GraphicsPath()
        Dim graphicsPath2 As New GraphicsPath()
        ' <snippet102>
        myGraphicsPath.AddPath(graphicsPath1, False)
        myGraphicsPath.AddPath(graphicsPath2, False)

        ' </snippet102>
    End Sub
    Public Sub Method103(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet103>
        Dim myGraphicsPath As New GraphicsPath()

        Dim myPointArray As Point() = { _
           New Point(5, 30), _
           New Point(20, 40), _
           New Point(50, 30)}

        Dim myFontFamily As New FontFamily("Times New Roman")
        Dim myPointF As New PointF(50, 20)
        Dim myStringFormat As New StringFormat()

        myGraphicsPath.AddArc(0, 0, 30, 20, -90, 180)
        myGraphicsPath.StartFigure()
        myGraphicsPath.AddCurve(myPointArray)
        myGraphicsPath.AddString("a string in a path", myFontFamily, _
           0, 24, myPointF, myStringFormat)
        myGraphicsPath.AddPie(230, 10, 40, 40, 40, 110)
        myGraphics.DrawPath(myPen, myGraphicsPath)

        ' </snippet103>
    End Sub
    ' a72213d2-d69a-4c2b-a75c-be7b20390c13
    ' Polygons in GDI+
    Public Sub Method111(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet111>
        Dim myPointArray As Point() = _
           {New Point(0, 0), New Point(50, 30), New Point(30, 60)}
        myGraphics.DrawPolygon(myPen, myPointArray)

        ' </snippet111>
    End Sub
    ' e863e2a7-0294-4130-99b6-f1ea3201e7cd
    ' Brushes and Filled Shapes in GDI+
    Public Sub Method121(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet121>
        Dim mySolidBrush As New SolidBrush(Color.Red)
        myGraphics.FillEllipse(mySolidBrush, 0, 0, 60, 40)

        ' </snippet121>
    End Sub
    Public Sub Method122()
        ' <snippet122>
        Dim myHatchBrush As _
           New HatchBrush(HatchStyle.Vertical, Color.Blue, Color.Green)

        ' </snippet122>
    End Sub
    Public Sub Method123(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        ' <snippet123>
        Dim myImage As Image = Image.FromFile("MyTexture.bmp")
        Dim myTextureBrush As New TextureBrush(myImage)
        myGraphics.FillEllipse(myTextureBrush, 0, 0, 100, 50)

        ' </snippet123>
    End Sub
    Public Sub Method124(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim myRectangle As Rectangle = Me.ClientRectangle
        ' <snippet124>
        Dim myLinearGradientBrush As New LinearGradientBrush( _
           myRectangle, _
           Color.Blue, _
           Color.Green, _
           LinearGradientMode.Horizontal)
        myGraphics.FillEllipse(myLinearGradientBrush, myRectangle)

        ' </snippet124>
    End Sub
End Class


