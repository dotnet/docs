Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class SystemDrawingMiscLegacyTopics

    ' 1e717711-1361-448e-aa49-0f3ec43110c9
    ' Using the World Transformation
    Private Sub Method11(ByVal e As PaintEventArgs)
        
        ' <snippet11>
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet11>
    End Sub
    Private Sub Method12(ByVal e As PaintEventArgs)
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        ' <snippet12>
        e.Graphics.ScaleTransform(1.75F, 0.5F)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet12>
    End Sub
    Private Sub Method13(ByVal e As PaintEventArgs)
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        ' <snippet13>
        e.Graphics.ResetTransform()
        e.Graphics.RotateTransform(28) ' 28 degrees
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet13>
    End Sub
    Private Sub Method14(ByVal e As PaintEventArgs)
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        ' <snippet14>
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(150, 150)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet14>
    End Sub
    ' 37d5f9dc-a5cf-4475-aa5d-34d714e808a9
    ' Why Transformation Order Is Significant
    Private Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        e.Graphics.ResetTransform()
        e.Graphics.ScaleTransform(1.75F, 0.5F)
        e.Graphics.RotateTransform(28, MatrixOrder.Append)
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Append)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet21>
    End Sub
    Private Sub Method22(ByVal e As PaintEventArgs)
        ' <snippet22>
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Append)
        e.Graphics.RotateTransform(28, MatrixOrder.Append)
        e.Graphics.ScaleTransform(1.75F, 0.5F)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet22>
    End Sub
    Private Sub Method23(ByVal e As PaintEventArgs)
        ' <snippet23>
        Dim rect As New Rectangle(0, 0, 50, 50)
        Dim pen As New Pen(Color.FromArgb(128, 200, 0, 200), 2)
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Prepend)
        e.Graphics.RotateTransform(28, MatrixOrder.Prepend)
        e.Graphics.ScaleTransform(1.75F, 0.5F)
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet23>
    End Sub
    ' 3a4c07cb-a40a-4d14-ad35-008f531910a8
    ' How to: Use Hit Testing with a Region
    Private Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim point As New Point(60, 10)

        ' Assume that the variable "point" contains the location of the
        ' most recent mouse click.
        ' To simulate a hit, assign (60, 10) to point.
        ' To simulate a miss, assign (0, 0) to point.

        Dim solidBrush As New SolidBrush(Color.Black)
        Dim region1 As New [Region](New Rectangle(50, 0, 50, 150))
        Dim region2 As New [Region](New Rectangle(0, 50, 150, 50))

        ' Create a plus-shaped region by forming the union of region1 and region2.
        ' The union replaces region1.
        region1.Union(region2)

        If region1.IsVisible(point, e.Graphics) Then
            ' The point is in the region. Use an opaque brush.
            solidBrush.Color = Color.FromArgb(255, 255, 0, 0)
        Else
            ' The point is not in the region. Use a semitransparent brush.
            solidBrush.Color = Color.FromArgb(64, 255, 0, 0)
        End If

        e.Graphics.FillRegion(solidBrush, region1)

        ' </snippet31>
    End Sub
    ' 43d121b4-e14c-4901-b25c-2d6c25ba4e29
    ' How to: Use Clipping with a Region
    Private Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        ' Create a path that consists of a single polygon.
        Dim polyPoints As Point() = { _
           New Point(10, 10), _
           New Point(150, 10), _
           New Point(100, 75), _
           New Point(100, 150)}
        Dim path As New GraphicsPath()
        path.AddPolygon(polyPoints)

        ' Construct a region based on the path.
        Dim [region] As New [Region](path)

        ' Draw the outline of the region.
        Dim pen As Pen = Pens.Black
        e.Graphics.DrawPath(pen, path)

        ' Set the clipping region of the Graphics object.
        e.Graphics.SetClip([region], CombineMode.Replace)

        ' Draw some clipped strings.
        Dim fontFamily As New FontFamily("Arial")
        Dim font As New Font( _
           fontFamily, _
           36, _
           FontStyle.Bold, _
           GraphicsUnit.Pixel)
        Dim solidBrush As New SolidBrush(Color.FromArgb(255, 255, 0, 0))

        e.Graphics.DrawString( _
           "A Clipping Region", _
           font, _
           solidBrush, _
           New PointF(15, 25))

        e.Graphics.DrawString( _
           "A Clipping Region", _
           font, _
           solidBrush, _
           New PointF(15, 68))

        ' </snippet41>
    End Sub

    ' a0d9f178-43a4-4323-bb5a-d3e3f77ae6c1
    ' Using Nested Graphics Containers
    Private Sub Method61(ByVal e As PaintEventArgs)
        ' <snippet61>
        Dim graphics As Graphics = e.Graphics
        Dim pen As New Pen(Color.Red)
        Dim graphicsContainer As GraphicsContainer
        graphics.FillRectangle(Brushes.Black, 100, 80, 3, 3)

        graphics.TranslateTransform(100, 80)

        graphicsContainer = graphics.BeginContainer()
        graphics.RotateTransform(30)
        graphics.DrawRectangle(pen, -60, -30, 120, 60)
        graphics.EndContainer(graphicsContainer)

        graphics.DrawRectangle(pen, -60, -30, 120, 60)

        ' </snippet61>
    End Sub
    Private Sub Method62(ByVal e As PaintEventArgs)
        ' <snippet62>
        Dim graphics As Graphics = e.Graphics
        Dim graphicsContainer As GraphicsContainer
        Dim redPen As New Pen(Color.Red, 2)
        Dim bluePen As New Pen(Color.Blue, 2)
        Dim aquaBrush As New SolidBrush(Color.FromArgb(255, 180, 255, 255))
        Dim greenBrush As New SolidBrush(Color.FromArgb(255, 150, 250, 130))

        graphics.SetClip(New Rectangle(50, 65, 150, 120))
        graphics.FillRectangle(aquaBrush, 50, 65, 150, 120)

        graphicsContainer = graphics.BeginContainer()
        ' Create a path that consists of a single ellipse.
        Dim path As New GraphicsPath()
        path.AddEllipse(75, 50, 100, 150)

        ' Construct a region based on the path.
        Dim [region] As New [Region](path)
        graphics.FillRegion(greenBrush, [region])

        graphics.SetClip([region], CombineMode.Replace)
        graphics.DrawLine(redPen, 50, 0, 350, 300)
        graphics.EndContainer(graphicsContainer)

        graphics.DrawLine(bluePen, 70, 0, 370, 300)

        ' </snippet62>
    End Sub
    Private Sub Method63(ByVal e As PaintEventArgs)
        ' <snippet63>
        Dim graphics As Graphics = e.Graphics
        Dim innerContainer As GraphicsContainer
        Dim outerContainer As GraphicsContainer
        Dim brush As New SolidBrush(Color.Blue)
        Dim fontFamily As New FontFamily("Times New Roman")
        Dim font As New Font( _
           fontFamily, _
           36, _
           FontStyle.Regular, _
           GraphicsUnit.Pixel)

        graphics.TextRenderingHint = _
        System.Drawing.Text.TextRenderingHint.AntiAlias

        outerContainer = graphics.BeginContainer()

        graphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.SingleBitPerPixel

        innerContainer = graphics.BeginContainer()
        graphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.AntiAlias
        graphics.DrawString( _
           "Inner Container", _
           font, _
           brush, _
           New PointF(20, 10))
        graphics.EndContainer(innerContainer)

        graphics.DrawString("Outer Container", font, brush, New PointF(20, 50))

        graphics.EndContainer(outerContainer)

        graphics.DrawString("Graphics Object", font, brush, New PointF(20, 90))

        ' </snippet63>
    End Sub
End Class

