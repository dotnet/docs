' <SnippetInsertInlineIntoTextExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class InsertInlineIntoTextExample
		Inherits Page
		Public Sub New()

			' Create a paragraph with a short sentence
			Dim myParagraph As New Paragraph(New Run("Neptune has 72 times Earth's volume..."))

			' Create two TextPointers that will specify the text range the Span will cover
			Dim myTextPointer1 As TextPointer = myParagraph.ContentStart.GetPositionAtOffset(10)
			Dim myTextPointer2 As TextPointer = myParagraph.ContentEnd.GetPositionAtOffset(-5)

			' Create a Span that covers the range between the two TextPointers.
			Dim mySpan As New Span(myTextPointer1, myTextPointer2)
			mySpan.Background = Brushes.Red

			' Create a FlowDocument with the paragraph as its initial content.
			Dim myFlowDocument As New FlowDocument(myParagraph)

			Me.Content = myFlowDocument

		End Sub
	End Class
End Namespace
' </SnippetInsertInlineIntoTextExampleWholePage>