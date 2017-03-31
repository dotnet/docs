Imports Microsoft.VisualBasic
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

	Public Class SolidColorBrushExample
		Inherits Page

		Private myMainPanel As StackPanel

		Public Sub New()
			Me.WindowTitle = "SolidColorBrush Example"
			Me.Background = Brushes.White

			myMainPanel = New StackPanel()
			predefinedBrushExample()
			predefinedColorExample()
			fromScRgbExample()
			fromArgbExample()
			Me.Content = myMainPanel
		End Sub


		Private Sub predefinedBrushExample()

            ' <SnippetSolidColorBrushPredefinedBrush1VB>
			Dim myButton As New Button()
			myButton.Content = "A Button"
			myButton.Background = Brushes.Red
            ' </SnippetSolidColorBrushPredefinedBrush1VB>

			myMainPanel.Children.Add(myButton)

		End Sub

		Private Sub predefinedColorExample()

            ' <SnippetSolidColorBrushPredefinedColor1VB>
			Dim myButton As New Button()
			myButton.Content = "A Button"

			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Colors.Red
			myButton.Background = mySolidColorBrush
            ' </SnippetSolidColorBrushPredefinedColor1VB>

			myMainPanel.Children.Add(myButton)

		End Sub

		' Create a button and paint its background red.
		Private Sub fromScRgbExample()

            ' <SnippetSolidColorBrushfromScRgbExample1VB>
			Dim myButton As New Button()
			myButton.Content = "A Button"

			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromScRgb(1.0f, 1.0f, 0.0f, 0.0f) ' Specifies the amount of blue. -  specifies the amount of green. -  Specifies the amount of red. -  Specifies the transparency of the color.

			myButton.Background = mySolidColorBrush
            ' </SnippetSolidColorBrushfromScRgbExample1VB>


			myMainPanel.Children.Add(myButton)

		End Sub

		' Create a button and paint its background red.
		Private Sub fromArgbExample()

            ' <SnippetSolidColorBrushfromArgbExample1VB>
			Dim myButton As New Button()
			myButton.Content = "A Button"

			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 255, 0, 0) ' Specifies the amount of blue. -  specifies the amount of green. -  Specifies the amount of red. -  Specifies the transparency of the color.

			myButton.Background = mySolidColorBrush
            ' </SnippetSolidColorBrushfromArgbExample1VB>


			myMainPanel.Children.Add(myButton)

		End Sub

	End Class

End Namespace