Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.TextFormatting

Imports CustomTextClasses

Namespace WindowsApplication1
	Partial Public Class Window1
		Inherits Window
		Private customTextSource As CustomTextSource

		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			' Initialize the text store.
			If customTextSource Is Nothing Then
				customTextSource = New CustomTextSource()
			End If

			UpdateFormattedText03()
		End Sub

		Private Sub UpdateFormattedText()
			' Index into the text of the TextSource object.
			Dim textStorePosition As Integer = 0

			' The position of the current line.
			Dim linePosition As New Point(0, 0)

			' Create a DrawingGroup object for storing formatted text.
			myTextDisplay = New DrawingGroup()
			Dim drawingContext As DrawingContext = myTextDisplay.Open()

			' Update the text store.
			customTextSource.Text = textToFormat.Text

			' <SnippetTextFormattingSnippet1>
			' Create a TextFormatter object.
			Dim formatter As TextFormatter = TextFormatter.Create()

			' Create common paragraph property settings.
			Dim customTextParagraphProperties As New CustomTextParagraphProperties()

			' Format each line of text from the text store and draw it.
			Do While textStorePosition < customTextSource.Text.Length
				' Create a textline from the text store using the TextFormatter object.
				Using myTextLine As TextLine = formatter.FormatLine(customTextSource, textStorePosition, 96 * 6, customTextParagraphProperties, Nothing)
					' Draw the formatted text into the drawing context.
					myTextLine.Draw(drawingContext, linePosition, InvertAxes.None)

					' Update the index position in the text store.
					textStorePosition += myTextLine.Length

					' Update the line position coordinate for the displayed line.
					linePosition.Y += myTextLine.Height
				End Using
			Loop
			' </SnippetTextFormattingSnippet1>

			' Persist the drawn text content.
			drawingContext.Close()

			' Display the formatted text in the DrawingGroup object.
			myDrawingBrush.Drawing = myTextDisplay
		End Sub

		Private Sub UpdateFormattedText02()
			' Create a DrawingGroup object for storing formatted text.
			myTextDisplay = New DrawingGroup()
			Dim drawingContext As DrawingContext = myTextDisplay.Open()

			' Update the text store.
			customTextSource.Text = "The quick red fox jumped over the lazy brown dog."

			' Create a TextFormatter object.
			Dim formatter As TextFormatter = TextFormatter.Create()

			' Create common paragraph property settings.
			Dim customTextParagraphProperties As New CustomTextParagraphProperties()

			' <SnippetTextFormattingSnippet2>
			' Create a textline from the text store using the TextFormatter object.
			Dim myTextLine As TextLine = formatter.FormatLine(customTextSource, 0, 400, customTextParagraphProperties, Nothing)

			' Draw the formatted text into the drawing context.
			myTextLine.Draw(drawingContext, New Point(0, 0), InvertAxes.None)
			' </SnippetTextFormattingSnippet2>

			' Persist the drawn text content.
			drawingContext.Close()

			' Display the formatted text in the DrawingGroup object.
			myDrawingBrush.Drawing = myTextDisplay
		End Sub

		Private Sub UpdateFormattedText03()
			' Index into the text of the TextSource object.
			Dim textStorePosition As Integer = 0

			' The position of the current line.
			Dim linePosition As New Point(0, 0)

			' Create a DrawingGroup object for storing formatted text.
			myTextDisplay = New DrawingGroup()
			Dim drawingContext As DrawingContext = myTextDisplay.Open()

			' Update the text store.
			customTextSource.Text = textToFormat.Text

			' Create a TextFormatter object.
			Dim formatter As TextFormatter = TextFormatter.Create()

			' Create common paragraph property settings.
			Dim customTextParagraphProperties As New CustomTextParagraphProperties()

			' <SnippetTextFormattingSnippet3>
			Dim minMaxParaWidth As MinMaxParagraphWidth = formatter.FormatMinMaxParagraphWidth(customTextSource, 0, customTextParagraphProperties)

			' Format each line of text from the text store and draw it.
			Do While textStorePosition < customTextSource.Text.Length
				' Create a textline from the text store using the TextFormatter object.
				Using myTextLine As TextLine = formatter.FormatLine(customTextSource, textStorePosition, minMaxParaWidth.MinWidth, customTextParagraphProperties, Nothing)
					' Draw the formatted text into the drawing context.
					myTextLine.Draw(drawingContext, linePosition, InvertAxes.None)

					' Update the index position in the text store.
					textStorePosition += myTextLine.Length

					' Update the line position coordinate for the displayed line.
					linePosition.Y += myTextLine.Height
				End Using
			Loop
			' </SnippetTextFormattingSnippet3>

			Dim myTextLine2 As TextLine = formatter.FormatLine(customTextSource, 0, minMaxParaWidth.MaxWidth, customTextParagraphProperties, Nothing)
			myTextLine2.Draw(drawingContext, linePosition, InvertAxes.None)

			' Persist the drawn text content.
			drawingContext.Close()

			' Display the formatted text in the DrawingGroup object.
			myDrawingBrush.Drawing = myTextDisplay
		End Sub
	End Class
End Namespace