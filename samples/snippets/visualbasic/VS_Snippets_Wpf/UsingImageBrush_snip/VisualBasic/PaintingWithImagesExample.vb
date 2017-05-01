' <SnippetImageBrushExampleWholePage>


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Media

Namespace Microsoft.Samples.Graphics.UsingImageBrush

    Public Class PaintingWithImagesExample
        Inherits Page

        Public Sub New()
            Background = Brushes.White
            Dim mainPanel As New StackPanel()
            mainPanel.Margin = New Thickness(20.0)

            ' Create a button.
            Dim berriesButton As New Button()
            With berriesButton
                .Foreground = Brushes.White
                .FontWeight = FontWeights.Bold
                Dim sizeConverter As New FontSizeConverter()
                .FontSize = CType(sizeConverter.ConvertFromString("16pt"), Double)
                .FontFamily = New FontFamily("Verdana")
                .Content = "Berries"
                .Padding = New Thickness(20.0)
                .HorizontalAlignment = HorizontalAlignment.Left
            End With

            ' Create an ImageBrush.
            Dim berriesBrush As New ImageBrush()
            berriesBrush.ImageSource = New BitmapImage(New Uri("sampleImages\berries.jpg", UriKind.Relative))

            ' Use the brush to paint the button's background.
            berriesButton.Background = berriesBrush

            mainPanel.Children.Add(berriesButton)
            Me.Content = mainPanel
        End Sub
    End Class
End Namespace

' </SnippetImageBrushExampleWholePage>