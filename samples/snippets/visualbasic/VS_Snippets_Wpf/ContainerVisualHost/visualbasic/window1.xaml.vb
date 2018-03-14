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
			 Dim vh As New MyContainerVisualHost(CreateDrawingVisualRectangle(), CreateDrawingVisualText())
			 MyCanvas.Children.Add(vh)
		 End Sub

		 Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
		 End Sub

		 ' Create a DrawingVisual that contains a rectangle.
		 Public Function CreateDrawingVisualRectangle() As DrawingVisual
			 Dim dv As New DrawingVisual()
			 Dim dc As DrawingContext = dv.RenderOpen()

			 Dim r As New Rect(New Point(160, 100), New Size(320, 80))
			 dc.DrawRectangle(Brushes.LightBlue, CType(Nothing, Pen), r)
			 dc.Close()

			 Return dv
		 End Function

		 ' Create a DrawingVisual that contains text.
		Public Function CreateDrawingVisualText() As DrawingVisual
			 ' Create an instance of a DrawingVisual.
			 Dim drawingVisual As New DrawingVisual()

			 ' Retrieve the DrawingContext from the DrawingVisual.
			 Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			 ' Draw a formatted text string into the DrawingContext.
			 drawingContext.DrawText(New FormattedText("Hello, world!", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Verdana"), 36, Brushes.Black), New Point(200, 116))

			 ' Close the DrawingContext to persist changes to the DrawingVisual.
			 drawingContext.Close()

			 Return drawingVisual
		End Function

	End Class

	' <SnippetContainerVisualHost01>
	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual objects.
	Public Class MyContainerVisualHost
		Inherits FrameworkElement
		Private _containerVisual As ContainerVisual

		Public Sub New(ByVal border As DrawingVisual, ByVal text As DrawingVisual)
			' Create a ContainerVisual to hold DrawingVisual children.
			_containerVisual = New ContainerVisual()

			' Add children to ContainerVisual in reverse z-order (bottom to top).
			_containerVisual.Children.Add(border)
			_containerVisual.Children.Add(text)

			' Create parent-child relationship with host visual and ContainerVisual.
			Me.AddVisualChild(_containerVisual)
		End Sub

		' Provide a required override for the VisualChildrenCount property.
		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return If(_containerVisual Is Nothing, 0, 1)
			End Get
		End Property

		' Provide a required override for the GetVisualChild method.
		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			If _containerVisual Is Nothing Then
				Throw New ArgumentOutOfRangeException()
			End If

			Return _containerVisual
		End Function
	End Class
	' </SnippetContainerVisualHost01>
End Namespace