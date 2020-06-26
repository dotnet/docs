' <SnippetSpellCheckCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class SpellCheckExample
		Inherits Page
		Public Sub New()
			Dim myStackPanel As New StackPanel()

			'Create TextBox
			Dim myTextBox As New TextBox()
			myTextBox.Width = 200

			' Enable spellchecking on the TextBox.
			myTextBox.SpellCheck.IsEnabled = True

			' Alternatively, the SetIsEnabled method could be used
			' to enable or disable spell checking like this:
			' SpellCheck.SetIsEnabled(myTextBox, True)

			myStackPanel.Children.Add(myTextBox)
			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
' </SnippetSpellCheckCodeExampleWholePage>