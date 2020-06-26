' <SnippetSectionCodeOnlyExampleWholePage>

Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class SectionExample
		Inherits Page
		Public Sub New()

			' Create three paragraphs
			Dim myParagraph1 As New Paragraph(New Run("Paragraph 1"))
			Dim myParagraph2 As New Paragraph(New Run("Paragraph 2"))
			Dim myParagraph3 As New Paragraph(New Run("Paragraph 3"))

			' Create a Section and add the three paragraphs to it.
			Dim mySection As New Section()
			mySection.Background = Brushes.Red

			mySection.Blocks.Add(myParagraph1)
			mySection.Blocks.Add(myParagraph2)
			mySection.Blocks.Add(myParagraph3)

			' Create a FlowDocument and add the section to it.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(mySection)

			Me.Content = myFlowDocument
		End Sub
	End Class
End Namespace
' </SnippetSectionCodeOnlyExampleWholePage>