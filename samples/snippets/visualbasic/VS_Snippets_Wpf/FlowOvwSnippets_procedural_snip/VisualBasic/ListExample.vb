' <SnippetListCodeOnlyExampleWholePage>

Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class ListExample
		Inherits Page
		Public Sub New()

			' Create three paragraphs
			Dim myParagraph1 As New Paragraph(New Run("List Item 1"))
			Dim myParagraph2 As New Paragraph(New Run("List Item 2"))
			Dim myParagraph3 As New Paragraph(New Run("List Item 3"))

			' Create the ListItem elements for the List and add the 
			' paragraphs to them.
			Dim myListItem1 As New ListItem()
			myListItem1.Blocks.Add(myParagraph1)
			Dim myListItem2 As New ListItem()
			myListItem2.Blocks.Add(myParagraph2)
			Dim myListItem3 As New ListItem()
			myListItem3.Blocks.Add(myParagraph3)

			' Create a List and add the three ListItems to it.
			Dim myList As New List()

			myList.ListItems.Add(myListItem1)
			myList.ListItems.Add(myListItem2)
			myList.ListItems.Add(myListItem3)

			' Create a FlowDocument and add the section to it.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(myList)

			Me.Content = myFlowDocument
		End Sub
	End Class
End Namespace
' </SnippetListCodeOnlyExampleWholePage>