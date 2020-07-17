Imports System.Globalization

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		 Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 Dim visualHost As New MyVisualHost()
			 MyCanvas.Children.Add(visualHost)
		 End Sub
	End Class

	'<Snippet100> 
	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyVisualHost
		Inherits FrameworkElement
		' Create a collection of child visual objects.
		Private _children As VisualCollection

		Public Sub New()
			_children = New VisualCollection(Me)
			_children.Add(CreateDrawingVisualRectangle())
			_children.Add(CreateDrawingVisualText())
			_children.Add(CreateDrawingVisualEllipses())

			' Add the event handler for MouseLeftButtonUp.
			AddHandler MouseLeftButtonUp, AddressOf MyVisualHost_MouseLeftButtonUp
		End Sub
		'</Snippet100> 

		'<Snippet103> 
		' Capture the mouse event and hit test the coordinate point value against
		' the child visual objects.
		Private Sub MyVisualHost_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			' Retrieve the coordinates of the mouse button event.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Initiate the hit test by setting up a hit test result callback method.
			VisualTreeHelper.HitTest(Me, Nothing, New HitTestResultCallback(AddressOf myCallback), New PointHitTestParameters(pt))
		End Sub

		' If a child visual object is hit, toggle its opacity to visually indicate a hit.
		Public Function myCallback(ByVal result As HitTestResult) As HitTestResultBehavior
			If result.VisualHit.GetType() Is GetType(DrawingVisual) Then
				If (CType(result.VisualHit, DrawingVisual)).Opacity = 1.0 Then
					CType(result.VisualHit, DrawingVisual).Opacity = 0.4
				Else
					CType(result.VisualHit, DrawingVisual).Opacity = 1.0
				End If
			End If

			' Stop the hit test enumeration of objects in the visual tree.
			Return HitTestResultBehavior.Stop
		End Function
		'</Snippet103> 

		'<Snippet101> 
		' Create a DrawingVisual that contains a rectangle.
		Private Function CreateDrawingVisualRectangle() As DrawingVisual
			Dim drawingVisual As New DrawingVisual()

			' Retrieve the DrawingContext in order to create new drawing content.
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			' Create a rectangle and draw it in the DrawingContext.
			Dim rect As New Rect(New Point(160, 100), New Size(320, 80))
			drawingContext.DrawRectangle(Brushes.LightBlue, CType(Nothing, Pen), rect)

			' Persist the drawing content.
			drawingContext.Close()

			Return drawingVisual
		End Function
		'</Snippet101> 

		'<Snippet110> 
		' Create a DrawingVisual that contains text.
		Private Function CreateDrawingVisualText() As DrawingVisual
			' Create an instance of a DrawingVisual.
			Dim drawingVisual As New DrawingVisual()

			' Retrieve the DrawingContext from the DrawingVisual.
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			' Draw a formatted text string into the DrawingContext.
			drawingContext.DrawText(New FormattedText("Click Me!", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Verdana"), 36, Brushes.Black), New Point(200, 116))

			' Close the DrawingContext to persist changes to the DrawingVisual.
			drawingContext.Close()

			Return drawingVisual
		End Function
		'</Snippet110> 

		' Create a DrawingVisual that contains an ellipse.
		Private Function CreateDrawingVisualEllipses() As DrawingVisual
			Dim drawingVisual As New DrawingVisual()
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			drawingContext.DrawEllipse(Brushes.Maroon, Nothing, New Point(430, 136), 20, 20)
			drawingContext.Close()

			Return drawingVisual
		End Function

		'<Snippet102>

		'<Snippet102a>
		' Provide a required override for the VisualChildrenCount property.
		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return _children.Count
			End Get
		End Property
		'</Snippet102a>

		'<Snippet102b>
		' Provide a required override for the GetVisualChild method.
		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			If index < 0 OrElse index >= _children.Count Then
				Throw New ArgumentOutOfRangeException()
			End If

			Return _children(index)
		End Function
		'</Snippet102b>

		'</Snippet102> 
	End Class
End Namespace
