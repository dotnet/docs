' <SnippetBasicRichTextBoxWithContentCodeOnlyExample>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Documents
Namespace SDKSample
	Partial Public Class BasicRichTextBoxWithContentExample
		Inherits Page
		Public Sub New()
			Dim myStackPanel As New StackPanel()

			' Create a FlowDocument to contain content for the RichTextBox.
			Dim myFlowDoc As New FlowDocument()

			' Create a Run of plain text and some bold text.
			Dim myRun As New Run("This is flow content and you can ")
			Dim myBold As New Bold(New Run("edit me!"))

			' Create a paragraph and add the Run and Bold to it.
			Dim myParagraph As New Paragraph()
			myParagraph.Inlines.Add(myRun)
			myParagraph.Inlines.Add(myBold)

			' Add the paragraph to the FlowDocument.
			myFlowDoc.Blocks.Add(myParagraph)

			Dim myRichTextBox As New RichTextBox()

			' Add initial content to the RichTextBox.
			myRichTextBox.Document = myFlowDoc

			myStackPanel.Children.Add(myRichTextBox)
			Me.Content = myStackPanel

		End Sub
	End Class
End Namespace
' </SnippetBasicRichTextBoxWithContentCodeOnlyExample>