Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Private _visualHost As MyVisualHost

		 Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 _visualHost = New MyVisualHost(CreateDrawingVisualRectangle(Brushes.LightBlue))
			 MyCanvas.Children.Add(_visualHost)
		 End Sub

		 Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			 _visualHost.Child = CreateDrawingVisualRectangle(Brushes.Maroon)
		 End Sub

		 ' Create a DrawingVisual that contains a rectangle.
		Public Function CreateDrawingVisualRectangle(ByVal brush As SolidColorBrush) As DrawingVisual
			 Dim drawingVisual As New DrawingVisual()

			 ' Retrieve the DrawingContext in order to create new drawing content.
			 Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			 ' Create a rectangle and draw it in the DrawingContext.
			 Dim rect As New Rect(New Point(160, 100), New Size(320, 80))
			 drawingContext.DrawRectangle(Nothing, New Pen(brush, 2.0), rect)

			 ' Persist the drawing content.
			 drawingContext.Close()

			 Return drawingVisual
		End Function
	End Class

	' <SnippetAddVisualChild01> 
	' Create a host visual derived from the FrameworkElement class.
	' This class provides layout, event handling, and container support for
	' the child visual object.
	Public Class MyVisualHost
		Inherits FrameworkElement
		Private _child As DrawingVisual

		Public Sub New(ByVal drawingVisual As DrawingVisual)
			_child = drawingVisual
			Me.AddVisualChild(_child)
		End Sub

		Public Property Child() As DrawingVisual
			Get
				Return _child
			End Get

			Set(ByVal value As DrawingVisual)
				If _child IsNot value Then
					Me.RemoveVisualChild(_child)
					_child = value
					Me.AddVisualChild(_child)
				End If
			End Set
		End Property

		' Provide a required override for the VisualChildrenCount property.
		Protected Overrides ReadOnly Property VisualChildrenCount() As Integer
			Get
				Return If(_child Is Nothing, 0, 1)
			End Get
		End Property

		' Provide a required override for the GetVisualChild method.
		Protected Overrides Function GetVisualChild(ByVal index As Integer) As Visual
			If _child Is Nothing Then
				Throw New ArgumentOutOfRangeException()
			End If

			Return _child
		End Function
		' </SnippetAddVisualChild01>
	End Class
End Namespace