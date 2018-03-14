Imports Microsoft.VisualBasic
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
	End Class

	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyVisualHost
		Inherits FrameworkElement
		' Create a collection of child visual objects.
		Private _children As VisualCollection
		Private _containerVisual As ContainerVisual

		Public Sub New()
			_children = New VisualCollection(Me)

			' <SnippetContainerVisualSnippet1>
			' Create a ContainerVisual and add children to it.
			Dim containerVisual As New ContainerVisual()
			containerVisual.Children.Add(CreateDrawingVisualRectangle())
			containerVisual.Children.Add(CreateDrawingVisualText())
			containerVisual.Children.Add(CreateDrawingVisualEllipses())
			' </SnippetContainerVisualSnippet1>

			' <SnippetContainerVisualSnippet3>
			If containerVisual.Children.Count > 0 Then
				Dim collection As VisualCollection = containerVisual.Children
			End If
			' </SnippetContainerVisualSnippet3>

			_containerVisual = containerVisual
			_children.Add(_containerVisual)
			AddHandler MouseLeftButtonUp, AddressOf MyVisualHost_MouseLeftButtonUp

			' <SnippetContainerVisualSnippet4>
			' Return the bounding rectangle for the ContainerVisual.
			Dim rectBounds As Rect = containerVisual.ContentBounds

			' Expand the rectangle to include the bounding rectangle
			' of the all of the ContainerVisual's descendants.
			rectBounds.Union(containerVisual.DescendantBounds)
			' </SnippetContainerVisualSnippet4>
		End Sub

		' <SnippetContainerVisualSnippet2>
		' Capture the mouse event and hit test the coordinate point value against
		' the child visual objects.
		Private Sub MyVisualHost_MouseLeftButtonUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			' Retrieve the coordinates of the mouse button event.
			Dim pt As Point = e.GetPosition(CType(sender, UIElement))

			' Initiate the hit test on the ContainerVisual's visual tree.
			Dim result As HitTestResult = _containerVisual.HitTest(pt)

			' Perform the action on the hit visual.
			If result.VisualHit IsNot Nothing Then
				ProcessHitVisual(CType(result.VisualHit, Visual))
			End If
		End Sub
		' </SnippetContainerVisualSnippet2>

		' If a child visual object is hit, toggle its opacity to visually indicate a hit.
		Public Shared Sub ProcessHitVisual(ByVal visual As Visual)
			If visual.GetType() Is GetType(DrawingVisual) Then
				If (CType(visual, DrawingVisual)).Opacity = 1.0 Then
					CType(visual, DrawingVisual).Opacity = 0.4
				Else
					CType(visual, DrawingVisual).Opacity = 1.0
				End If
			End If
		End Sub

		' Create a DrawingVisual that contains a rectangle.
		Private Function CreateDrawingVisualRectangle() As DrawingVisual
			Dim dv As New DrawingVisual()
			Dim dc As DrawingContext = dv.RenderOpen()

			Dim r As New Rect(New Point(160, 100), New Size(320, 80))
			dc.DrawRectangle(Brushes.LightBlue, CType(Nothing, Pen), r)
			dc.Close()

			Return dv
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
			Dim dv As New DrawingVisual()
			Dim dc As DrawingContext = dv.RenderOpen()

			dc.DrawEllipse(Brushes.Maroon, Nothing, New Point(430, 136), 20, 20)
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