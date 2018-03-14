' <SnippetSetBackgroundColorOfShapeCodeExampleWholePage>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class SetBackgroundColorOfShapeExample
		Inherits Page
		Public Sub New()
			' Create a StackPanel to contain the shape.
			Dim myStackPanel As New StackPanel()

			' Create a red Ellipse.
			Dim myEllipse As New Ellipse()

			' Create a SolidColorBrush with a red color to fill the 
			' Ellipse with.
			Dim mySolidColorBrush As New SolidColorBrush()

			' Describes the brush's color using RGB values. 
			' Each value has a range of 0-255.
			mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0)
			myEllipse.Fill = mySolidColorBrush
			myEllipse.StrokeThickness = 2
			myEllipse.Stroke = Brushes.Black

			' Set the width and height of the Ellipse.
			myEllipse.Width = 200
			myEllipse.Height = 100

			' Add the Ellipse to the StackPanel.
			myStackPanel.Children.Add(myEllipse)

			Me.Content = myStackPanel
		End Sub

	End Class
End Namespace
' </SnippetSetBackgroundColorOfShapeCodeExampleWholePage>