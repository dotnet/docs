Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class DrawingVisualWindow
		Inherits Window
		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 Dim visualHost As New MyVisualHost2()
			 MyCanvas.Children.Add(visualHost)

			 RetrieveDrawings(visualHost)
		End Sub

		'<SnippetDrawingVisualSnippet1>
		' Enumerate the DrawingVisual children of a host visual.
		Public Sub RetrieveDrawings(ByVal visualHost As Visual)
			For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(visualHost) - 1
				' Retrieve child visual at specified index value.
				Dim dependencyObject As DependencyObject = VisualTreeHelper.GetChild(visualHost, i)

				' Determine if the child object is a DrawingVisual.
				If dependencyObject.GetType() Is GetType(DrawingVisual) Then
					Dim drawingVisual As DrawingVisual = CType(dependencyObject, DrawingVisual)

					If drawingVisual.Drawing IsNot Nothing Then
						If drawingVisual.Drawing.GetType() Is GetType(DrawingGroup) Then
							' Enumerate the drawings in the DrawingGroup.
							EnumDrawingGroup(drawingVisual.Drawing)
						End If
					End If
				End If
			Next i
		End Sub

		 ' Enumerate the drawings in the DrawingGroup.
		 Public Sub EnumDrawingGroup(ByVal drawingGroup As DrawingGroup)
			 Dim dc As DrawingCollection = drawingGroup.Children

			 ' Enumerate the drawings in the DrawingCollection.
			 For Each drawing As Drawing In dc
				 ' If the drawing is a DrawingGroup, call the function recursively.
				 If drawing.GetType() Is GetType(DrawingGroup) Then
					 EnumDrawingGroup(CType(drawing, DrawingGroup))
				 End If

				 If drawing.GetType() Is GetType(GeometryDrawing) Then
					 ' Perform action based on drawing type.
				 End If
			 Next drawing
		 End Sub
		 '</SnippetDrawingVisualSnippet1>
	End Class

	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyVisualHost2
		Inherits FrameworkElement
		' Create a collection of child visual objects.
		Private _children As VisualCollection

		Public Sub New()
			_children = New VisualCollection(Me)
			_children.Add(CreateDrawingVisualRectangle())
			_children.Add(CreateDrawingVisualText())
			_children.Add(CreateDrawingVisualEllipses())
			AddHandler MouseLeftButtonUp, AddressOf MyVisualHost_MouseLeftButtonUp
		End Sub

		' Capture the mouse event and hit test the coordinate point value against
		' the child visual objects.
		Private Sub MyVisualHost_MouseLeftButtonUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			' Retreive the coordinates of the mouse button event.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			Dim result As HitTestResult = Me.HitTestCore(New PointHitTestParameters(pt))

			If (result IsNot Nothing) AndAlso (result.VisualHit.GetType() Is GetType(DrawingVisual)) Then
				If (CType(result.VisualHit, DrawingVisual)).Opacity = 1.0 Then
					CType(result.VisualHit, DrawingVisual).Opacity = 0.4
				Else
					CType(result.VisualHit, DrawingVisual).Opacity = 1.0
				End If
			End If
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

		' Create a DrawingVisual that contains a rectangle.
		Private Function CreateDrawingVisualRectangle() As DrawingVisual
			Dim drawingVisual As New DrawingVisual()
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			Dim rect As New Rect(New Point(160, 100), New Size(320, 80))
			drawingContext.DrawRectangle(Brushes.LightBlue, CType(Nothing, Pen), rect)
			drawingContext.Close()

			Return drawingVisual
		End Function

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

		' Create a DrawingVisual that contains an ellipse.
		Private Function CreateDrawingVisualEllipses() As DrawingVisual
			Dim drawingVisual As New DrawingVisual()
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			drawingContext.DrawEllipse(Brushes.Maroon, Nothing, New Point(430, 136), 20, 20)
			drawingContext.Close()

			Return drawingVisual
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