Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region
    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
    ' <snippet55>
    Private Function DrawImageCallback8(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Public Sub DrawImageRect4FloatAttribAbortData(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback8)
        Dim imageCallbackData As New IntPtr(1)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying original image.
        Dim destRect1 As New Rectangle(100, 25, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 150.0F
        Dim height As Single = 150.0F
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destRect1, x, y, width, _
        height, units)

        ' Create rectangle for adjusted image.
        Dim destRect2 As New Rectangle(100, 175, 450, 150)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, _
            height, units, imageAttr, imageCallback, imageCallbackData)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet55>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.RectangleF)
    ' <snippet56>
    Public Sub DrawImageRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim rect As New RectangleF(100.0F, 100.0F, 450.0F, 150.0F)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, rect)
    End Sub
    ' </snippet56>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.RectangleF,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
    ' <snippet57>
    Public Sub DrawImageRectFRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New RectangleF(100.0F, 100.0F, 450.0F, 150.0F)

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, srcRect, units)
    End Sub
    ' </snippet57>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32)
    ' <snippet58>
    Public Sub DrawImage2Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y)
    End Sub
    ' </snippet58>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
    ' <snippet59>
    Public Sub DrawImage2IntRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, srcRect, units)
    End Sub
    ' </snippet59>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet60>
    Public Sub DrawImage4Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner

        ' of image and for size of image.
        Dim x As Integer = 100
        Dim y As Integer = 100
        Dim width As Integer = 450
        Dim height As Integer = 150

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, width, height)
    End Sub
    ' </snippet60>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single)
    ' <snippet61>
    Public Sub DrawImage2Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y)
    End Sub
    ' </snippet61>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
    ' <snippet62>
    Public Sub DrawImage2FloatRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, srcRect, units)
    End Sub
    ' </snippet62>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single,System.Single,System.Single)
    ' <snippet63>
    Public Sub DrawImage4Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner

        ' of image and for size of image.
        Dim x As Single = 100.0F
        Dim y As Single = 100.0F
        Dim width As Single = 450.0F
        Dim height As Single = 150.0F

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, x, y, width, height)
    End Sub
    ' </snippet63>


    ' Snippet for: M:System.Drawing.Graphics.DrawImageUnscaled(System.Drawing.Image,System.Drawing.Point)
    ' <snippet64>
    Public Sub DrawImageUnscaledPoint(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImageUnscaled(newImage, ulCorner)
    End Sub
    ' </snippet64>


    ' Snippet for: M:System.Drawing.Graphics.DrawImageUnscaled(System.Drawing.Image,System.Int32,System.Int32)
    ' <snippet65>
    Public Sub DrawImageUnscaledInt(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create coordinates for upper-left corner of image.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Draw image to screen.
        e.Graphics.DrawImageUnscaled(newImage, x, y)
    End Sub
    ' </snippet65>


    ' Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Drawing.Point,System.Drawing.Point)
    ' <snippet66>
    Public Sub DrawLinePoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define line.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(500, 100)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
    End Sub
    ' </snippet66>


    ' Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Drawing.PointF,System.Drawing.PointF)
    ' <snippet67>
    Public Sub DrawLinePointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define line.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(500.0F, 100.0F)

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, point1, point2)
    End Sub
    ' </snippet67>


    ' Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet68>
    Public Sub DrawLineInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of points that define line.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim x2 As Integer = 500
        Dim y2 As Integer = 100

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, x1, y1, x2, y2)
    End Sub
    ' </snippet68>


    ' Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
    ' <snippet69>
    Public Sub DrawLineFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of points that define line.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim x2 As Single = 500.0F
        Dim y2 As Single = 100.0F

        ' Draw line to screen.
        e.Graphics.DrawLine(blackPen, x1, y1, x2, y2)
    End Sub
    ' </snippet69>


    ' Snippet for: M:System.Drawing.Graphics.DrawLines(System.Drawing.Pen,System.Drawing.Point[])
    ' <snippet70>
    Public Sub DrawLinesPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of points that define lines to draw.
        Dim points As Point() = {New Point(10, 10), New Point(10, 100), _
        New Point(200, 50), New Point(250, 300)}

        'Draw lines to screen.
        e.Graphics.DrawLines(blackPen, points)
    End Sub
    ' </snippet70>


    ' Snippet for: M:System.Drawing.Graphics.DrawLines(System.Drawing.Pen,System.Drawing.PointF[])
    ' <snippet71>
    Public Sub DrawLinesPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of points that define lines to draw.
        Dim points As PointF() = {New PointF(10.0F, 10.0F), _
        New PointF(10.0F, 100.0F), New PointF(200.0F, 50.0F), _
        New PointF(250.0F, 300.0F)}

        'Draw lines to screen.
        e.Graphics.DrawLines(blackPen, points)
    End Sub
    ' </snippet71>


    ' Snippet for: M:System.Drawing.Graphics.DrawPath(System.Drawing.Pen,System.Drawing.Drawing2D.GraphicsPath)
    ' <snippet72>
    Public Sub DrawPathEllipse(ByVal e As PaintEventArgs)

        ' Create graphics path object and add ellipse.
        Dim graphPath As New GraphicsPath
        graphPath.AddEllipse(0, 0, 200, 100)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Draw graphics path to screen.
        e.Graphics.DrawPath(blackPen, graphPath)
    End Sub
    ' </snippet72>


    ' Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Drawing.Rectangle,System.Single,System.Single)
    ' <snippet73>
    Public Sub DrawPieRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New Rectangle(0, 0, 200, 100)

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle)
    End Sub
    ' </snippet73>


    ' Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Drawing.RectangleF,System.Single,System.Single)
    ' <snippet74>
    Public Sub DrawPieRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 200.0F, 100.0F)

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle)
    End Sub
    ' </snippet74>


    ' Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet75>
    Public Sub DrawPieInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Create start and sweep angles.
        Dim startAngle As Integer = 0
        Dim sweepAngle As Integer = 45

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, x, y, width, height, _
        startAngle, sweepAngle)
    End Sub
    ' </snippet75>


    ' Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
    ' <snippet76>
    Public Sub DrawPieFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Draw pie to screen.
        e.Graphics.DrawPie(blackPen, x, y, width, height, _
        startAngle, sweepAngle)
    End Sub
    ' </snippet76>


    ' Snippet for: M:System.Drawing.Graphics.DrawPolygon(System.Drawing.Pen,System.Drawing.Point[])
    ' <snippet77>
    Public Sub DrawPolygonPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define polygon.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw polygon curve to screen.
        e.Graphics.DrawPolygon(blackPen, curvePoints)
    End Sub
    ' </snippet77>


    ' Snippet for: M:System.Drawing.Graphics.DrawPolygon(System.Drawing.Pen,System.Drawing.PointF[])
    ' <snippet78>
    Public Sub DrawPolygonPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points that define polygon.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw polygon to screen.
        e.Graphics.DrawPolygon(blackPen, curvePoints)
    End Sub
    ' </snippet78>


    ' Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Drawing.Rectangle)
    ' <snippet79>
    Public Sub DrawRectangleRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle.
        Dim rect As New Rectangle(0, 0, 200, 200)

        ' Draw rectangle to screen.
        e.Graphics.DrawRectangle(blackPen, rect)
    End Sub
    ' </snippet79>


    ' Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet80>
    Public Sub DrawRectangleInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of rectangle.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 200

        ' Draw rectangle to screen.
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    End Sub
    ' </snippet80>


    ' Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
    ' <snippet81>
    Public Sub DrawRectangleFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of rectangle.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 200.0F

        ' Draw rectangle to screen.
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    End Sub
    ' </snippet81>


    ' Snippet for: M:System.Drawing.Graphics.DrawRectangles(System.Drawing.Pen,System.Drawing.Rectangle[])
    ' <snippet82>
    Public Sub DrawRectanglesRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of rectangles.
        Dim rects As Rectangle() = {New Rectangle(0, 0, 100, 200), _
        New Rectangle(100, 200, 250, 50), _
        New Rectangle(300, 0, 50, 100)}

        ' Draw rectangles to screen.
        e.Graphics.DrawRectangles(blackPen, rects)
    End Sub
    ' </snippet82>


    ' Snippet for: M:System.Drawing.Graphics.DrawRectangles(System.Drawing.Pen,System.Drawing.RectangleF[])
    ' <snippet83>
    Public Sub DrawRectanglesRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of rectangles.
        Dim rects As RectangleF() = {New RectangleF(0.0F, 0.0F, 100.0F, 200.0F), _
        New RectangleF(100.0F, 200.0F, 250.0F, 50.0F), _
        New RectangleF(300.0F, 0.0F, 50.0F, 100.0F)}

        ' Draw rectangles to screen.
        e.Graphics.DrawRectangles(blackPen, rects)
    End Sub
    ' </snippet83>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.PointF)
    ' <snippet84>
    Public Sub DrawStringPointF(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim drawPoint As New PointF(150.0F, 150.0F)

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint)
    End Sub
    ' </snippet84>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.PointF,System.Drawing.StringFormat)
    ' <snippet85>
    Public Sub DrawStringPointFFormat(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim drawPoint As New PointF(150.0F, 50.0F)

        ' Set format of string.
        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, _
        drawPoint, drawFormat)
    End Sub
    ' </snippet85>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.RectangleF)
    ' <snippet86>
    Public Sub DrawStringRectangleF(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create rectangle for drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 150.0F
        Dim width As Single = 200.0F
        Dim height As Single = 50.0F
        Dim drawRect As New RectangleF(x, y, width, height)

        ' Draw rectangle to screen.
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect)
    End Sub
    ' </snippet86>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.RectangleF,System.Drawing.StringFormat)
    ' <snippet87>
    Public Sub DrawStringRectangleFFormat(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create rectangle for drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 150.0F
        Dim width As Single = 200.0F
        Dim height As Single = 50.0F
        Dim drawRect As New RectangleF(x, y, width, height)

        ' Draw rectangle to screen.
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.DrawRectangle(blackPen, x, y, width, height)

        ' Set format of string.
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, _
        drawRect, drawFormat)
    End Sub
    ' </snippet87>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Single,System.Single)
    ' <snippet88>
    Public Sub DrawStringFloat(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 150.0F

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y)
    End Sub
    ' </snippet88>


    ' Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Single,System.Single,System.Drawing.StringFormat)
    ' <snippet89>
    Public Sub DrawStringFloatFormat(ByVal e As PaintEventArgs)

        ' Create string to draw.
        Dim drawString As [String] = "Sample Text"

        ' Create font and brush.
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)

        ' Create point for upper-left corner of drawing.
        Dim x As Single = 150.0F
        Dim y As Single = 50.0F

        ' Set format of string.
        Dim drawFormat As New StringFormat
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Draw string to screen.
        e.Graphics.DrawString(drawString, drawFont, drawBrush, _
        x, y, drawFormat)
    End Sub
    ' </snippet89>


    ' Snippet for: M:System.Drawing.Graphics.EndContainer(System.Drawing.Drawing2D.GraphicsContainer)
    ' <snippet90>
    Public Sub EndContainerState(ByVal e As PaintEventArgs)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer()

        ' Translate world transformation.
        e.Graphics.TranslateTransform(100.0F, 100.0F)

        ' Fill translated rectangle in container with red.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, _
        200, 200)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0, 0, _
        200, 200)
    End Sub
    ' </snippet90>


    ' Snippet for: M:System.Drawing.Graphics.ExcludeClip(System.Drawing.Region)
    ' <snippet91>
    Public Sub ExcludeClipRegion(ByVal e As PaintEventArgs)

        ' Create rectangle for region.
        Dim excludeRect As New Rectangle(100, 100, 200, 200)

        ' Create region for exclusion.
        Dim excludeRegion As New [Region](excludeRect)

        ' Set clipping region to exclude region.
        e.Graphics.ExcludeClip(excludeRegion)

        ' Fill large rectangle to show clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        300, 300)
    End Sub
    ' </snippet91>


    ' Snippet for: M:System.Drawing.Graphics.ExcludeClip(System.Drawing.Rectangle)
    ' <snippet92>
    Public Sub ExcludeClipRectangle(ByVal e As PaintEventArgs)

        ' Create rectangle for exclusion.
        Dim excludeRect As New Rectangle(100, 100, 200, 200)

        ' Set clipping region to exclude rectangle.
        e.Graphics.ExcludeClip(excludeRect)

        ' Fill large rectangle to show clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        300, 300)
    End Sub
    ' </snippet92>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[])
    ' <snippet93>
    Public Sub FillClosedCurvePoint(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        'Create array of points for curve.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(200, 50)
        Dim point3 As New Point(250, 200)
        Dim point4 As New Point(50, 150)
        Dim points As Point() = {point1, point2, point3, point4}

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points)
    End Sub
    ' </snippet93>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode)
    ' <snippet94>
    Public Sub FillClosedCurvePointFillMode(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        'Create array of points for curve.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(200, 50)
        Dim point3 As New Point(250, 200)
        Dim point4 As New Point(50, 150)
        Dim points As Point() = {point1, point2, point3, point4}

        ' Set fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points, newFillMode)
    End Sub
    ' </snippet94>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode,System.Single)
    ' <snippet95>
    Public Sub FillClosedCurvePointFillModeTension(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create array of points for curve.
        Dim point1 As New Point(100, 100)
        Dim point2 As New Point(200, 50)
        Dim point3 As New Point(250, 200)
        Dim point4 As New Point(50, 150)
        Dim points As Point() = {point1, point2, point3, point4}

        ' Set fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Set tension.
        Dim tension As Single = 1.0F

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension)
    End Sub
    ' </snippet95>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[])
    ' <snippet96>
    Public Sub FillClosedCurvePointF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        'Create array of points for curve.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(200.0F, 50.0F)
        Dim point3 As New PointF(250.0F, 200.0F)
        Dim point4 As New PointF(50.0F, 150.0F)
        Dim points As PointF() = {point1, point2, point3, point4}

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points)
    End Sub
    ' </snippet96>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode)
    ' <snippet97>
    Public Sub FillClosedCurvePointFFillMode(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create array of points for curve.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(200.0F, 50.0F)
        Dim point3 As New PointF(250.0F, 200.0F)
        Dim point4 As New PointF(50.0F, 150.0F)
        Dim points As PointF() = {point1, point2, point3, point4}

        ' Set fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points, newFillMode)
    End Sub
    ' </snippet97>


    ' Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode,System.Single)
    ' <snippet98>
    Public Sub FillClosedCurvePointFFillModeTension(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create array of points for curve.
        Dim point1 As New PointF(100.0F, 100.0F)
        Dim point2 As New PointF(200.0F, 50.0F)
        Dim point3 As New PointF(250.0F, 200.0F)
        Dim point4 As New PointF(50.0F, 150.0F)
        Dim points As PointF() = {point1, point2, point3, point4}

        ' Set fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Set tension.
        Dim tension As Single = 1.0F

        ' Fill curve on screen.
        e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension)
    End Sub
    ' </snippet98>


    ' Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Drawing.Rectangle)
    ' <snippet99>
    Public Sub FillEllipseRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100
        Dim rect As New Rectangle(x, y, width, height)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, rect)
    End Sub
    ' </snippet99>


    ' Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Drawing.RectangleF)
    ' <snippet100>
    Public Sub FillEllipseRectangleF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F
        Dim rect As New RectangleF(x, y, width, height)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, rect)
    End Sub
    ' </snippet100>


    ' Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet101>
    Public Sub FillEllipseInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, x, y, width, height)
    End Sub
    ' </snippet101>


    ' Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single)
    ' <snippet102>
    Public Sub FillEllipseFloat(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(redBrush, x, y, width, height)
    End Sub
    ' </snippet102>


    ' Snippet for: M:System.Drawing.Graphics.FillPath(System.Drawing.Brush,System.Drawing.Drawing2D.GraphicsPath)
    ' <snippet103>
    Public Sub FillPathEllipse(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create graphics path object and add ellipse.
        Dim graphPath As New GraphicsPath
        graphPath.AddEllipse(0, 0, 200, 100)

        ' Fill graphics path to screen.
        e.Graphics.FillPath(redBrush, graphPath)
    End Sub
    ' </snippet103>


    ' Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Drawing.Rectangle,System.Single,System.Single)
    ' <snippet104>
    Public Sub FillPieRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create rectangle for ellipse.
        Dim rect As New Rectangle(0, 0, 200, 100)

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Fill pie to screen.
        e.Graphics.FillPie(redBrush, rect, startAngle, sweepAngle)
    End Sub
    ' </snippet104>


    ' Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet105>
    Public Sub FillPieInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Create start and sweep angles.
        Dim startAngle As Integer = 0
        Dim sweepAngle As Integer = 45

        ' Fill pie to screen.
        e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub
    ' </snippet105>


    ' Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
    ' <snippet106>
    Public Sub FillPieFloat(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim redBrush As New SolidBrush(Color.Red)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Create start and sweep angles.
        Dim startAngle As Single = 0.0F
        Dim sweepAngle As Single = 45.0F

        ' Fill pie to screen.
        e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub
    ' </snippet106>


    ' Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.Point[])
    ' <snippet107>
    Public Sub FillPolygonPoint(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create points that define polygon.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw polygon to screen.
        e.Graphics.FillPolygon(blueBrush, curvePoints)
    End Sub
    ' </snippet107>


    ' Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode)
    ' <snippet108>
    Public Sub FillPolygonPointFillMode(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create points that define polygon.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Define fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Draw polygon to screen.
        e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode)
    End Sub
    ' </snippet108>


    ' Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.PointF[])
    ' <snippet109>
    Public Sub FillPolygonPointF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create points that define polygon.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Fill polygon to screen.
        e.Graphics.FillPolygon(blueBrush, curvePoints)
    End Sub
    ' </snippet109>


    ' Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode)
    ' <snippet110>
    Public Sub FillPolygonPointFFillMode(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create points that define polygon.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Define fill mode.
        Dim newFillMode As FillMode = FillMode.Winding

        ' Fill polygon to screen.
        e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode)
    End Sub
    ' </snippet110>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
