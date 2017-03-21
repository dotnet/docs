' <SnippetBasicBorderCodeExampleWholePage>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class BasicBorderExample
		Inherits Page
		Public Sub New()

			Dim myTextBox As New TextBox()

			' Put some initial text in the TextBox.
			myTextBox.Text = "TextBox with a black Border around it"

			' Create a Border
			Dim myBorder As New Border()
			myBorder.BorderThickness = New Thickness(20)
			myBorder.BorderBrush = Brushes.Black

			' Add TextBox to the Border.
			myBorder.Child = myTextBox
			' myStackPanel.Children.Add(myTextBox)
			Me.Content = myBorder
		End Sub
	End Class
End Namespace
' </SnippetBasicBorderCodeExampleWholePage>