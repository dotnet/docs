'
'SolidColorBrushExample.vb
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
	Partial Public Class SolidColorBrushExample
		Inherits Page
		Public Sub New()
			Me.WindowTitle = "SolidColorBrush Example"
			Me.Background = Brushes.White

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' <Snippet_graphicsmm_PredefinedBrush1> 
			' Create a rectangle and paint it with
			' a predefined brush.
			Dim myPredefinedBrushRectangle As New Rectangle()
			myPredefinedBrushRectangle.Width = 50
			myPredefinedBrushRectangle.Height = 50
			myPredefinedBrushRectangle.Fill = Brushes.Blue
			' </Snippet_graphicsmm_PredefinedBrush1> 

			myStackPanel.Children.Add(myPredefinedBrushRectangle)

			' <Snippet_graphicsmm_RgbNotation1> 
			Dim myRgbRectangle As New Rectangle()
			myRgbRectangle.Width = 50
			myRgbRectangle.Height = 50
			Dim mySolidColorBrush As New SolidColorBrush()

			' Describes the brush's color using RGB values. 
			' Each value has a range of 0-255.
			mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 255)
			myRgbRectangle.Fill = mySolidColorBrush
			' </Snippet_graphicsmm_RgbNotation1> 
			myStackPanel.Children.Add(myRgbRectangle)

			' <Snippet_graphicsmm_ScrgbNotation1> 
			Dim myScRGBRectangle As New Rectangle()
			myScRGBRectangle.Width = 50
			myScRGBRectangle.Height = 50
			Dim myScrgbSolidColorBrush As New SolidColorBrush()

			' Describes the brush's color using ScRGB values. 
			' Each value has a range of 0-1.
			myScrgbSolidColorBrush.Color = Color.FromScRgb(1.0F, 0.0F, 0.0F, 1.0F)
			myScRGBRectangle.Fill = myScrgbSolidColorBrush
			' </Snippet_graphicsmm_ScrgbNotation1> 
			myStackPanel.Children.Add(myScRGBRectangle)



			Me.Content = myStackPanel
		End Sub


	End Class
End Namespace
