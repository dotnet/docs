'
'OpacityExample.vb
'
'


Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging

Namespace Microsoft.Samples.BrushExamples
	Partial Public Class OpacityExample
		Inherits Page
		Public Sub New()
			Me.WindowTitle = "Opacity Example"
			Me.Background = Brushes.White

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' <Snippet2>
			'
			' Both the button and its text are made 25% opaque.
			'
			Dim myTwentyFivePercentOpaqueButton As New Button()
			myTwentyFivePercentOpaqueButton.Opacity = New Double()
			myTwentyFivePercentOpaqueButton.Opacity = 0.25
			myTwentyFivePercentOpaqueButton.Content = "A Button"
			' </Snippet2>

			myStackPanel.Children.Add(myTwentyFivePercentOpaqueButton)


			' <Snippet3>
			'
			' The image contained within this button has an 
			' effective opacity of 0.125 (0.25*0.5 = 0.125)
			'
			Dim myImageButton As New Button()
			myImageButton.Opacity = New Double()
			myImageButton.Opacity = 0.25

			Dim myImageStackPanel As New StackPanel()
			myImageStackPanel.Orientation = Orientation.Horizontal


			Dim myTextBlock As New TextBlock()
			myTextBlock.VerticalAlignment = VerticalAlignment.Center
			myTextBlock.Margin = New Thickness(10)
			myTextBlock.Text = "A Button"
			myImageStackPanel.Children.Add(myTextBlock)

			Dim myImage As New Image()
			Dim myBitmapImage As New BitmapImage()
			myBitmapImage.BeginInit()
			myBitmapImage.UriSource = New Uri("sampleImages/berries.jpg",UriKind.Relative)
			myBitmapImage.EndInit()
			myImage.Source = myBitmapImage
			Dim myImageBrush As New ImageBrush(myBitmapImage)
			myImage.Width = 50
			myImage.Height = 50
			myImage.Opacity = 0.5
			myImageStackPanel.Children.Add(myImage)
			myImageButton.Content = myImageStackPanel
			' </Snippet3>

			myStackPanel.Children.Add(myImageButton)


			' <Snippet4>
			'
			'  This button's background is made 25% opaque, 
			' but its text remains 100% opaque.
			'
			Dim myOpaqueTextButton As New Button()
			Dim mySolidColorBrush As New SolidColorBrush(Colors.Gray)
			mySolidColorBrush.Opacity = 0.25
			myOpaqueTextButton.Background = mySolidColorBrush
			myOpaqueTextButton.Content = "A Button"
			' </Snippet4>

			myStackPanel.Children.Add(myOpaqueTextButton)

			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
