' <SnippetFigureCodeOnlyExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class FigureExample
		Inherits Page
		Public Sub New()

			' Create strings to use as content.
			Dim strFigure As String = "A Figure embeds content into flow content with" & " placement properties that can be customized" & " independently from the primary content flow"
			Dim strOther As String = "Lorem ipsum dolor sit amet, consectetuer adipiscing" & " elit, sed diam nonummy nibh euismod tincidunt ut laoreet" & " dolore magna aliquam erat volutpat. Ut wisi enim ad" & " minim veniam, quis nostrud exerci tation ullamcorper" & " suscipit lobortis nisl ut aliquip ex ea commodo consequat." & " Duis autem vel eum iriure."

			' Create a Figure and assign content and layout properties to it.
			Dim myFigure As New Figure()
			myFigure.Width = New FigureLength(300)
			myFigure.Height = New FigureLength(100)
			myFigure.Background = Brushes.GhostWhite
			myFigure.HorizontalAnchor = FigureHorizontalAnchor.PageLeft
			Dim myFigureParagraph As New Paragraph(New Run(strFigure))
			myFigureParagraph.FontStyle = FontStyles.Italic
			myFigureParagraph.Background = Brushes.Beige
			myFigureParagraph.Foreground = Brushes.DarkGreen
			myFigure.Blocks.Add(myFigureParagraph)

			' Create the paragraph and add content to it.
			Dim myParagraph As New Paragraph()
			myParagraph.Inlines.Add(myFigure)
			myParagraph.Inlines.Add(New Run(strOther))

			' Create a FlowDocument and add the paragraph to it.
			Dim myFlowDocument As New FlowDocument()
			myFlowDocument.Blocks.Add(myParagraph)

			Me.Content = myFlowDocument
		End Sub
	End Class
End Namespace
' </SnippetFigureCodeOnlyExampleWholePage>