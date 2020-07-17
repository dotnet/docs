' <SnippetInlineUIContainerCodeOnlyExampleWholePage>

Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class InlineUIContainerExample
		Inherits Page
		Public Sub New()
			Dim run1 As New Run(" Text to precede the button... ")
			Dim run2 As New Run(" Text to follow the button... ")

			' Create a new button to be hosted in the paragraph.
			Dim myButton As New Button()
			myButton.Content = "Click me!"

			' Create a new InlineUIContainer to contain the Button.
			Dim myInlineUIContainer As New InlineUIContainer()

			' Set the BaselineAlignment property to "Bottom" so that the 
			' Button aligns properly with the text.
			myInlineUIContainer.BaselineAlignment = BaselineAlignment.Bottom

			' Asign the button as the UI container's child.
			myInlineUIContainer.Child = myButton

			' Create the paragraph and add content to it.
			Dim myParagraph As New Paragraph()
			myParagraph.Inlines.Add(run1)
			myParagraph.Inlines.Add(myInlineUIContainer)
			myParagraph.Inlines.Add(run2)

			' Create a FlowDocument and add the paragraph to it.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(myParagraph)

			Me.Content = myFlowDocument
		End Sub
	End Class
End Namespace
' </SnippetInlineUIContainerCodeOnlyExampleWholePage>