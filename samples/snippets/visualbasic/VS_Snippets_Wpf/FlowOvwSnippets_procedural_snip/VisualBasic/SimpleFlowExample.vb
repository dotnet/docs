' <SnippetSimpleFlowCodeOnlyExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class SimpleFlowExample
		Inherits Page
		Public Sub New()

			Dim myParagraph As New Paragraph()

			' Add some Bold text to the paragraph
			myParagraph.Inlines.Add(New Bold(New Run("Some bold text in the paragraph.")))

			' Add some plain text to the paragraph
			myParagraph.Inlines.Add(New Run(" Some text that is not bold."))

			' Create a List and populate with three list items.
			Dim myList As New List()

			' First create paragraphs to go into the list item.
			Dim paragraphListItem1 As New Paragraph(New Run("ListItem 1"))
			Dim paragraphListItem2 As New Paragraph(New Run("ListItem 2"))
			Dim paragraphListItem3 As New Paragraph(New Run("ListItem 3"))

			' Add ListItems with paragraphs in them.
			myList.ListItems.Add(New ListItem(paragraphListItem1))
			myList.ListItems.Add(New ListItem(paragraphListItem2))
			myList.ListItems.Add(New ListItem(paragraphListItem3))

			' Create a FlowDocument with the paragraph and list.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(myParagraph)
			myFlowDocument.Blocks.Add(myList)

			' Add the FlowDocument to a FlowDocumentReader Control
			Dim myFlowDocumentReader As New FlowDocumentReader()
			myFlowDocumentReader.Document = myFlowDocument

			Me.Content = myFlowDocumentReader
		End Sub
	End Class
End Namespace
' </SnippetSimpleFlowCodeOnlyExampleWholePage>