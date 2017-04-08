' <SnippetRectExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class RectExample
		Inherits Page
		Public Sub New()
			Dim myPath1 As New Path()
			myPath1.Stroke = Brushes.Black
			myPath1.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath1.Fill = mySolidColorBrush

			' Create the rectangle.
			' This RectangleGeometry specifies a rectangle that is 100 pixels high and
			' 150 wide. The left side of the rectangle is 10 pixels from the left of the 
			' Canvas and the top side of the rectangle is 100 pixels from the top of the Canvas.  
			' Note: You could alternatively use the Rect Constructor to create this:
			' Dim myRect1 As New Rect(10,100,150,100")
			Dim myRect1 As New Rect()
			myRect1.X = 10
			myRect1.Y = 100
			myRect1.Width = 150
			myRect1.Height = 100
			Dim myRectangleGeometry1 As New RectangleGeometry()
			myRectangleGeometry1.Rect = myRect1

			Dim myGeometryGroup1 As New GeometryGroup()
			myGeometryGroup1.Children.Add(myRectangleGeometry1)

			myPath1.Data = myGeometryGroup1

			Dim myPath2 As New Path()
			myPath2.Stroke = Brushes.Black
			myPath2.StrokeThickness = 1
			myPath2.Fill = mySolidColorBrush

			' Create the rectangle.
			' This Rect uses the Size property to specify a height of 50 and width
			' of 200. The Location property uses a Point value to determine the location of the
			' top-left corner of the rectangle.
			Dim myRect2 As New Rect()
			myRect2.Size = New Size(50, 200)
			myRect2.Location = New Point(300, 100)
			Dim myRectangleGeometry2 As New RectangleGeometry()
			myRectangleGeometry2.Rect = myRect2

			Dim myGeometryGroup2 As New GeometryGroup()
			myGeometryGroup2.Children.Add(myRectangleGeometry2)

			myPath2.Data = myGeometryGroup2

			' Add path shape to the UI.
			Dim myCanvas As New Canvas()
			myCanvas.Children.Add(myPath1)
			myCanvas.Children.Add(myPath2)
			Me.Content = myCanvas
		End Sub
	End Class

End Namespace
' </SnippetRectExampleWholePage>
