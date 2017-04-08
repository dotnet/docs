Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace Microsoft.Samples.GradientBrushExamples

	Public Class RadialGradientBrushExample
		Inherits Page

		Private myMainPanel As StackPanel

		Public Sub New()
			Me.WindowTitle = "RadialGradientBrush Example"
			Me.Background = Brushes.White

			myMainPanel = New StackPanel()

			createRadialGradientBrushExample()


			Me.Content = myMainPanel

		End Sub


		Private Sub createRadialGradientBrushExample()
            ' <SnippetRadialGradient1VB>
            Dim myRadialGradientBrush As New RadialGradientBrush()
            With myRadialGradientBrush
                .GradientOrigin = New Point(0.5, 0.5)
                .Center = New Point(0.5, 0.5)
                .RadiusX = 0.5
                .RadiusY = 0.5
                .GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
                .GradientStops.Add(New GradientStop(Colors.Red, 0.25))
                .GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
                .GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))
            End With

            Dim myRectangle As New Rectangle()
            myRectangle.Width = 200
            myRectangle.Height = 100
            myRectangle.Fill = myRadialGradientBrush
            ' </SnippetRadialGradient1VB>

            myMainPanel.Children.Add(myRectangle)

		End Sub

	End Class
End Namespace