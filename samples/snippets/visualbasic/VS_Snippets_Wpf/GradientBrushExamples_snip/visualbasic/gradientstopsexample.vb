Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace Microsoft.Samples.GradientBrushExamples

	Public Class GradientStopsExample
		Inherits Page

		Private myMainPanel As StackPanel

		Public Sub New()
			Me.WindowTitle = "Gradient Stop Examples"
			Me.Background = Brushes.White

			myMainPanel = New StackPanel()

			createTransparentGradientStopExample()


			Me.Content = myMainPanel

		End Sub


		Private Sub createTransparentGradientStopExample()
            ' <SnippetTransparentGradientStopExample1VB>
			Dim myLinearGradientBrush As New LinearGradientBrush()

			' This gradient stop is partially transparent.
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Color.FromArgb(32, 0, 0, 255), 0.0))

			' This gradient stop is fully opaque. 
			myLinearGradientBrush.GradientStops.Add(New GradientStop(Color.FromArgb(255, 0, 0, 255), 1.0))

			Dim myRectangle As New Rectangle()
			myRectangle.Width = 100
			myRectangle.Height = 100
			myRectangle.Fill = myLinearGradientBrush

            ' </SnippetTransparentGradientStopExample1VB>

			myMainPanel.Children.Add(myRectangle)

		End Sub

	End Class
End Namespace