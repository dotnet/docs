' <SnippetStreamGeometryPolyLineToExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections.Generic

Namespace SDKSample
	Partial Public Class StreamGeometryPolyLineToExample
		Inherits Page
		Public Sub New()
			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' Create a StreamGeometry to use to specify myPath.
			Dim geometry As New StreamGeometry()

			' Open a StreamGeometryContext that can be used to describe this StreamGeometry 
			' object's contents. 
			Using ctx As StreamGeometryContext = geometry.Open()
				' Begin the triangle at the point specified.
				ctx.BeginFigure(New Point(10, 100), True, True) ' is closed  -  is filled 

				' Create a collection of Point structures that will be used with the PolyLineTo 
				' Method to create a triangle.
				Dim pointList As New List(Of Point)()

				' Two Points are added to the collection. The PolyLineTo method will draw lines
				' between the Points of the collection.
				pointList.Add(New Point(100, 100))
				pointList.Add(New Point(100, 50))

				' Create a triangle using the collection of Point Structures.
				ctx.PolyLineTo(pointList, True, False) ' is smooth join  -  is stroked 

			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (triangle) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryPolyLineToExampleWholePage>