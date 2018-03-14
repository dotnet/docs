' <SnippetFigureLengthCodeExampleWholePage>
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class FigureCodeOnlyExample
		Inherits Page
		Public Sub New()

			' Create a paragraph
			Dim myParagraph As New Paragraph(New Run("Neptune has 72 times Earth's volume..."))
			' Create a Figure with a paragraph in it. 
			Dim myFigure As New Figure()

			' Add the paragraph to the Figure.
			myFlowDoc.Blocks.Add(myParagraph)
			myFigure.Width = New FigureLength(140, FigureUnitType.Pixel)
			myFigure.Height = New FigureLength(50, FigureUnitType.Pixel)
			myFigure.Background = Colors.GhostWhite

			' Create a FlowDocument with the paragraph as its initial content.
			Dim myFlowDocument As New FlowDocument(myFigure)

			Me.Content = myFlowDocument

		End Sub
	End Class
End Namespace
' </SnippetFigureLengthCodeExampleWholePage>