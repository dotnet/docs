Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class BeginChangeEndChangeExample
		Inherits Page
		Public Sub New()

			Dim myStackPanel As New StackPanel()

			' <SnippetBeginChangeEndChangeCodeExampleInline1>
			Dim myTextBox As New TextBox()

			' Begin the change block. Once BeginChange() is called
			' no text content or selection change events will be raised 
			' until EndChange is called. Also, all edits made within
			' a BeginChange/EndChange block are wraped in a single undo block.
			myTextBox.BeginChange()

			' Put some initial text in the TextBox.
			myTextBox.Text = "Initial text in TextBox"

			' Make other changes if desired...

			' Whenever BeginChange() is called EndChange() must also be
			' called to end the change block.
			myTextBox.EndChange()
			' </SnippetBeginChangeEndChangeCodeExampleInline1>

			myStackPanel.Children.Add(myTextBox)
			Me.Content = myStackPanel

		End Sub

	End Class
End Namespace