' <SnippetParagraphCodeOnlyExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class ParagraphExample
		Inherits Page
		Public Sub New()

			' Create paragraph with some text.
			Dim myParagraph As New Paragraph()
			myParagraph.Inlines.Add(New Run("Some paragraph text."))

			' Create a FlowDocument and add the paragraph to it.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(myParagraph)

			Me.Content = myFlowDocument
		End Sub
	End Class
End Namespace
' </SnippetParagraphCodeOnlyExampleWholePage>