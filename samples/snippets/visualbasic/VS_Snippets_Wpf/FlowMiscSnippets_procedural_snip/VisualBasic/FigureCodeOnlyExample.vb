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
			myFigure.Blocks.Add(myParagraph)
			myFigure.Width = New FigureLength(140, FigureUnitType.Pixel)
			myFigure.Height = New FigureLength(50, FigureUnitType.Pixel)
			myFigure.Background = Brushes.GhostWhite

			' Initial string to put in the paragraph
			Dim paragraphString As String = "Neptune(planet), major planet in the solar system, eighth planet" & "from the Sun and fourth largest in diameter.  Neptune maintains an almost constant" & "distance, about 4,490 million km (about 2,790 million mi), from the Sun.  Neptune" & "revolves outside the orbit of Uranus and for most of its orbit moves inside the" & "elliptical path of the outermost planet Pluto (see Solar System). Every 248 years," & "Pluto’s elliptical orbit brings the planet inside Neptune’s nearly circular orbit" & "for about 20 years, temporarily making Neptune the farthest planet from the Sun." & "The last time Pluto’s orbit brought it inside Neptune’s orbit was in 1979. In" & "1999 Pluto’s orbit carried it back outside Neptune’s orbit."

			Dim myContainerParagraph As New Paragraph()
			myContainerParagraph.Inlines.Add(paragraphString)
			myContainerParagraph.Inlines.Add(myFigure)
			' Create a FlowDocument with the paragraph as its initial content.
			Dim myFlowDocument As New FlowDocument(myContainerParagraph)


			Me.Content = myFlowDocument

		End Sub
	End Class
End Namespace
' </SnippetFigureLengthCodeExampleWholePage>