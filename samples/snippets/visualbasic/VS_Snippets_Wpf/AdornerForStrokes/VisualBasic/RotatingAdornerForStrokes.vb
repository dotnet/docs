 '<Snippet1>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink



Public Class RotatingStrokesAdorner
    Inherits Adorner

    ' The Thumb to drag to rotate the strokes.
    Private rotateHandle As Thumb
    
    ' The surrounding boarder.
    Private outline As Path
    
    Private visualChildren As VisualCollection
    
    ' The center of the strokes.
    Private center As Point
    Private lastAngle As Double
    
    Private rotation As RotateTransform
    
    Private Const HANDLEMARGIN As Integer = 10
    
    ' The bounds of the Strokes;
    Private strokeBounds As Rect = Rect.Empty
    
    
    Public Sub New(ByVal adornedElement As UIElement)
        MyBase.New(adornedElement)

        visualChildren = New VisualCollection(Me)
        rotateHandle = New Thumb()
        rotateHandle.Cursor = Cursors.SizeNWSE
        rotateHandle.Width = 20
        rotateHandle.Height = 20
        rotateHandle.Background = Brushes.Blue

        AddHandler rotateHandle.DragDelta, _
            AddressOf rotateHandle_DragDelta
        AddHandler rotateHandle.DragCompleted, _
            AddressOf rotateHandle_DragCompleted

        outline = New Path()
        outline.Stroke = Brushes.Blue
        outline.StrokeThickness = 1

        visualChildren.Add(outline)
        visualChildren.Add(rotateHandle)

        strokeBounds = AdornedStrokes.GetBounds()

    End Sub 'New
    
    
    ''' <summary>
    ''' Draw the rotation handle and the outline of
    ''' the element.
    ''' </summary>
    ''' <param name="finalSize">The final area within the 
    ''' parent that this element should use to arrange 
    ''' itself and its children.</param>
    ''' <returns>The actual size used. </returns>
    Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) _
              As Size

        If strokeBounds.IsEmpty Then
            Return finalSize
        End If

        center = New Point(strokeBounds.X + strokeBounds.Width / 2, _
                           strokeBounds.Y + strokeBounds.Height / 2)

        ' The rectangle that determines the position of the Thumb.
        Dim handleRect As New Rect(strokeBounds.X, _
                           strokeBounds.Y - (strokeBounds.Height / 2 + _
                                             HANDLEMARGIN), _
                           strokeBounds.Width, strokeBounds.Height)

        If Not (rotation Is Nothing) Then
            handleRect.Transform(rotation.Value)
        End If

        ' Draws the thumb and the rectangle around the strokes.
        rotateHandle.Arrange(handleRect)
        outline.Data = New RectangleGeometry(strokeBounds)
        outline.Arrange(New Rect(finalSize))
        Return finalSize

    End Function 'ArrangeOverride
    
    
    ''' <summary>
    ''' Rotates the rectangle representing the
    ''' strokes' bounds as the user drags the
    ''' Thumb.
    ''' </summary>
    Private Sub rotateHandle_DragDelta(ByVal sender As Object, _
                               ByVal e As DragDeltaEventArgs)

        'Find the angle of which to rotate the shape.  Use the right
        'triangle that uses the center and the mouse's position 
        'as vertices for the hypotenuse.
        Dim pos As Point = Mouse.GetPosition(Me)

        Dim deltaX As Double = pos.X - center.X
        Dim deltaY As Double = pos.Y - center.Y

        If deltaY.Equals(0) Then
            Return
        End If

        Dim tan As Double = deltaX / deltaY
        Dim angle As Double = Math.Atan(tan)

        ' Convert to degrees.
        angle = angle * 180 / Math.PI

        ' If the mouse crosses the vertical center, 
        ' find the complementary angle.
        If deltaY > 0 Then
            angle = 180 - Math.Abs(angle)
        End If

        ' Rotate left if the mouse moves left and right
        ' if the mouse moves right.
        If deltaX < 0 Then
            angle = -Math.Abs(angle)
        Else
            angle = Math.Abs(angle)
        End If

        If Double.IsNaN(angle) Then
            Return
        End If

        ' Apply the rotation to the strokes' outline.
        rotation = New RotateTransform(angle, center.X, center.Y)
        outline.RenderTransform = rotation

    End Sub 'rotateHandle_DragDelta
    
    
    ''' <summary>
    ''' Rotates the strokes to the same angle as outline.
    ''' </summary>
    Private Sub rotateHandle_DragCompleted(ByVal sender As Object, _
                                   ByVal e As DragCompletedEventArgs)

        If rotation Is Nothing Then
            Return
        End If

        ' Rotate the strokes to match the new angle.
        Dim mat As New Matrix()
        mat.RotateAt(rotation.Angle - lastAngle, center.X, center.Y)
        AdornedStrokes.Transform(mat, True)

        ' Save the angle of the last rotation.
        lastAngle = rotation.Angle

        ' Redraw rotateHandle.
        Me.InvalidateArrange()

    End Sub 'rotateHandle_DragCompleted
    
    ''' <summary>
    ''' Gets the strokes of the adorned element 
    ''' (in this case, an InkPresenter).
    ''' </summary>
    Private ReadOnly Property AdornedStrokes() As StrokeCollection
        Get
            Return CType(AdornedElement, InkPresenter).Strokes
        End Get
    End Property
    
    ' Override the VisualChildrenCount and 
    ' GetVisualChild properties to interface with 
    ' the adorner's visual collection.
    
    Protected Overrides ReadOnly Property VisualChildrenCount() As Integer 
        Get
            Return visualChildren.Count
        End Get
    End Property
     
    Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual 
        Return visualChildren(index)
    
    End Function 'GetVisualChild
End Class 'RotatingStrokesAdorner
'</Snippet1>