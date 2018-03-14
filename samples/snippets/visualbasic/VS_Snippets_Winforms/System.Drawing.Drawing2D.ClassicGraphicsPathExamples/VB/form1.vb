Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D


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


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddArc(System.Drawing.Rectangle,System.Single,System.Single)
    ' <snippet1>
    Public Sub AddArcExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' Set up and call AddArc, and close the figure.
        Dim rect As New Rectangle(20, 20, 50, 100)
        myPath.StartFigure()
        myPath.AddArc(rect, 0, 180)
        myPath.CloseFigure()

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 3), myPath)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddBezier(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet2>
    Public Sub AddBezierExample(ByVal e As PaintEventArgs)

        ' Create a new Path.
        Dim myPath As New GraphicsPath

        ' Call AddBezier.
        myPath.StartFigure()
        myPath.AddBezier(50, 50, 70, 0, 100, 120, 150, 50)

        ' Close the curve.
        myPath.CloseFigure()

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 2), myPath)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddBeziers(System.Drawing.Point[])
    ' <snippet3>
    Public Sub AddBeziersExample(ByVal e As PaintEventArgs)

        ' Adds two Bezier curves.
        Dim myArray As Point() = {New Point(20, 100), New Point(40, 75), _
        New Point(60, 125), New Point(80, 100), New Point(100, 50), _
        New Point(120, 150), New Point(140, 100)}
        Dim myPath As New GraphicsPath
        myPath.AddBeziers(myArray)
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddClosedCurve(System.Drawing.Point[],System.Single)
    ' <snippet4>
    Public Sub AddClosedCurveExample(ByVal e As PaintEventArgs)

        ' Creates a symetrical, closed curve.
        Dim myArray As Point() = {New Point(20, 100), New Point(40, 150), _
        New Point(60, 125), New Point(40, 100), New Point(60, 75), _
        New Point(40, 50)}
        Dim myPath As New GraphicsPath
        myPath.AddClosedCurve(myArray, 0.5F)
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddCurve(System.Drawing.Point[],System.Int32,System.Int32,System.Single)
    ' <snippet5>
    Public Sub AddCurveExample(ByVal e As PaintEventArgs)

        ' Create some points.
        Dim point1 As New Point(20, 20)
        Dim point2 As New Point(40, 0)
        Dim point3 As New Point(60, 40)
        Dim point4 As New Point(80, 20)

        ' Create an array of the points.
        Dim curvePoints As Point() = {point1, point2, point3, point4}

        ' Create a GraphicsPath object and add a curve.
        Dim myPath As New GraphicsPath
        myPath.AddCurve(curvePoints, 0, 3, 0.8F)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddEllipse(System.Drawing.Rectangle)
    ' <snippet6>
    Public Sub AddEllipseExample(ByVal e As PaintEventArgs)

        ' Create a path and add an ellipse.
        Dim myEllipse As New Rectangle(20, 20, 100, 50)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(myEllipse)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddLine(System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet7>
    Public Sub AddLineExample(ByVal e As PaintEventArgs)

        ' Create a path and add a symetrical triangle using AddLine.
        Dim myPath As New GraphicsPath
        myPath.AddLine(30, 30, 60, 60)
        myPath.AddLine(60, 60, 0, 60)
        myPath.AddLine(0, 60, 30, 30)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddLines(System.Drawing.Point[])
    ' <snippet8>
    Public Sub AddLinesExample(ByVal e As PaintEventArgs)

        'Create a symetrical triangle using an array of points.
        Dim myArray As Point() = {New Point(30, 30), New Point(60, 60), _
        New Point(0, 60), New Point(30, 30)}
        Dim myPath As New GraphicsPath
        myPath.AddLines(myArray)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPath(System.Drawing.Drawing2D.GraphicsPath,System.Boolean)
    ' <snippet9>
    Public Sub AddPathExample(ByVal e As PaintEventArgs)

        ' Creates a symetrical triangle and adds an inverted triangle.

        ' Create the first path - right side up triangle.
        Dim myArray As Point() = {New Point(30, 30), New Point(60, 60), _
        New Point(0, 60), New Point(30, 30)}
        Dim myPath As New GraphicsPath
        myPath.AddLines(myArray)

        ' Create the second path - inverted triangle.
        Dim myArray2 As Point() = {New Point(30, 30), New Point(0, 0), _
        New Point(60, 0), New Point(30, 30)}
        Dim myPath2 As New GraphicsPath
        myPath2.AddLines(myArray2)

        ' Add the second path to the first path.
        myPath.AddPath(myPath2, True)

        ' Draw the combined path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPie(System.Int32,System.Int32,System.Int32,System.Int32,System.Single,System.Single)
    ' <snippet10>
    Public Sub AddPieExample(ByVal e As PaintEventArgs)

        ' Create a pie slice of a circle using the AddPie method.
        Dim myPath As New GraphicsPath
        myPath.AddPie(20, 20, 70, 70, -45, 90)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet10>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPolygon(System.Drawing.Point[])
    ' <snippet11>
    Public Sub AddPolygonExample(ByVal e As PaintEventArgs)

        ' Create an array of points.
        Dim myArray As Point() = {New Point(23, 20), New Point(40, 10), _
        New Point(57, 20), New Point(50, 40), New Point(30, 40)}

        ' Create a GraphicsPath object and add a polygon.
        Dim myPath As New GraphicsPath
        myPath.AddPolygon(myArray)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet11>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddRectangle(System.Drawing.Rectangle)
    ' <snippet12>
    Public Sub AddRectangleExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object and add a rectangle to it.
        Dim myPath As New GraphicsPath
        Dim pathRect As New Rectangle(20, 20, 100, 200)
        myPath.AddRectangle(pathRect)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet12>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddRectangles(System.Drawing.Rectangle[])
    ' <snippet13>
    Public Sub AddRectanglesExample(ByVal e As PaintEventArgs)

        ' Adds a pattern of rectangles to a GraphicsPath object.
        Dim myPath As New GraphicsPath
        Dim pathRects As Rectangle() = {New Rectangle(20, 20, 100, 200), _
        New Rectangle(40, 40, 120, 220), New Rectangle(60, 60, 240, 140)}
        myPath.AddRectangles(pathRects)

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet13>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddString(System.String,System.Drawing.FontFamily,System.Int32,System.Single,System.Drawing.Point,System.Drawing.StringFormat)
    ' <snippet14>
    Public Sub AddStringExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' Set up all the string parameters.
        Dim stringText As String = "Sample Text"
        Dim family As New FontFamily("Arial")
        Dim myfontStyle As Integer = CInt(FontStyle.Italic)
        Dim emSize As Integer = 26
        Dim origin As New Point(20, 20)
        Dim format As StringFormat = StringFormat.GenericDefault

        ' Add the string to the path.
        myPath.AddString(stringText, family, myfontStyle, emSize, _
        origin, format)

        'Draw the path to the screen.
        e.Graphics.FillPath(Brushes.Black, myPath)
    End Sub
    ' </snippet14>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.ClearMarkers
    ' <snippet15>
    Public Sub ClearMarkersExample(ByVal e As PaintEventArgs)

        ' Set several markers in a path.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)
        myPath.SetMarkers()
        myPath.AddLine(New Point(100, 100), New Point(200, 100))
        Dim rect As New Rectangle(200, 0, 100, 200)
        myPath.AddRectangle(rect)
        myPath.SetMarkers()
        myPath.AddLine(New Point(250, 200), New Point(250, 300))
        myPath.SetMarkers()

        ' Clear the markers.
        myPath.ClearMarkers()

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)
    End Sub
    ' </snippet15>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Clone
    ' <snippet16>
    Public Sub CloneExample(ByVal e As PaintEventArgs)

        ' Set several markers in a path.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)
        myPath.AddLine(New Point(100, 100), New Point(200, 100))
        Dim rect As New Rectangle(200, 0, 100, 200)
        myPath.AddRectangle(rect)
        myPath.AddLine(New Point(250, 200), New Point(250, 300))

        ' Draw the path to the screen.
        Dim myPen As New Pen(Color.Black, 2)
        e.Graphics.DrawPath(myPen, myPath)

        ' Clone a copy of myPath.
        Dim myPath2 As GraphicsPath = CType(myPath.Clone(), GraphicsPath)

        ' Draw the path to the screen.
        Dim myPen2 As New Pen(Color.Red, 4)
        e.Graphics.DrawPath(myPen2, myPath2)
    End Sub
    ' </snippet16>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.CloseAllFigures
    ' <snippet17>
    Public Sub CloseAllFiguresExample(ByVal e As PaintEventArgs)

        ' Create a path containing several open-ended figures.
        Dim myPath As New GraphicsPath
        myPath.StartFigure()
        myPath.AddLine(New Point(10, 10), New Point(150, 10))
        myPath.AddLine(New Point(150, 10), New Point(10, 150))
        myPath.StartFigure()
        myPath.AddArc(200, 200, 100, 100, 0, 90)
        myPath.StartFigure()
        Dim point1 As New Point(300, 300)
        Dim point2 As New Point(400, 325)
        Dim point3 As New Point(400, 375)
        Dim point4 As New Point(300, 400)
        Dim points As Point() = {point1, point2, point3, point4}
        myPath.AddCurve(points)

        ' close all the figures.
        myPath.CloseAllFigures()

        ' Draw the path to the screen.
        e.Graphics.DrawPath(New Pen(Color.Black, 3), myPath)
    End Sub
    ' </snippet17>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.CloseFigure
    ' <snippet18>
    Public Sub CloseFigureExample(ByVal e As PaintEventArgs)

        ' Create a path consisting of two, open-ended lines and close

        ' the lines using CloseFigure.
        Dim myPath As New GraphicsPath
        myPath.StartFigure()
        myPath.AddLine(New Point(10, 10), New Point(200, 10))
        myPath.AddLine(New Point(200, 10), New Point(200, 200))
        myPath.CloseFigure()

        ' Draw the path to the screen.
        e.Graphics.DrawPath(Pens.Black, myPath)
    End Sub
    ' </snippet18>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Flatten(System.Drawing.Drawing2D.Matrix,System.Single)
    ' <snippet19>
    Public Sub FlattenExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(0, 10)
        Dim point1 As New Point(20, 100)
        Dim point2 As New Point(70, 10)
        Dim point3 As New Point(130, 200)
        Dim point4 As New Point(180, 100)
        Dim points As Point() = {point1, point2, point3, point4}
        myPath.AddCurve(points)
        e.Graphics.DrawPath(New Pen(Color.Black, 2), myPath)
        myPath.Flatten(translateMatrix, 10.0F)
        e.Graphics.DrawPath(New Pen(Color.Red, 1), myPath)
    End Sub
    'FlattenExample
    ' </snippet19>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.GetBounds
    ' <snippet20>
    Public Sub GetBoundsExample(ByVal e As PaintEventArgs)

        ' Create path number 1 and a Pen for drawing.
        Dim myPath As New GraphicsPath
        Dim pathPen As New Pen(Color.Black, 1)

        ' Add an Ellipse to the path and Draw it (circle in start

        ' position).
        myPath.AddEllipse(20, 20, 100, 100)
        e.Graphics.DrawPath(pathPen, myPath)

        ' Get the path bounds for Path number 1 and draw them.
        Dim boundRect As RectangleF = myPath.GetBounds()
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), boundRect.X, _
        boundRect.Y, boundRect.Height, boundRect.Width)

        ' Create a second graphics path and a wider Pen.
        Dim myPath2 As New GraphicsPath
        Dim pathPen2 As New Pen(Color.Black, 10)

        ' Create a new ellipse with a width of 10.
        myPath2.AddEllipse(150, 20, 100, 100)
        myPath2.Widen(pathPen2)
        e.Graphics.FillPath(Brushes.Black, myPath2)

        ' Get the second path bounds.
        Dim boundRect2 As RectangleF = myPath2.GetBounds()

        ' Show the bounds in a message box.
        e.Graphics.DrawString("Rectangle2 Bounds: " + _
        boundRect2.ToString(), New Font("Arial", 8), Brushes.Black, _
        20, 150)

        ' Draw the bounding rectangle.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), boundRect2.X, _
        boundRect2.Y, boundRect2.Height, boundRect2.Width)
    End Sub
    ' </snippet20>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.GetLastPoint
    ' <snippet21>
    Public Sub GetLastPointExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddLine(20, 20, 100, 20)
        Dim lastPoint As PointF = myPath.GetLastPoint()
        If lastPoint.IsEmpty = False Then
            Dim lastPointXString As String = lastPoint.X.ToString()
            Dim lastPointYString As String = lastPoint.Y.ToString()
            MessageBox.Show((lastPointXString + ", " + lastPointYString))
        Else
            MessageBox.Show("lastPoint is empty")
        End If
    End Sub
    ' </snippet21>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.IsOutlineVisible(System.Int32,System.Int32,System.Drawing.Pen,System.Drawing.Graphics)
    ' <snippet22>
    Public Sub IsOutlineVisibleExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(20, 20, 100, 100)
        myPath.AddRectangle(rect)
        Dim testPen As New Pen(Color.Black, 20)
        myPath.Widen(testPen)
        e.Graphics.FillPath(Brushes.Black, myPath)
        Dim visible As Boolean = myPath.IsOutlineVisible(100, 50, _
        testPen, e.Graphics)
        MessageBox.Show(("visible = " + visible.ToString()))
    End Sub
    ' </snippet22>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.IsVisible(System.Int32,System.Int32,System.Drawing.Graphics)
    ' <snippet23>
    Public Sub IsVisibleExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 100)
        Dim visible As Boolean = myPath.IsVisible(50, 50, e.Graphics)
        MessageBox.Show(visible.ToString())
    End Sub
    ' </snippet23>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Reset
    ' <snippet24>
    Public Sub GraphicsPathResetExample(ByVal e As PaintEventArgs)
        Dim myFont As New Font("Arial", 8)

        ' Create a path and add a line, an ellipse, and an arc.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(100, 100))
        myPath.AddEllipse(100, 100, 200, 250)
        myPath.AddArc(300, 250, 100, 100, 0, 90)

        ' Draw the pre-reset points array to the screen.
        DrawPointsHelper1(e, myPath.PathPoints, 20)

        ' Reset the path.
        myPath.Reset()

        ' See if any points remain.
        If myPath.PointCount > 0 Then

            ' Draw the post-reset points array to the screen.
            DrawPointsHelper1(e, myPath.PathPoints, 150)

            ' If there are no points, say so.
        Else
            e.Graphics.DrawString("No Points", myFont, Brushes.Black, _
            150, 20)
        End If
    End Sub

    ' A helper function used by GraphicsPathResetExample to draw points.
    Public Sub DrawPointsHelper1(ByVal e As PaintEventArgs, _
    ByVal pathPoints() As PointF, ByVal xOffset As Integer)
        Dim y As Integer = 20
        Dim myFont As New Font("Arial", 8)
        Dim i As Integer
        For i = 0 To pathPoints.Length - 1
            e.Graphics.DrawString(pathPoints(i).X.ToString() + _
            ", " + pathPoints(i).Y.ToString(), myFont, Brushes.Black, _
            xOffset, y)
            y += 20
        Next i
    End Sub
    ' </snippet24>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Reverse
    ' <snippet25>
    Public Sub GraphicsPathReverseExample(ByVal e As PaintEventArgs)

        ' Create a path and add a line, ellipse, and arc.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(100, 100))
        myPath.AddEllipse(100, 100, 200, 250)
        myPath.AddArc(300, 250, 100, 100, 0, 90)

        ' Draw the first set of points to the screen.
        DrawPointsHelper2(e, myPath.PathPoints, 20)

        ' Call GraphicsPath.Reverse.
        myPath.Reverse()

        ' Draw the reversed set of points to the screen.
        DrawPointsHelper2(e, myPath.PathPoints, 150)
    End Sub

    ' A helper function used by GraphicsPathReverseExample to draw points.
    Public Sub DrawPointsHelper2(ByVal e As PaintEventArgs, _
    ByVal pathPoints() As PointF, ByVal xOffset As Integer)
        Dim y As Integer = 20
        Dim myFont As New Font("Arial", 8)
        Dim i As Integer
        For i = 0 To pathPoints.Length - 1
            e.Graphics.DrawString(pathPoints(i).X.ToString() + _
            ", " + pathPoints(i).Y.ToString(), myFont, Brushes.Black, _
            xOffset, y)
            y += 20
        Next i
    End Sub
    ' </snippet25>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.SetMarkers
    ' <snippet26>
    Public Sub SetMarkersExample(ByVal e As PaintEventArgs)

        ' Create a path and set two markers.
        Dim myPath As New GraphicsPath
        myPath.AddLine(New Point(0, 0), New Point(50, 50))
        myPath.SetMarkers()
        Dim rect As New Rectangle(50, 50, 50, 50)
        myPath.AddRectangle(rect)
        myPath.SetMarkers()
        myPath.AddEllipse(100, 100, 100, 50)

        ' Draw the path to screen.
        e.Graphics.DrawPath(New Pen(Color.Black, 2), myPath)
    End Sub
    ' </snippet26>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.StartFigure
    ' <snippet27>
    Public Sub StartFigureExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath object.
        Dim myPath As New GraphicsPath

        ' First set of figures.
        myPath.StartFigure()
        myPath.AddArc(10, 10, 50, 50, 0, 270)
        myPath.AddLine(New Point(50, 0), New Point(100, 50))
        myPath.AddArc(50, 100, 75, 75, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddArc(100, 10, 50, 50, 0, 270)

        ' Second set of figures.
        myPath.StartFigure()
        myPath.AddArc(10, 200, 50, 50, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddLine(New Point(60, 200), New Point(110, 250))
        myPath.AddArc(50, 300, 75, 75, 0, 270)
        myPath.CloseFigure()
        myPath.StartFigure()
        myPath.AddArc(100, 200, 50, 50, 0, 270)

        ' Draw the path to the screen.
        e.Graphics.DrawPath(New Pen(Color.Black), myPath)
    End Sub
    ' </snippet27>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Transform(System.Drawing.Drawing2D.Matrix)
    ' <snippet28>
    Public Sub TransformExample(ByVal e As PaintEventArgs)

        ' Create a path and add and ellipse.
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 200)

        ' Draw the starting position to screen.
        e.Graphics.DrawPath(Pens.Black, myPath)

        ' Move the ellipse 100 points to the right.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(100, 0)
        myPath.Transform(translateMatrix)

        ' Draw the transformed ellipse to the screen.
        e.Graphics.DrawPath(New Pen(Color.Red, 2), myPath)
    End Sub
    ' </snippet28>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Warp(System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.WarpMode,System.Single)
    ' <snippet29>
    Public Sub WarpExample(ByVal e As PaintEventArgs)

        ' Create a path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim srcRect As New RectangleF(0, 0, 100, 200)
        myPath.AddRectangle(srcRect)

        ' Draw the source path (rectangle)to the screen.
        e.Graphics.DrawPath(Pens.Black, myPath)

        ' Create a destination for the warped rectangle.
        Dim point1 As New PointF(200, 200)
        Dim point2 As New PointF(400, 250)
        Dim point3 As New PointF(220, 400)
        Dim destPoints As PointF() = {point1, point2, point3}

        ' Create a translation matrix.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(100, 0)

        ' Warp the source path (rectangle).
        myPath.Warp(destPoints, srcRect, translateMatrix, _
        WarpMode.Perspective, 0.5F)

        ' Draw the warped path (rectangle) to the screen.
        e.Graphics.DrawPath(New Pen(Color.Red), myPath)
    End Sub
    ' </snippet29>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Widen(System.Drawing.Pen,System.Drawing.Drawing2D.Matrix,System.Single)
    ' <snippet30>
    Public Sub WidenExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        myPath.AddEllipse(0, 0, 100, 100)
        myPath.AddEllipse(100, 0, 100, 100)
        e.Graphics.DrawPath(Pens.Black, myPath)
        Dim widenPen As New Pen(Color.Black, 10)
        Dim widenMatrix As New Matrix
        widenMatrix.Translate(50, 50)
        myPath.Widen(widenPen, widenMatrix, 1.0F)
        ' Sets tension for curves.
        e.Graphics.FillPath(New SolidBrush(Color.Red), myPath)
    End Sub
    ' </snippet30>

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        GraphicsPathResetExample(e)
    End Sub

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
