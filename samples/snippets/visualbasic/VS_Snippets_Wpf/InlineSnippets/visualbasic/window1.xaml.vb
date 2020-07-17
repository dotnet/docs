Namespace InlineSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Siblings()
		End Sub

		Private Sub FlowDir()
			' <Snippet_Inline_FlowDirection>
			Dim run As New Run("This text run will flow from left to right.")
			run.FlowDirection = FlowDirection.LeftToRight
			' </Snippet_Inline_FlowDirection>
		End Sub

		Private Sub Siblings()
			' <Snippet_Inline_SiblingBase>
			' A host paragraph to hold the example Inline elements..
			Dim par As New Paragraph()

			' Some arbitrary Inline elements.
			Dim run1 As New Run("Text run number 1.")
			Dim run2 As New Run("Text run number 2.")
			Dim bold As New Bold(New Run("Bold text."))
			Dim ital As New Italic(New Run("Italic text."))
			Dim span1 As New Span(New Run("Span number 1"))
			Dim span2 As New Span(New Run("Span number 2"))

			' Add the Inline elements to the Paragraph. Note the order
			' of the inline elements in the paragraph; the order is 
			' arbitrary, but the notion of an order is important with 
			' respect to  what are 'previous' and 'next' elements.
			par.Inlines.Add(run1)
			par.Inlines.Add(run2)
			par.Inlines.Add(bold)
			par.Inlines.Add(ital)
			par.Inlines.Add(span1)
			par.Inlines.Add(span2)
			' </Snippet_Inline_SiblingBase>

			' <Snippet_Inline_NextSibling>
			' After this line executes, "nextSibling" holds "run2", which is
			' the next peer-level Inline following "run1".
			Dim nextSibling As Inline = run1.NextInline

			' After this line executes, "nextSibling" holds "span1", which is
			' the next peer-level Inline following "ital".
			nextSibling = ital.NextInline

			' After this line executes, "nextSibling" is null, since "span2" is the
			' last Inline element in the Paragraph.
			nextSibling = span2.NextInline
			' </Snippet_Inline_NextSibling>

			' <Snippet_Inline_PreviousSibling>
			' After this line executes, "previousSibling" is null, since "run1" is
			' the first Inline element in the Paragraph.
			Dim previousSibling As Inline = run1.PreviousInline

			' After this line executes, "previousSibling" holds "bold", which is the
			' first peer-level Inline preceeding "ital".
			previousSibling = ital.PreviousInline

			' After this line executes, "previousSibling" holds "span1", which is the
			' first peer-level Inline preceeding "span1".
			previousSibling = span2.NextInline
			' </Snippet_Inline_PreviousSibling>

			' <Snippet_Inline_Siblings>
			' After this line executes, "siblingInlines" holds "run1", "run2",
			' "bold", "ital", "span1", and "span2", which are all of the sibling
			' Inline elements for "run1" (including "run1");
			Dim siblingInlines As InlineCollection = run1.SiblingInlines

			' Since "bold" is a sibling to "run1", this call will return the
			' same collection of sibling elements as the previous call.
			siblingInlines = bold.SiblingInlines
			' </Snippet_Inline_Siblings>
		End Sub

		Private Sub TextDec()
				' <Snippet_Inline_TextDec>
				Dim run1 As New Run("This text will render with the strikethrough effect.")
				run1.TextDecorations = TextDecorations.Strikethrough
				' </Snippet_Inline_TextDec>
				' <Snippet_Paragraph_TextDec>
				Dim parx As New Paragraph(New Run("This text will render with the strikethrough effect."))
				parx.TextDecorations = TextDecorations.Strikethrough
				' </Snippet_Paragraph_TextDec>
				' <Snippet_TextBlock_TextDec>
				Dim textBlock As New TextBlock(New Run("This text will render with the strikethrough effect."))
				textBlock.TextDecorations = TextDecorations.Strikethrough
				' </Snippet_TextBlock_TextDec>
		End Sub
	End Class
End Namespace
