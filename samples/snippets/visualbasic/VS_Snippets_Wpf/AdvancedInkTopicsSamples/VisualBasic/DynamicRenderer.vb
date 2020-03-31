'<Snippet19>
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Input
Imports System.Windows.Ink
'</Snippet19>

'<Snippet1>
' A StylusPlugin that renders ink with a linear gradient brush effect.
Class CustomDynamicRenderer
    Inherits DynamicRenderer
    <ThreadStatic()> _
    Private Shared brush As Brush = Nothing

    <ThreadStatic()> _
    Private Shared pen As Pen = Nothing

    Private prevPoint As Point


    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput)
        ' Allocate memory to store the previous point to draw from.
        prevPoint = New Point(Double.NegativeInfinity, Double.NegativeInfinity)
        MyBase.OnStylusDown(rawStylusInput)

    End Sub


    Protected Overrides Sub OnDraw(ByVal drawingContext As DrawingContext, _
                                   ByVal stylusPoints As StylusPointCollection, _
                                   ByVal geometry As Geometry, _
                                   ByVal fillBrush As Brush)

        ' Create a new Brush, if necessary.
        If brush Is Nothing Then
            brush = New LinearGradientBrush(Colors.Red, Colors.Blue, 20.0)
        End If

        ' Create a new Pen, if necessary.
        If pen Is Nothing Then
            pen = New Pen(brush, 2.0)
        End If

        ' Draw linear gradient ellipses between 
        ' all the StylusPoints that have come in.
        Dim i As Integer
        For i = 0 To stylusPoints.Count - 1

            Dim pt As Point = CType(stylusPoints(i), Point)
            Dim v As Vector = Point.Subtract(prevPoint, pt)

            ' Only draw if we are at least 4 units away 
            ' from the end of the last ellipse. Otherwise, 
            ' we're just redrawing and wasting cycles.
            If v.Length > 4 Then
                ' Set the thickness of the stroke based 
                ' on how hard the user pressed.
                Dim radius As Double = stylusPoints(i).PressureFactor * 10.0
                drawingContext.DrawEllipse(brush, pen, pt, radius, radius)
                prevPoint = pt
            End If
        Next i

    End Sub
End Class
'</Snippet1>

'<Snippet2>
' A class for rendering custom strokes
Class CustomStroke
    Inherits Stroke
    Private brush As Brush
    Private pen As Pen


    Public Sub New(ByVal stylusPoints As StylusPointCollection)
        MyBase.New(stylusPoints)
        ' Create the Brush and Pen used for drawing.
        brush = New LinearGradientBrush(Colors.Red, Colors.Blue, 20.0)
        pen = New Pen(brush, 2.0)

    End Sub


    Protected Overrides Sub DrawCore(ByVal drawingContext As DrawingContext, _
                                     ByVal drawingAttributes As DrawingAttributes)

        ' Allocate memory to store the previous point to draw from.
        Dim prevPoint As New Point(Double.NegativeInfinity, Double.NegativeInfinity)

        ' Draw linear gradient ellipses between 
        ' all the StylusPoints in the Stroke.
        Dim i As Integer
        For i = 0 To Me.StylusPoints.Count - 1
            Dim pt As Point = CType(Me.StylusPoints(i), Point)
            Dim v As Vector = Point.Subtract(prevPoint, pt)

            ' Only draw if we are at least 4 units away 
            ' from the end of the last ellipse. Otherwise, 
            ' we're just redrawing and wasting cycles.
            If v.Length > 4 Then
                ' Set the thickness of the stroke 
                ' based on how hard the user pressed.
                Dim radius As Double = Me.StylusPoints(i).PressureFactor * 10.0
                drawingContext.DrawEllipse(brush, pen, pt, radius, radius)
                prevPoint = pt
            End If
        Next i

    End Sub
End Class
'</Snippet2>

'<Snippet3>
' A StylusPlugin that restricts the input area.
Class FilterPlugin
    Inherits StylusPlugIn

    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput)
        ' Call the base class before modifying the data.
        MyBase.OnStylusDown(rawStylusInput)

        ' Restrict the stylus input.
        Filter(rawStylusInput)

    End Sub


    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput)
        ' Call the base class before modifying the data.
        MyBase.OnStylusMove(rawStylusInput)

        ' Restrict the stylus input.
        Filter(rawStylusInput)

    End Sub


    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput)
        ' Call the base class before modifying the data.
        MyBase.OnStylusUp(rawStylusInput)

        ' Restrict the stylus input
        Filter(rawStylusInput)

    End Sub


    Private Sub Filter(ByVal rawStylusInput As RawStylusInput)
        ' Get the StylusPoints that have come in.
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()

        ' Modify the (X,Y) data to move the points 
        ' inside the acceptable input area, if necessary.
        Dim i As Integer
        For i = 0 To stylusPoints.Count - 1
            Dim sp As StylusPoint = stylusPoints(i)
            If sp.X < 50 Then
                sp.X = 50
            End If
            If sp.X > 250 Then
                sp.X = 250
            End If
            If sp.Y < 50 Then
                sp.Y = 50
            End If
            If sp.Y > 250 Then
                sp.Y = 250
            End If
            stylusPoints(i) = sp
        Next i

        ' Copy the modified StylusPoints back to the RawStylusInput.
        rawStylusInput.SetStylusPoints(stylusPoints)

    End Sub
End Class
'</Snippet3>