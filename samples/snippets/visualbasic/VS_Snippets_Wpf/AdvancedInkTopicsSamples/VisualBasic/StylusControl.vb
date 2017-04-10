'<Snippet20>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Controls
Imports System.Windows
'</Snippet20>

'<Snippet6>
' A control for managing ink input
Class InkControl
    Inherits Label
    Private ip As InkPresenter
    Private dr As DynamicRenderer

    ' The StylusPointsCollection that gathers points 
    ' before Stroke from is created.
    Private stylusPoints As StylusPointCollection = Nothing


    Public Sub New()
        ' Add an InkPresenter for drawing.
        ip = New InkPresenter()
        Me.Content = ip

        ' Add a dynamic renderer that 
        ' draws ink as it "flows" from the stylus.
        dr = New DynamicRenderer()
        ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes)
        Me.StylusPlugIns.Add(dr)

        Dim cdr As New CustomDynamicRenderer()
        ip.AttachVisuals(cdr.RootVisual, cdr.DrawingAttributes)
        Me.StylusPlugIns.Add(cdr)

    End Sub 'New

    Shared Sub New()

        ' Allow ink to be drawn only within the bounds of the control.
        Dim owner As Type = GetType(InkControl)
        ClipToBoundsProperty.OverrideMetadata(owner, New FrameworkPropertyMetadata(True))

    End Sub 'New

    '<Snippet7>
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs)
        ' Capture the stylus so all stylus input is routed to this control.
        Stylus.Capture(Me)

        ' Allocate memory for the StylusPointsCollection and
        ' add the StylusPoints that have come in so far.
        stylusPoints = New StylusPointCollection()
        Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)

        stylusPoints.Add(eventPoints)

    End Sub 'OnStylusDown
    '</Snippet7>

    '<Snippet8>
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs)

        If stylusPoints Is Nothing Then
            Return
        End If

        ' Add the StylusPoints that have come in since the 
        ' last call to OnStylusMove.
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)

    End Sub 'OnStylusMove
    '</Snippet8>

    '<Snippet10>
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs)
        ' Allocate memory for the StylusPointsCollection, if necessary.
        If stylusPoints Is Nothing Then
            Return
        End If

        ' Add the StylusPoints that have come in since the 
        ' last call to OnStylusMove.
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)

        ' Create a new stroke from all the StylusPoints since OnStylusDown.
        Dim stroke As New Stroke(stylusPoints)

        ' Add the new stroke to the Strokes collection of the InkPresenter.
        ip.Strokes.Add(stroke)

        ' Clear the StylusPointsCollection.
        stylusPoints = Nothing

        ' Release stylus capture.
        Stylus.Capture(Nothing)

    End Sub 'OnStylusUp
    '</Snippet10>

    '<Snippet11>
    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)

        MyBase.OnMouseLeftButtonDown(e)

        ' If a stylus generated this event, return.
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        ' Start collecting the points.
        stylusPoints = New StylusPointCollection()
        Dim pt As Point = e.GetPosition(Me)
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))

    End Sub 'OnMouseLeftButtonDown
    '</Snippet11>

    '<Snippet12>
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

        MyBase.OnMouseMove(e)

        ' If a stylus generated this event, return.
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        ' Don't collect points unless the left mouse button
        ' is down.
        If e.LeftButton = MouseButtonState.Released Then
            Return
        End If

        If stylusPoints Is Nothing Then
            Return
        End If

        Dim pt As Point = e.GetPosition(Me)
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))

    End Sub 'OnMouseMove
    '</Snippet12>

    '<Snippet13>
    Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)

        MyBase.OnMouseLeftButtonUp(e)

        ' If a stylus generated this event, return.
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If

        Dim pt As Point = e.GetPosition(Me)
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))

        ' Create a stroke and add it to the InkPresenter.
        Dim stroke As New Stroke(stylusPoints)
        stroke.DrawingAttributes = dr.DrawingAttributes
        ip.Strokes.Add(stroke)

        stylusPoints = Nothing

    End Sub 'OnMouseLeftButtonUp 
    '</Snippet13>
End Class 'StylusControl
'</Snippet6>

