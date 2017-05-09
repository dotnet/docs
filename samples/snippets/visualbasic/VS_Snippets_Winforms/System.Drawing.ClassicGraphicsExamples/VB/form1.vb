Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
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


    ' Snippet for: M:System.Drawing.Graphics.AddMetafileComment(System.Byte[])
    ' <snippet1>
    Private Sub AddMetafileCommentBytes(ByVal e As PaintEventArgs)

        ' Create temporary graphics object for metafile
        ' creation and get handle to its device context.
        Dim newGraphics As Graphics = Me.CreateGraphics()
        Dim hdc As IntPtr = newGraphics.GetHdc()

        ' Create metafile object to record.
        Dim metaFile1 As New Metafile("SampMeta.emf", hdc)

        ' Create graphics object to record metaFile.
        Dim metaGraphics As Graphics = Graphics.FromImage(metaFile1)

        ' Draw rectangle in metaFile.
        metaGraphics.DrawRectangle(New Pen(Color.Black, 5), 0, 0, 100, 100)

        ' Create comment and add to metaFile.
        Dim metaComment As Byte() = {CByte("T"), CByte("e"), CByte("s"), _
        CByte("t")}
        metaGraphics.AddMetafileComment(metaComment)

        ' Dispose of graphics object.
        metaGraphics.Dispose()

        ' Dispose of metafile.
        metaFile1.Dispose()

        ' Release handle to scratch device context.
        newGraphics.ReleaseHdc(hdc)

        ' Dispose of scratch graphics object.
        newGraphics.Dispose()

        ' Create existing metafile object to draw.
        Dim metaFile2 As New Metafile("SampMeta.emf")

        ' Draw metaFile to screen.
        e.Graphics.DrawImage(metaFile2, New Point(0, 0))

        ' Dispose of metafile.
        metaFile2.Dispose()
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Graphics.BeginContainer
    ' <snippet2>
    Private Sub BeginContainerVoid(ByVal e As PaintEventArgs)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer()

        ' Translate world transformation.
        e.Graphics.TranslateTransform(100.0F, 100.0F)

        ' Fill translated rectangle in container with red.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 200, 200)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0, 0, _
        200, 200)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
    ' <snippet3>
    Private Sub BeginContainerRectangle(ByVal e As PaintEventArgs)

        ' Define transformation for container.
        Dim srcRect As New Rectangle(0, 0, 200, 200)
        Dim destRect As New Rectangle(100, 100, 150, 150)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel)

        ' Fill red rectangle in container.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 200, 200)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0, 0, _
        200, 200)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.RectangleF,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
    ' <snippet4>
    Private Sub BeginContainerRectangleF(ByVal e As PaintEventArgs)

        ' Define transformation for container.
        Dim srcRect As New RectangleF(0.0F, 0.0F, 200.0F, 200.0F)
        Dim destRect As New RectangleF(100.0F, 100.0F, 150.0F, 150.0F)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel)

        ' Fill red rectangle in container.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0.0F, 0.0F, _
        200.0F, 200.0F)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0.0F, 0.0F, _
        200.0F, 200.0F)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Graphics.Clear(System.Drawing.Color)
    ' <snippet5>
    Private Sub ClearColor(ByVal e As PaintEventArgs)

        ' Clear screen with teal background.
        e.Graphics.Clear(Color.Teal)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Graphics.Dispose
    ' <snippet6>
    Private Sub FromImageImage1(ByVal e As PaintEventArgs)

        ' Create image.
        Dim imageFile As Image = Image.FromFile("SampImag.jpg")

        ' Create graphics object for alteration.
        Dim newGraphics As Graphics = Graphics.FromImage(imageFile)

        ' Alter image.
        newGraphics.FillRectangle(New SolidBrush(Color.Black), 100, _
        50, 100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(imageFile, New PointF(0.0F, 0.0F))

        ' Dispose of graphics object.
        newGraphics.Dispose()
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.Rectangle,System.Single,System.Single)
    ' <snippet7>
    Private Sub DrawArcRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle to bound ellipse.
        Dim rect As New Rectangle(0, 0, 100, 200)

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.RectangleF,System.Single,System.Single)
    ' <snippet8>
    Private Sub DrawArcRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle to bound ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 100.0F, 200.0F)

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle)
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet9>
    Private Sub DrawArcInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of rectangle to bound ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 100
        Dim height As Integer = 200

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Integer = 45
        Dim sweepAngle As Integer = 270

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
    ' <snippet10>
    Private Sub DrawArcFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of rectangle to bound ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 100.0F
        Dim height As Single = 200.0F

        ' Create start and sweep angles on ellipse.
        Dim startAngle As Single = 45.0F
        Dim sweepAngle As Single = 270.0F

        ' Draw arc to screen.
        e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, _
        sweepAngle)
    End Sub
    ' </snippet10>


    ' Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point)
    ' <snippet11>
    Private Sub DrawBezierPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New Point(100, 100)
        Dim control1 As New Point(200, 10)
        Dim control2 As New Point(350, 50)
        Dim [end] As New Point(500, 100)

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, start, control1, control2, [end])
    End Sub
    ' </snippet11>


    ' Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF)
    ' <snippet12>
    Private Sub DrawBezierPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New PointF(100.0F, 100.0F)
        Dim control1 As New PointF(200.0F, 10.0F)
        Dim control2 As New PointF(350.0F, 50.0F)
        Dim [end] As New PointF(500.0F, 100.0F)

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, start, control1, control2, [end])
    End Sub
    ' </snippet12>


    ' Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
    ' <snippet13>

    ' Begin Example03.
    Private Sub DrawBezierFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create coordinates of points for curve.
        Dim startX As Single = 100.0F
        Dim startY As Single = 100.0F
        Dim controlX1 As Single = 200.0F
        Dim controlY1 As Single = 10.0F
        Dim controlX2 As Single = 350.0F
        Dim controlY2 As Single = 50.0F
        Dim endX As Single = 500.0F
        Dim endY As Single = 100.0F

        ' Draw arc to screen.
        e.Graphics.DrawBezier(blackPen, startX, startY, controlX1, _
        controlY1, controlX2, controlY2, endX, endY)
    End Sub
    ' </snippet13>


    ' Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.Point[])
    ' <snippet14>
    Private Sub DrawBeziersPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New Point(100, 100)
        Dim control1 As New Point(200, 10)
        Dim control2 As New Point(350, 50)
        Dim end1 As New Point(500, 100)
        Dim control3 As New Point(600, 150)
        Dim control4 As New Point(650, 250)
        Dim end2 As New Point(500, 300)
        Dim bezierPoints As Point() = {start, control1, control2, _
        end1, control3, control4, end2}

        ' Draw arc to screen.
        e.Graphics.DrawBeziers(blackPen, bezierPoints)
    End Sub
    ' </snippet14>


    ' Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.PointF[])
    ' <snippet15>
    Private Sub DrawBeziersPointF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create points for curve.
        Dim start As New PointF(100.0F, 100.0F)
        Dim control1 As New PointF(200.0F, 10.0F)
        Dim control2 As New PointF(350.0F, 50.0F)
        Dim end1 As New PointF(500.0F, 100.0F)
        Dim control3 As New PointF(600.0F, 150.0F)
        Dim control4 As New PointF(650.0F, 250.0F)
        Dim end2 As New PointF(500.0F, 300.0F)
        Dim bezierPoints As PointF() = {start, control1, control2, _
        end1, control3, control4, end2}

        ' Draw arc to screen.
        e.Graphics.DrawBeziers(blackPen, bezierPoints)
    End Sub
    ' </snippet15>


    ' Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[])
    ' <snippet16>
    Private Sub DrawClosedCurvePoint(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Draw closed curve to screen.
        e.Graphics.DrawClosedCurve(greenPen, curvePoints)
    End Sub
    ' </snippet16>


    ' Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single,System.Drawing.Drawing2D.FillMode)
    ' <snippet17>
    Private Sub DrawClosedCurvePointTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create tension and fill mode.
        Dim tension As Single = 1.0F
        Dim aFillMode As FillMode = FillMode.Alternate

        ' Draw closed curve to screen.
        e.Graphics.DrawClosedCurve(greenPen, curvePoints, tension, _
        aFillMode)
    End Sub
    ' </snippet17>


    ' Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[])
    ' <snippet18>
    Private Sub DrawClosedCurvePointF(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Draw closed curve to screen.
        e.Graphics.DrawClosedCurve(greenPen, curvePoints)
    End Sub
    ' </snippet18>


    ' Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single,System.Drawing.Drawing2D.FillMode)
    ' <snippet19>
    Private Sub DrawClosedCurvePointFTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create tension and fill mode.
        Dim tension As Single = 1.0F
        Dim aFillMode As FillMode = FillMode.Alternate

        ' Draw closed curve to screen.
        e.Graphics.DrawClosedCurve(greenPen, curvePoints, tension, _
        aFillMode)
    End Sub
    ' </snippet19>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[])
    ' <snippet20>
    Private Sub DrawCurvePoint(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints)
    End Sub
    ' </snippet20>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Int32,System.Int32,System.Single)
    ' <snippet21>
    Private Sub DrawCurvePointSegmentTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create offset, number of segments, and tension.
        Dim offset As Integer = 2
        Dim numSegments As Integer = 4
        Dim tension As Single = 1.0F

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments, _
        tension)
    End Sub
    ' </snippet21>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single)
    ' <snippet22>
    Private Sub DrawCurvePointTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New Point(50, 50)
        Dim point2 As New Point(100, 25)
        Dim point3 As New Point(200, 5)
        Dim point4 As New Point(250, 50)
        Dim point5 As New Point(300, 100)
        Dim point6 As New Point(350, 200)
        Dim point7 As New Point(250, 250)
        Dim curvePoints As Point() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create tension.
        Dim tension As Single = 1.0F

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, tension)
    End Sub
    ' </snippet22>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[])
    ' <snippet23>
    Private Sub DrawCurvePointF(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints)
    End Sub
    ' </snippet23>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32)
    ' <snippet24>
    Private Sub DrawCurvePointFSegments(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create offset and number of segments.
        Dim offset As Integer = 2
        Dim numSegments As Integer = 4

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments)
    End Sub
    ' </snippet24>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32,System.Single)
    ' <snippet25>
    Private Sub DrawCurvePointFSegmentTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create offset, number of segments, and tension.
        Dim offset As Integer = 2
        Dim numSegments As Integer = 4
        Dim tension As Single = 1.0F

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments, _
        tension)
    End Sub
    ' </snippet25>


    ' Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single)
    ' <snippet26>
    Private Sub DrawCurvePointFTension(ByVal e As PaintEventArgs)

        ' Create pens.
        Dim redPen As New Pen(Color.Red, 3)
        Dim greenPen As New Pen(Color.Green, 3)

        ' Create points that define curve.
        Dim point1 As New PointF(50.0F, 50.0F)
        Dim point2 As New PointF(100.0F, 25.0F)
        Dim point3 As New PointF(200.0F, 5.0F)
        Dim point4 As New PointF(250.0F, 50.0F)
        Dim point5 As New PointF(300.0F, 100.0F)
        Dim point6 As New PointF(350.0F, 200.0F)
        Dim point7 As New PointF(250.0F, 250.0F)
        Dim curvePoints As PointF() = {point1, point2, point3, point4, _
        point5, point6, point7}

        ' Draw lines between original points to screen.
        e.Graphics.DrawLines(redPen, curvePoints)

        ' Create tension.
        Dim tension As Single = 1.0F

        ' Draw curve to screen.
        e.Graphics.DrawCurve(greenPen, curvePoints, tension)
    End Sub
    ' </snippet26>


    ' Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.Rectangle)
    ' <snippet27>
    Private Sub DrawEllipseRectangle(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New Rectangle(0, 0, 200, 100)

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, rect)
    End Sub
    ' </snippet27>


    ' Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.RectangleF)
    ' <snippet28>
    Private Sub DrawEllipseRectangleF(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create rectangle for ellipse.
        Dim rect As New RectangleF(0.0F, 0.0F, 200.0F, 100.0F)

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, rect)
    End Sub
    ' </snippet28>


    ' Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet29>
    Private Sub DrawEllipseInt(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 100

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, x, y, width, height)
    End Sub
    ' </snippet29>


    ' Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
    ' <snippet30>
    Private Sub DrawEllipseFloat(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create location and size of ellipse.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 100.0F

        ' Draw ellipse to screen.
        e.Graphics.DrawEllipse(blackPen, x, y, width, height)
    End Sub
    ' </snippet30>


    ' Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Drawing.Rectangle)
    ' <snippet31>
    Private Sub DrawIconRectangle(ByVal e As PaintEventArgs)

        ' Create icon.
        Dim newIcon As New Icon("SampIcon.ico")

        ' Create rectangle for icon.
        Dim rect As New Rectangle(100, 100, 200, 200)

        ' Draw icon to screen.
        e.Graphics.DrawIcon(newIcon, rect)
    End Sub
    ' </snippet31>


    ' Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Int32,System.Int32)
    ' <snippet32>
    Private Sub DrawIconInt(ByVal e As PaintEventArgs)

        ' Create icon.
        Dim newIcon As New Icon("SampIcon.ico")

        ' Create coordinates for upper-left corner of icon.
        Dim x As Integer = 100
        Dim y As Integer = 100

        ' Draw icon to screen.
        e.Graphics.DrawIcon(newIcon, x, y)
    End Sub
    ' </snippet32>


    ' Snippet for: M:System.Drawing.Graphics.DrawIconUnstretched(System.Drawing.Icon,System.Drawing.Rectangle)
    ' <snippet33>
    Private Sub DrawIconUnstretchedRectangle(ByVal e As PaintEventArgs)

        ' Create icon.
        Dim newIcon As New Icon("SampIcon.ico")

        ' Create rectangle for icon.
        Dim rect As New Rectangle(100, 100, 200, 200)

        ' Draw icon to screen.
        e.Graphics.DrawIconUnstretched(newIcon, rect)
    End Sub
    ' </snippet33>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point)
    ' <snippet34>
    Private Sub DrawImagePoint(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create Point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub
    ' </snippet34>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[])
    ' <snippet35>
    Private Sub DrawImagePara(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(550, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara As Point() = {ulCorner, urCorner, llCorner}

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara)
    End Sub
    ' </snippet35>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
    ' <snippet36>
    Private Sub DrawImageParaRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(325, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara As Point() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara, srcRect, units)
    End Sub
    ' </snippet36>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
    ' <snippet37>
    Private Sub DrawImageParaRectAttrib(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner1 As New Point(100, 100)
        Dim urCorner1 As New Point(325, 100)
        Dim llCorner1 As New Point(150, 250)
        Dim destPara1 As Point() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New Point(325, 100)
        Dim urCorner2 As New Point(550, 100)
        Dim llCorner2 As New Point(375, 250)
        Dim destPara2 As Point() = {ulCorner2, urCorner2, llCorner2}

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
        imageAttr)
    End Sub
    ' </snippet37>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
    ' <snippet38>
    Private Function DrawImageCallback1(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaRectAttribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback1)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(550, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara1 As Point() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New Point(325, 100)
        Dim urCorner2 As New Point(550, 100)
        Dim llCorner2 As New Point(375, 250)
        Dim destPara2 As Point() = {ulCorner2, urCorner2, llCorner2}

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet38>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
    ' <snippet39>
    Private Function DrawImageCallback2(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaRectAttribAbortData(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback2)
        Dim imageCallbackData As Integer = 1

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner As New Point(100, 100)
        Dim urCorner As New Point(550, 100)
        Dim llCorner As New Point(150, 250)
        Dim destPara1 As Point() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New Point(325, 100)
        Dim urCorner2 As New Point(550, 100)
        Dim llCorner2 As New Point(375, 250)
        Dim destPara2 As Point() = {ulCorner2, urCorner2, llCorner2}

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback, imageCallbackData)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet39>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF)
    ' <snippet40>
    Private Sub DrawImagePointF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create point for upper-left corner of image.
        Dim ulCorner As New PointF(100.0F, 100.0F)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub
    ' </snippet40>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[])
    ' <snippet41>
    Private Sub DrawImageParaF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New PointF(100.0F, 100.0F)
        Dim urCorner As New PointF(550.0F, 100.0F)
        Dim llCorner As New PointF(150.0F, 250.0F)
        Dim destPara As PointF() = {ulCorner, urCorner, llCorner}

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara)
    End Sub
    ' </snippet41>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
    ' <snippet42>
    Private Sub DrawImageParaFRectF(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing image.
        Dim ulCorner As New PointF(100.0F, 100.0F)
        Dim urCorner As New PointF(550.0F, 100.0F)
        Dim llCorner As New PointF(150.0F, 250.0F)
        Dim destPara As PointF() = {ulCorner, urCorner, llCorner}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destPara, srcRect, units)
    End Sub
    ' </snippet42>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
    ' <snippet43>
    Private Sub DrawImageParaFRectFAttrib(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner1 As New PointF(100.0F, 100.0F)
        Dim urCorner1 As New PointF(325.0F, 100.0F)
        Dim llCorner1 As New PointF(150.0F, 250.0F)
        Dim destPara1 As PointF() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New PointF(325.0F, 100.0F)
        Dim urCorner2 As New PointF(550.0F, 100.0F)
        Dim llCorner2 As New PointF(375.0F, 250.0F)
        Dim destPara2 As PointF() = {ulCorner2, urCorner2, llCorner2}

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
        imageAttr)
    End Sub
    ' </snippet43>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
    ' <snippet44>
    Private Function DrawImageCallback3(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaFRectAttribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback3)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner1 As New PointF(100.0F, 100.0F)
        Dim urCorner1 As New PointF(325.0F, 100.0F)
        Dim llCorner1 As New PointF(150.0F, 250.0F)
        Dim destPara1 As PointF() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New PointF(325.0F, 100.0F)
        Dim urCorner2 As New PointF(550.0F, 100.0F)
        Dim llCorner2 As New PointF(375.0F, 250.0F)
        Dim destPara2 As PointF() = {ulCorner2, urCorner2, llCorner2}

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet44>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
    ' <snippet45>
    Private Function DrawImageCallback4(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageParaFRectAttribAbortData(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback4)
        Dim imageCallbackData As Integer = 1

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create parallelogram for drawing original image.
        Dim ulCorner1 As New PointF(100.0F, 100.0F)
        Dim urCorner1 As New PointF(325.0F, 100.0F)
        Dim llCorner1 As New PointF(150.0F, 250.0F)
        Dim destPara1 As PointF() = {ulCorner1, urCorner1, llCorner1}

        ' Create rectangle for source image.
        Dim srcRect As New RectangleF(50.0F, 50.0F, 150.0F, 150.0F)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Create parallelogram for drawing adjusted image.
        Dim ulCorner2 As New PointF(325.0F, 100.0F)
        Dim urCorner2 As New PointF(550.0F, 100.0F)
        Dim llCorner2 As New PointF(375.0F, 250.0F)
        Dim destPara2 As PointF() = {ulCorner2, urCorner2, llCorner2}

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destPara1, srcRect, units)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, _
            imageAttr, imageCallback, imageCallbackData)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet45>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle)
    ' <snippet46>
    Private Sub DrawImageRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect)
    End Sub
    ' </snippet46>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
    ' <snippet47>
    Private Sub DrawImageRectRect(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Create rectangle for source image.
        Dim srcRect As New Rectangle(50, 50, 150, 150)
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, srcRect, units)
    End Sub
    ' </snippet47>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit)
    ' <snippet48>
    Private Sub DrawImageRect4Int(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim width As Integer = 150
        Dim height As Integer = 150
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, x, y, width, height, _
        units)
    End Sub
    ' </snippet48>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
    ' <snippet49>
    Private Sub DrawImageRect4IntAtrrib(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying original image.
        Dim destRect1 As New Rectangle(100, 25, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim width As Integer = 150
        Dim height As Integer = 150
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, _
        units)

        ' Create rectangle for adjusted image.
        Dim destRect2 As New Rectangle(100, 175, 450, 150)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)

        ' Draw adjusted image to screen.
        e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, _
        units, imageAttr)
    End Sub
    ' </snippet49>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
    ' <snippet50>
    Private Function DrawImageCallback5(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageRect4IntAtrribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback5)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying original image.
        Dim destRect1 As New Rectangle(100, 25, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim width As Integer = 150
        Dim height As Integer = 150
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, _
        units)

        ' Create rectangle for adjusted image.
        Dim destRect2 As New Rectangle(100, 175, 450, 150)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, _
            height, units, imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet50>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
    ' <snippet51>
    Private Function DrawImageCallback6(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageRect4IntAtrribAbortData(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback6)
        Dim imageCallbackData As New IntPtr(1)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying original image.
        Dim destRect1 As New Rectangle(100, 25, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim width As Integer = 150
        Dim height As Integer = 150
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw original image to screen.
        e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, _
        units)

        ' Create rectangle for adjusted image.
        Dim destRect2 As New Rectangle(100, 175, 450, 150)

        ' Create image attributes and set large gamma.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(4.0F)
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, _
            height, units, imageAttr, imageCallback, imageCallbackData)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet51>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit)
    ' <snippet52>
    Private Sub DrawImageRect4Float(ByVal e As PaintEventArgs)

        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(100, 100, 450, 150)

        ' Create coordinates of rectangle for source image.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 150.0F
        Dim height As Single = 150.0F
        Dim units As GraphicsUnit = GraphicsUnit.Pixel

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, destRect, x, y, width, height, _
        units)
    End Sub
    ' </snippet52>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
    ' <snippet53>
    Private Sub DrawImageRect4FloatAttrib(ByVal e As PaintEventArgs)

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
        e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, _
        units, imageAttr)
    End Sub
    ' </snippet53>


    ' Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
    ' <snippet54>
    Private Function DrawImageCallback7(ByVal callBackData As IntPtr) As Boolean

        ' Test for call that passes callBackData parameter.
        If callBackData.Equals(IntPtr.Zero) Then

            ' If no callBackData passed, abort DrawImage method.
            Return True
        Else

            ' If callBackData passed, continue DrawImage method.
            Return False
        End If
    End Function
    Private Sub DrawImageRect4FloatAttribAbort(ByVal e As PaintEventArgs)

        ' Create callback method.
        Dim imageCallback As New _
        Graphics.DrawImageAbort(AddressOf DrawImageCallback7)

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
        Try

            ' Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, _
            height, units, imageAttr, imageCallback)
        Catch ex As Exception
            e.Graphics.DrawString(ex.ToString(), New Font("Arial", 8), _
            Brushes.Black, New PointF(0, 0))
        End Try
    End Sub
    ' </snippet54>

    ' Snippet for: T:System.Drawing.Image
    ' <snippet55>
    Private Sub ImageExampleForm_Paint _
        (ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs) _
        Handles MyBase.Paint


        ' Create image.
        Dim newImage As Image = Image.FromFile("SampImag.jpg")

        ' Create Point for upper-left corner of image.
        Dim ulCorner As New Point(100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(newImage, ulCorner)
    End Sub
    ' </snippet55>
 

   
    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
