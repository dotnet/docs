Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace Microsoft.Samples.GradientBrushExamples

	Public Class LinearGradientBrushExample
		Inherits Page

		Public Sub New()
			Me.WindowTitle = "LinearGradientBrush Example"
			Me.Background = Brushes.White

			Dim mainPanel As New StackPanel()

            ' <SnippetDiagonalGradient1VB>            
			Dim diagonalFillRectangle As New Rectangle()
			diagonalFillRectangle.Width = 200
			diagonalFillRectangle.Height = 100

			' Create a diagonal linear gradient with four stops.   
			Dim myLinearGradientBrush As New LinearGradientBrush()
			myLinearGradientBrush.StartPoint = New Point(0,0)
			myLinearGradientBrush.EndPoint = New Point(1,1)
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Use the brush to paint the rectangle.
			diagonalFillRectangle.Fill = myLinearGradientBrush
            ' </SnippetDiagonalGradient1VB>            

            ' <SnippetHorizontalGradient1VB>            
			Dim horizontalFillRectangle As New Rectangle()
			horizontalFillRectangle.Width = 200
			horizontalFillRectangle.Height = 100

			' Create a horizontal linear gradient with four stops.   
			Dim myHorizontalGradient As New LinearGradientBrush()
			myHorizontalGradient.StartPoint = New Point(0,0.5)
			myHorizontalGradient.EndPoint = New Point(1,0.5)
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			myHorizontalGradient.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Use the brush to paint the rectangle.
			horizontalFillRectangle.Fill = myHorizontalGradient

            ' </SnippetHorizontalGradient1VB>


            ' <SnippetVerticalGradient1VB>
			Dim verticalFillRectangle As New Rectangle()
			verticalFillRectangle.Width = 200
			verticalFillRectangle.Height = 100

			' Create a vertical linear gradient with four stops.   
			Dim myVerticalGradient As New LinearGradientBrush()
			myVerticalGradient.StartPoint = New Point(0.5,0)
			myVerticalGradient.EndPoint = New Point(0.5,1)
			myVerticalGradient.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myVerticalGradient.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			myVerticalGradient.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			myVerticalGradient.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Use the brush to paint the rectangle.
			verticalFillRectangle.Fill = myVerticalGradient
            ' </SnippetVerticalGradient1VB>

			mainPanel.Children.Add(diagonalFillRectangle)
			mainPanel.Children.Add(horizontalFillRectangle)
			mainPanel.Children.Add(verticalFillRectangle)

			Me.Content = mainPanel

		End Sub

	End Class
End Namespace