' <SnippetCharacterCasingCodeExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class CharacterCasingExample
		Inherits Page
		Public Sub New()
			Dim myStackPanel As New StackPanel()

			'Create TextBox
			Dim myTextBox As New TextBox()
			myTextBox.Width = 100

			' The CharacterCasing property of this TextBox is set to 
			' "Upper" which causes all manually typed characters to 
			' be converted to upper case.
			myTextBox.CharacterCasing = CharacterCasing.Upper
			myStackPanel.Children.Add(myTextBox)
			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
' </SnippetCharacterCasingCodeExampleWholePage>