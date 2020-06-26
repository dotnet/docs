Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Imports System.Windows.Media.Animation

Namespace TextElementSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			ForgroundBackground()
			ContentStartEnd()
			FontProps()
			TypographyProps()
			ContentStartEnd()
			TextEffectsProp()

			TextBlockTextEffectsProp()
		End Sub

		Private Sub ForgroundBackground()
			' <Snippet_TextElement_Background>
			Dim run As New Run("This text has a foreground color of dark green, and a background color of bisque.")
			Dim par As New Paragraph(run)

			par.Background = Brushes.Bisque
			par.Foreground = Brushes.DarkGreen
			' </Snippet_TextElement_Background>
		End Sub

		Private Sub FontProps()
			' <Snippet_TextElement_FontProps>
			Dim run As New Run("This text will use the Century Gothic font (if available), with fallback to Courier New." & "It will render with a font size of 16 pixels in ultra-expanded demi-bold italic.")
			Dim par As New Paragraph(run)

            With par
                .FontFamily = New FontFamily("Century Gothic, Courier New")
                .FontSize = 16
                .FontStretch = FontStretches.UltraExpanded
                .FontStyle = FontStyles.Italic
                .FontWeight = FontWeights.DemiBold
            End With
            ' </Snippet_TextElement_FontProps>
		End Sub

		Private Sub TypographyProps()
			' <Snippet_TextElement_Typog>
			Dim par As New Paragraph()

			Dim runText As New Run("This text has some altered typography characteristics.  Note" & "that use of an open type font is necessary for most typographic" & "properties to be effective.")
			Dim runNumerals As New Run("0123456789 10 11 12 13")
			Dim runFractions As New Run("1/2 2/3 3/4")

			par.Inlines.Add(runText)
			par.Inlines.Add(New LineBreak())
			par.Inlines.Add(New LineBreak())
			par.Inlines.Add(runNumerals)
			par.Inlines.Add(New LineBreak())
			par.Inlines.Add(New LineBreak())
			par.Inlines.Add(runFractions)

			par.TextAlignment = TextAlignment.Left
			par.FontSize = 18
			par.FontFamily = New FontFamily("Palatino Linotype")

			par.Typography.NumeralStyle = FontNumeralStyle.OldStyle
			par.Typography.Fraction = FontFraction.Stacked
			par.Typography.Variants = FontVariants.Inferior
			' </Snippet_TextElement_Typog>
		End Sub

		Private Sub ContentStartEnd()
'            
'            // <Snippet_TextElement_ContStartEnd>
'            Paragraph par = new Paragraph();
'
'            Run run1 = new Run("Run 1...");
'            Run run2 = new Run("Run 2...");
'            Run run3 = new Run("Run 3...");
'            Run run4 = new Run("Run 4...");
'
'            par.ContentEnd.InsertTextInRun("Run 1...");
'            par.ContentEnd.InsertParagraphBreak();
'            par.ContentEnd.InsertTextInRun("Run 2...");
'
'            par.ContentStart.InsertParagraphBreak();
'            par.ContentStart.InsertTextInRun("Run 3...");
'            par.ContentStart.InsertParagraphBreak();
'            par.ContentStart.InsertTextInRun("Run 4...");
'            // </Snippet_TextElement_ContStartEnd>
'
'            // flowDoc.Blocks.Add(par);
'            
		End Sub

		Private Sub TextEffectsProp()
			' <Snippet_TextElement_TextEffects>
			' Create and configure a simple color animation sequence.  Timespan is in 100ns ticks.
			Dim blackToWhite As New ColorAnimation(Colors.White, Colors.Black, New Duration(New TimeSpan(100000)))
			blackToWhite.AutoReverse = True
			blackToWhite.RepeatBehavior = RepeatBehavior.Forever

			' Create a new brush and apply the color animation.
			Dim scb As New SolidColorBrush(Colors.Black)
			scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite)

			' Create a new TextEffect object; set foreground brush to the previously created brush.
			Dim tfe As New TextEffect()
			tfe.Foreground = scb
			' Range of text to apply effect to (all).
			tfe.PositionStart = 0
			tfe.PositionCount = Integer.MaxValue

			' Create a new text run, and add the previously created text effect to the run's effects collection.
			Dim flickerRun As New Run("Text that flickers...")
			flickerRun.TextEffects = New TextEffectCollection()
			flickerRun.TextEffects.Add(tfe)
			' </Snippet_TextElement_TextEffects>

			flowDoc.Blocks.Add(New Paragraph(flickerRun))
		End Sub

		Private Sub TextBlockTextEffectsProp()
			' <Snippet_TextBlock_TextEffects>
			' Create and configure a simple color animation sequence.  Timespan is in 100ns ticks.
			Dim blackToWhite As New ColorAnimation(Colors.White, Colors.Black, New Duration(New TimeSpan(100000)))
			blackToWhite.AutoReverse = True
			blackToWhite.RepeatBehavior = RepeatBehavior.Forever

			' Create a new brush and apply the color animation.
			Dim scb As New SolidColorBrush(Colors.Black)
			scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite)

			' Create a new TextEffect object; set foreground brush to the previously created brush.
			Dim tfe As New TextEffect()
			tfe.Foreground = scb
			' Range of text to apply effect to (all).
			tfe.PositionStart = 0
			tfe.PositionCount = Integer.MaxValue

			' Create a new TextBlock with some text.
			Dim textBlock As New TextBlock()
			textBlock.Text = "Text that flickers..."

			' The TextEffects property is null (no collection) by default.  Create a new one.
			textBlock.TextEffects = New TextEffectCollection()

			' Add the previously created effect to the TextEffects collection.
			textBlock.TextEffects.Add(tfe)
			' </Snippet_TextBlock_TextEffects>
		End Sub

	End Class
End Namespace