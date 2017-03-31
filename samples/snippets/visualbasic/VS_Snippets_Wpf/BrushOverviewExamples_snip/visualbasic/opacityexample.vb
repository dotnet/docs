Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.BrushExamples

	Public Class OpacityExample
		Inherits Page


		Public Sub New()
			Me.WindowTitle = "Opacity Example"
			Me.Background = Brushes.White
			Dim myMainPanel As New StackPanel()

            ' <SnippetOpacityExample1VB>
			Dim myRectangle As New Rectangle()
			myRectangle.Width = 100
			myRectangle.Height = 100
			Dim partiallyTransparentSolidColorBrush As New SolidColorBrush(Colors.Blue)
			partiallyTransparentSolidColorBrush.Opacity = 0.25
			myRectangle.Fill = partiallyTransparentSolidColorBrush
            ' </SnippetOpacityExample1VB>

			myMainPanel.Children.Add(myRectangle)

			Me.Content = myMainPanel
		End Sub

	End Class

End Namespace