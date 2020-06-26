Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes
Namespace SDKSample
	Partial Public Class CreateColorsFromExample
		Inherits Page
		Public Sub New()


			' Add Image to the UI
			Dim myStackPanel As New StackPanel()
			'myStackPanel.Children.Add(myImage)

			'////// FromRgb Rectangle ///////
			Dim fromRgbRect As New Rectangle()
			fromRgbRect.Width = 50
			fromRgbRect.Height = 50

			' Create a brush for the rectangle fill.
			Dim fromRgbSolidColorBrush As New SolidColorBrush()
			fromRgbSolidColorBrush.Color = FromRgbExample()
			fromRgbRect.Fill = fromRgbSolidColorBrush

			'////// FromScRgb Rectangle ///////
			Dim fromScRgbRect As New Rectangle()
			fromScRgbRect.Width = 50
			fromScRgbRect.Height = 50
			Dim fromScRgbSolidColorBrush As New SolidColorBrush()
			fromScRgbSolidColorBrush.Color = FromScRgbExample()
			fromScRgbRect.Fill = fromScRgbSolidColorBrush

			'////// FromArgb Rectangle ///////
			Dim fromArgbRect As New Rectangle()
			fromArgbRect.Width = 50
			fromArgbRect.Height = 50
			Dim fromArgbSolidColorBrush As New SolidColorBrush()
			fromArgbSolidColorBrush.Color = FromScRgbExample()
			fromArgbRect.Fill = fromArgbSolidColorBrush

			'////// FromAValues Rectangle ///////
			Dim fromAValuesRect As New Rectangle()
			fromAValuesRect.Width = 50
			fromAValuesRect.Height = 50
			Dim fromAValuesSolidColorBrush As New SolidColorBrush()
			fromAValuesSolidColorBrush.Color = FromAValuesExample()
			fromAValuesRect.Fill = fromAValuesSolidColorBrush

			'////// FromValues Rectangle ///////
			Dim fromValuesRect As New Rectangle()
			fromValuesRect.Width = 50
			fromValuesRect.Height = 50
			Dim fromValuesSolidColorBrush As New SolidColorBrush()
			fromValuesSolidColorBrush.Color = FromValuesExample()
			fromValuesRect.Fill = fromValuesSolidColorBrush

			myStackPanel.Children.Add(fromRgbRect)
			myStackPanel.Children.Add(fromScRgbRect)
			myStackPanel.Children.Add(fromArgbRect)
			myStackPanel.Children.Add(fromAValuesRect)
			myStackPanel.Children.Add(fromValuesRect)
			Me.Content = myStackPanel

		End Sub
		' <SnippetFromRgbExample>
		Private Function FromRgbExample() As Color
			' Create a green color using the FromRgb static method.
			Dim myRgbColor As New Color()
			myRgbColor = Color.FromRgb(0, 255, 0)
			Return myRgbColor
		End Function
		' </SnippetFromRgbExample>
		' <SnippetFromScRgbExample>
		Private Function FromScRgbExample() As Color
			' Create a blue color using the FromScRgb static method.
			Dim myScRgbColor As New Color()
			myScRgbColor = Color.FromScRgb(1, 0, 0, 1)
			Return myScRgbColor
		End Function
		' </SnippetFromScRgbExample>
		' <SnippetFromArgbExample>
		Private Function FromArgbExample() As Color
			' Create a blue color using the FromArgb static method.
			Dim myArgbColor As New Color()
			myArgbColor = Color.FromArgb(255, 0, 255, 0)
			Return myArgbColor
		End Function
		' </SnippetFromArgbExample>
		' <SnippetFromAValuesExample>
		Private Function FromAValuesExample() As Color
			' Create a brown color using the FromAValues static method.
			Dim myAValuesColor As New Color()
			Dim colorValues(3) As Single
			colorValues(0) = 0.0f
			colorValues(1) = 0.5f
			colorValues(2) = 0.5f
			colorValues(3) = 0.5f

			' Uri to sample color profile. This color profile is used to 
			' determine what the colors the colorValues map to.
			Dim iccUri As New Uri("C:\sampleColorProfile.icc")

			' The FromAValues method requires an explicit value for alpha
			' (first parameter). The values given by the second parameter are
			' used with the color profile specified by the third parameter to 
			' determine the color.
			myAValuesColor = Color.FromAValues(1.0f, colorValues, iccUri)
			Return myAValuesColor
		End Function
		' </SnippetFromAValuesExample>
		' <SnippetFromValuesExample>
		Private Function FromValuesExample() As Color
			' Create a brown color using the FromValues static method.
			Dim myValuesColor As New Color()
			Dim colorValues(3) As Single
			colorValues(0) = 0.0f
			colorValues(1) = 0.5f
			colorValues(2) = 0.5f
			colorValues(3) = 0.5f

			' Uri to sample color profile. This color profile is used to 
			' determine what the colors the colorValues map to.
			Dim myIccUri As New Uri("C:\sampleColorProfile.icc")

			' The values given by the first parameter are used with the color 
			' profile specified by the second parameter to determine the color.
			myValuesColor = Color.FromValues(colorValues, myIccUri)
			Return myValuesColor
		End Function
		' </SnippetFromValuesExample>
	End Class
End Namespace