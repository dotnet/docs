' <SnippetRichTextBoxCodeOnlyExample>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Documents
Namespace SDKSample
	Partial Public Class RichTextBoxExample
		Inherits Page
		Public Sub New()

			Dim myStackPanel As New StackPanel()

			' Create a FlowDocument to contain content for the RichTextBox.
			Dim myFlowDoc As New FlowDocument()

			' Add paragraphs to the FlowDocument.
			myFlowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 1")))
			myFlowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 2")))
			myFlowDoc.Blocks.Add(New Paragraph(New Run("Paragraph 3")))
			Dim myRichTextBox As New RichTextBox()

			' Add initial content to the RichTextBox.
			myRichTextBox.Document = myFlowDoc

			myStackPanel.Children.Add(myRichTextBox)
			Me.Content = myStackPanel

		End Sub
	End Class
End Namespace
' </SnippetRichTextBoxCodeOnlyExample>