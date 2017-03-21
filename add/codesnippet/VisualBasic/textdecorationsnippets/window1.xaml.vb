Imports System
Imports System.Windows
Imports System.Windows.Media

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		 Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			 SetDefaultStrikethrough()
			 'SetRedUnderline()
			 SetLinearGradientUnderline()
			 SetMaroonBaseline()
			 SetToNone()
			 'Stub01()
		 End Sub

		' <SnippetTextDecorationSnippets1>
		' Use the default font values for the strikethrough text decoration.
		Private Sub SetDefaultStrikethrough()
			' Set the underline decoration directly to the text block.
			TextBlock1.TextDecorations = TextDecorations.Strikethrough
		End Sub
		' </SnippetTextDecorationSnippets1>

		' <SnippetTextDecorationSnippets2>
		' Use a Red pen for the underline text decoration.
		Private Sub SetRedUnderline()
			' Create an underline text decoration. Default is underline.
			Dim myUnderline As New TextDecoration()

			' Create a solid color brush pen for the text decoration.
			myUnderline.Pen = New Pen(Brushes.Red, 1)
			myUnderline.PenThicknessUnit = TextDecorationUnit.FontRecommended

			' Set the underline decoration to a TextDecorationCollection and add it to the text block.
			Dim myCollection As New TextDecorationCollection()
			myCollection.Add(myUnderline)
			TextBlock2.TextDecorations = myCollection
		End Sub
		' </SnippetTextDecorationSnippets2>

		' <SnippetTextDecorationSnippets3>
		' Use a linear gradient pen for the underline text decoration.
		Private Sub SetLinearGradientUnderline()
			' Create an underline text decoration. Default is underline.
			Dim myUnderline As New TextDecoration()

			' Create a linear gradient pen for the text decoration.
			Dim myPen As New Pen()
			myPen.Brush = New LinearGradientBrush(Colors.Yellow, Colors.Red, New Point(0, 0.5), New Point(1, 0.5))
			myPen.Brush.Opacity = 0.5
			myPen.Thickness = 1.5
			myPen.DashStyle = DashStyles.Dash
			myUnderline.Pen = myPen
			myUnderline.PenThicknessUnit = TextDecorationUnit.FontRecommended

			' Set the underline decoration to a TextDecorationCollection and add it to the text block.
			Dim myCollection As New TextDecorationCollection()
			myCollection.Add(myUnderline)
			TextBlock3.TextDecorations = myCollection
		End Sub
		' </SnippetTextDecorationSnippets3>

		Private Sub SetToNone()
			' <SnippetTextDecorationSnippets5a>
			TextBlock2.TextDecorations.Clear()
			' </SnippetTextDecorationSnippets5a>
		End Sub


		' <SnippetTextDecorationSnippets6>
		' Use a Maroon pen for the baseline text decoration.
		Private Sub SetMaroonBaseline()
			' Create an baseline text decoration 2 units lower than the default.
			Dim myBaseline As New TextDecoration(TextDecorationLocation.Baseline, New Pen(Brushes.Maroon, 1), 2.0, TextDecorationUnit.Pixel, TextDecorationUnit.Pixel)

			' Set the baseline decoration to a TextDecorationCollection and add it to the text block.
			Dim myCollection As New TextDecorationCollection()
			myCollection.Add(myBaseline)
			TextBlock2.TextDecorations = myCollection
		End Sub
		' </SnippetTextDecorationSnippets6>

		Private Sub Stub01()
			' Create an underline text decoration.
			Dim myUnderline As New TextDecoration()
			myUnderline.Location = TextDecorationLocation.Underline

			' Create a solid color brush pen for the text decoration.
			myUnderline.Pen = New Pen(Brushes.Red, 1)

			' <SnippetTextDecorationSnippets7>
			' Move the text decoration lower using pixel value units.
			myUnderline.PenOffset = 2
			myUnderline.PenOffsetUnit = TextDecorationUnit.Pixel
			myUnderline.PenThicknessUnit = TextDecorationUnit.Pixel
			' </SnippetTextDecorationSnippets7>

			' Set the underline decoration to a TextDecorationCollection and add it to the text block.
			Dim myCollection As New TextDecorationCollection()
			myCollection.Add(myUnderline)
			TextBlock2.TextDecorations = myCollection
		End Sub
	End Class
End Namespace