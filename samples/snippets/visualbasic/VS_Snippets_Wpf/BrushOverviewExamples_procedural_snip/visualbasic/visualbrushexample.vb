' <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace Microsoft.Samples.BrushExamples

	Public Class VisualBrushExample
		Inherits Page

		Public Sub New()

			Dim mainPanel As New StackPanel()
			visualBrushAsRectangleFillExample(mainPanel)
			Me.Content = mainPanel

		End Sub


		' <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample>
		Private Sub visualBrushAsRectangleFillExample(ByVal mainPanel As Panel)

			' <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample1>
			Dim myVisualBrush As New VisualBrush()

			' Create the visual brush's contents.
			Dim myStackPanel As New StackPanel()
			myStackPanel.Background = Brushes.White

            Dim redRectangle As New Rectangle()
            With redRectangle
                .Width = 25
                .Height = 25
                .Fill = Brushes.Red
                .Margin = New Thickness(2)
            End With
            myStackPanel.Children.Add(redRectangle)

            Dim someText As New TextBlock()
            Dim myFontSizeConverter As New FontSizeConverter()
            someText.FontSize = CDbl(myFontSizeConverter.ConvertFrom("10pt"))
            someText.Text = "Hello, World!"
            someText.Margin = New Thickness(2)
            myStackPanel.Children.Add(someText)

            Dim aButton As New Button()
            aButton.Content = "A Button"
            aButton.Margin = New Thickness(2)
            myStackPanel.Children.Add(aButton)

            ' Use myStackPanel as myVisualBrush's content.
            myVisualBrush.Visual = myStackPanel

            ' Create a rectangle to paint.
            Dim myRectangle As New Rectangle()
            With myRectangle
                .Width = 150
                .Height = 150
                .Stroke = Brushes.Black
                .Margin = New Thickness(5, 0, 5, 0)
            End With

            ' Use myVisualBrush to paint myRectangle.
            myRectangle.Fill = myVisualBrush

            ' </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample1>

            mainPanel.Children.Add(myRectangle)


		End Sub
		' </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample>

	End Class

End Namespace
' </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExampleWholePage>