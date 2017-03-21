Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		 Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 Dim vh As New MyVisualHost()
			 MyCanvas.Children.Add(vh)
		 End Sub

		' Handle the Click event for the button.
		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

	End Class

	'<Snippet100> 
	' Create a visual object derived from DrawingVisual.
	Friend Class MyRectangle
		Inherits DrawingVisual
		Public Sub New(ByVal myColor As Color, ByVal myRect As Rect, ByVal caption As String)
			' Return a drawing context to draw into.
			Dim dc As DrawingContext = RenderOpen()

			' Draw a rectangle into the drawing context.
			dc.DrawRectangle(New SolidColorBrush(myColor), Nothing, myRect)

			' Create a text string and draw it in the drawing context.
			Dim formattedText As New FormattedText(caption, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, New Typeface("Verdana"), 36, Brushes.Black)
			dc.DrawText(formattedText, New Point(myRect.Left + 10, myRect.Top + 5))

			' Close the drawing context to persist the changes.
			dc.Close()
		End Sub
	End Class
	'</Snippet100>

	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyVisualHost
		Inherits FrameworkElement
		' Create a collection of child visual objects.
		Private _children As VisualCollection

		Public Sub New()
			_children = New VisualCollection(Me)
			Dim myRect As New MyRectangle(Brushes.LightBlue.Color, New Rect(New Point(160, 100), New Size(320, 80)), "Hello, world!")
			_children.Add(myRect)
			_children.Add(CreateDrawingVisualEllipses())
			AddHandler MouseLeftButtonUp, AddressOf MyVisualHost_MouseLeftButtonUp
		End Sub

		' Capture the mouse event and hit test the coordinate point value against
		' the child visual objects.
		Private Sub MyVisualHost_MouseLeftButtonUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			' Enumerate all the descendants of the visual host object.
			EnumVisual(Me)

			' Get bounding rectangle of parent and descendants.
			Dim r As Rect = GetBoundingRectangle(Me)

			' Find a DrawingVisual in the hit object.
			FindDrawingVisual(Me, e.GetPosition(Me))
		End Sub

		'<Snippet101> 
		' Enumerate all the descendants of the visual object.
		Public Shared Sub EnumVisual(ByVal myVisual As Visual)
			For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(myVisual) - 1
				' Retrieve child visual at specified index value.
				Dim childVisual As Visual = CType(VisualTreeHelper.GetChild(myVisual, i), Visual)

				' Do processing of the child visual object.

				' Enumerate children of the child visual object.
				EnumVisual(childVisual)
			Next i
		End Sub
		'</Snippet101>

		' Get the combined bounding rectangle of the parent visual and its descendants.
		Public Shared Function GetBoundingRectangle(ByVal parentVisual As Visual) As Rect
			'<Snippet102>
			' Return the bounding rectangle of the parent visual object and all of its descendants.
			Dim rectBounds As Rect = VisualTreeHelper.GetDescendantBounds(parentVisual)
			'</Snippet102>

			Return rectBounds
		End Function

		'<SnippetVisualsOverviewSnippet4>
		' Determine if a geometry within the visual was hit.
		Public Shared Sub HitTestGeometryInVisual(ByVal visual As Visual, ByVal pt As Point)
			' Retrieve the group of drawings for the visual.
			Dim drawingGroup As DrawingGroup = VisualTreeHelper.GetDrawing(visual)
			EnumDrawingGroup(drawingGroup, pt)
		End Sub

		' Enumerate the drawings in the DrawingGroup.
		Public Shared Sub EnumDrawingGroup(ByVal drawingGroup As DrawingGroup, ByVal pt As Point)
			Dim drawingCollection As DrawingCollection = drawingGroup.Children

			' Enumerate the drawings in the DrawingCollection.
			For Each drawing As Drawing In drawingCollection
				' If the drawing is a DrawingGroup, call the function recursively.
				If drawing.GetType() Is GetType(DrawingGroup) Then
					EnumDrawingGroup(CType(drawing, DrawingGroup), pt)
				ElseIf drawing.GetType() Is GetType(GeometryDrawing) Then
					' Determine whether the hit test point falls within the geometry.
					If (CType(drawing, GeometryDrawing)).Geometry.FillContains(pt) Then
						' Perform action based on hit test on geometry.
					End If
				End If

			Next drawing
		End Sub
		'</SnippetVisualsOverviewSnippet4>

		' Find a DrawingVisual in the hit object.
		Public Shared Sub FindDrawingVisual(ByVal myVisual As Visual, ByVal pt As Point)
			For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(myVisual) - 1
				' Retrieve child visual at specified index value.
				Dim childVisual As Visual = CType(VisualTreeHelper.GetChild(myVisual, i), Visual)
				Dim dv As New DrawingVisual()
				If childVisual.GetType() Is dv.GetType() Then
					Dim dg As DrawingGroup = VisualTreeHelper.GetDrawing(childVisual)

					' Hit test geometry of drawing.
					HitTestGeometryInVisual(childVisual, pt)
				End If
				' Do processing of the child visual object.

				' Enumerate children of the child visual object.
				FindDrawingVisual(childVisual, pt)
			Next i
		End Sub


		' Create a DrawingVisual that contains an ellipse.
		Private Function CreateDrawingVisualEllipses() As DrawingVisual
			Dim dv As New DrawingVisual()
			Dim dc As DrawingContext = dv.RenderOpen()

			dc.DrawEllipse(Brushes.Gray, Nothing, New Point(430, 136), 20, 20)
			dc.DrawEllipse(Brushes.SteelBlue, Nothing, New Point(480, 136), 20, 20)
			dc.DrawEllipse(Brushes.Maroon, Nothing, New Point(530, 136), 20, 20)
			' Create a text string and draw it in the drawing context.
			Dim formattedText As New FormattedText("Hi", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, New Typeface("Verdana"), 24, Brushes.Black)
			dc.DrawText(formattedText, New Point(430-12, 136-12))
			dc.Close()

			Return dv
		End Function

		' Provide a required override for the VisualChildCount property.
		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return _children.Count
			End Get
		End Property

		' Provide a required override for the GetVisualChild method.
		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			If index < 0 OrElse index > _children.Count Then
				Throw New ArgumentOutOfRangeException()
			End If

			Return CType(_children(index), Visual)
		End Function

		' Provide a required override for the MeasureOverride method.
		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.MeasureOverride(availableSize)
		End Function

		' Provide a required override for the ArrangeOverride method.
		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.ArrangeOverride(finalSize)
		End Function

	End Class
End Namespace