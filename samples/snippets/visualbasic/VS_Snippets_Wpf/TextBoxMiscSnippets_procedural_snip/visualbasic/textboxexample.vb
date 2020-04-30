Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class TextBoxExample
		Inherits Page
		Public Sub New()
			' <SnippetTextBoxCodeExampleInline1>
			Dim myStackPanel As New StackPanel()

			'Create TextBox
			Dim myTextBox As New TextBox()
			myTextBox.Width = 200

			' Put some initial text in the TextBox.
			myTextBox.Text = "Initial text in TextBox"

			' Set the maximum characters a user can manually type
			' into the TextBox.
			myTextBox.MaxLength = 500
			myTextBox.MinLines = 1

			' Set the maximum number of lines the TextBox will expand to 
			' accomidate text. Note: This does not constrain the amount of 
			' text that can be typed. To do that, use the MaxLength property.
			myTextBox.MaxLines = 5

			' The text typed into the box is aligned in the center.
			myTextBox.TextAlignment = TextAlignment.Center

			' When the text reaches the edge of the box, go to the next line.
			myTextBox.TextWrapping = TextWrapping.Wrap

			myStackPanel.Children.Add(myTextBox)
			Me.Content = myStackPanel
			' </SnippetTextBoxCodeExampleInline1>
		End Sub

	End Class
End Namespace