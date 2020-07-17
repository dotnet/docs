' <SnippetChangeSelectionProgrammaticalyCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class ChangeSelectionProgrammaticaly
		Inherits Page

		' Change the current selection.
		Private Sub ChangeSelection(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Create two arbitrary TextPointers to specify the range of content to select.
			Dim myTextPointer1 As TextPointer = myParagraph.ContentStart.GetPositionAtOffset(20)
			Dim myTextPointer2 As TextPointer = myParagraph.ContentEnd.GetPositionAtOffset(-10)

			' Programmatically change the selection in the RichTextBox.
			richTB.Selection.Select(myTextPointer1, myTextPointer2)
		End Sub
	End Class
End Namespace
' </SnippetChangeSelectionProgrammaticalyCodeExampleWholePage>